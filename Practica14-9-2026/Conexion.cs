using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Practica14_9_2026
{
    /// <summary>
    /// Acceso a datos (estructura del Laboratorio 4 adaptada a SQL Server).
    /// Cada operación abre su propia conexión dentro de un using, así se cierra
    /// y se devuelve al pool aunque ocurra un error.
    /// </summary>
    public static class Conexion
    {
        private static readonly string cadenaConexion =
            "Data Source=Mateo;Initial Catalog=productosdb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        // Los nombres de tabla y columna no pueden ir como parámetros (@...), por eso
        // se validan contra una lista blanca antes de armar el SQL dinámico.
        private static readonly HashSet<string> tablasPermitidas =
            new(StringComparer.OrdinalIgnoreCase) { "productos" };

        private static readonly HashSet<string> columnasPermitidas =
            new(StringComparer.OrdinalIgnoreCase) { "nombre", "precio", "cantidad", "imagen" };

        /// <summary>Mensaje del último error de base de datos (vacío si la última operación salió bien).</summary>
        public static string UltimoError { get; private set; } = string.Empty;

        public static SqlConnection? ObtenerConexion()
        {
            var conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                conexion.Dispose();
                RegistrarError("Error al conectar: ", ex);
                return null;
            }
        }

        public static List<Producto> GetProductos(string filtro)
        {
            UltimoError = string.Empty;
            List<Producto> listaProductos = new List<Producto>();

            string query = "SELECT id, nombre, precio, cantidad, imagen FROM productos";

            // En SQL Server LIKE trabaja sobre texto, por eso los números se convierten con CAST.
            if (!string.IsNullOrEmpty(filtro))
            {
                query += " WHERE CAST(id AS NVARCHAR(20)) LIKE @filtro OR nombre LIKE @filtro" +
                         " OR CAST(precio AS NVARCHAR(20)) LIKE @filtro OR CAST(cantidad AS NVARCHAR(20)) LIKE @filtro";
            }
            query += " ORDER BY id";

            using (SqlConnection? conn = ObtenerConexion())
            {
                if (conn == null) return listaProductos;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // El filtro viaja como parámetro: evita inyección SQL
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.Add("@filtro", SqlDbType.NVarChar, 200).Value = "%" + EscaparLike(filtro) + "%";
                    }

                    try
                    {
                        using (SqlDataReader mReader = cmd.ExecuteReader())
                        {
                            while (mReader.Read())
                            {
                                Producto prod = new Producto();

                                // Los nombres entre comillas deben coincidir con las columnas de la tabla
                                prod.Id = Convert.ToInt32(mReader["id"]);
                                prod.Nombre = mReader["nombre"].ToString() ?? string.Empty;
                                prod.Precio = Convert.ToDecimal(mReader["precio"]);
                                prod.Cantidad = Convert.ToInt32(mReader["cantidad"]);
                                prod.Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null;

                                listaProductos.Add(prod);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        RegistrarError("Error en SELECT: ", ex);
                    }
                }
            }

            return listaProductos;
        }

        public static bool InsertSeguro(string tbName, Dictionary<string, object?> data)
        {
            UltimoError = string.Empty;
            ValidarIdentificadores(tbName, data.Keys);

            var columns = string.Join(", ", data.Keys);
            var placeholders = "@" + string.Join(", @", data.Keys);
            string sql = $"INSERT INTO {tbName} ({columns}) VALUES ({placeholders})";

            return EjecutarNoConsulta(sql, data, null, "Error en INSERT: ");
        }

        public static bool UpdateSeguro(string tbName, Dictionary<string, object?> data, int id)
        {
            UltimoError = string.Empty;
            ValidarIdentificadores(tbName, data.Keys);

            var asignaciones = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
            string sql = $"UPDATE {tbName} SET {asignaciones} WHERE id = @id";

            return EjecutarNoConsulta(sql, data, id, "Error en UPDATE: ");
        }

        public static bool DeleteSeguro(string tbName, int id)
        {
            UltimoError = string.Empty;
            ValidarIdentificadores(tbName, Array.Empty<string>());

            string sql = $"DELETE FROM {tbName} WHERE id = @id";

            return EjecutarNoConsulta(sql, new Dictionary<string, object?>(), id, "Error en DELETE: ");
        }

        private static bool EjecutarNoConsulta(string sql, Dictionary<string, object?> data, int? id, string prefijoError)
        {
            try
            {
                using (SqlConnection? conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (SqlCommand stmt = new SqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            AgregarParametro(stmt, kvp.Key, kvp.Value);
                        }

                        if (id.HasValue)
                        {
                            stmt.Parameters.Add("@id", SqlDbType.Int).Value = id.Value;
                        }

                        // true solo si de verdad se afectó al menos un registro
                        return stmt.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                RegistrarError(prefijoError, ex);
                return false;
            }
        }

        private static void AgregarParametro(SqlCommand cmd, string nombre, object? valor)
        {
            // Con AddWithValue un null (DBNull) se envía como NVARCHAR y SQL Server rechaza
            // guardarlo en VARBINARY(MAX). Por eso la imagen se declara con su tipo exacto.
            if (nombre.Equals("imagen", StringComparison.OrdinalIgnoreCase) || valor is byte[])
            {
                cmd.Parameters.Add("@" + nombre, SqlDbType.VarBinary, -1).Value = valor ?? DBNull.Value;
            }
            else
            {
                cmd.Parameters.AddWithValue("@" + nombre, valor ?? DBNull.Value);
            }
        }

        private static void ValidarIdentificadores(string tabla, IEnumerable<string> columnas)
        {
            if (!tablasPermitidas.Contains(tabla))
                throw new ArgumentException($"Tabla no permitida: {tabla}");

            foreach (string columna in columnas)
            {
                if (!columnasPermitidas.Contains(columna))
                    throw new ArgumentException($"Columna no permitida: {columna}");
            }
        }

        // %, _ y [ son comodines de LIKE en SQL Server; se escapan para buscarlos como texto normal.
        private static string EscaparLike(string texto)
        {
            return texto.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
        }

        private static void RegistrarError(string prefijo, SqlException ex)
        {
            UltimoError = prefijo + ex.Message;
            Console.WriteLine(UltimoError);
            Debug.WriteLine(UltimoError);
        }
    }
}
