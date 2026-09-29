using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Practica14_9_2026
{
    internal class BaseDeDatos
    {
        const string connectionString = "Data Source=Mateo;Initial Catalog=productosdb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public SqlConnection connection = new SqlConnection(connectionString);
        public SqlCommand command;
        public SqlDataReader reader;
        public void AsegurarConexionAbierta()
        {
            if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CerrarConexion()
        {
            connection.Dispose();
        }

        public Product[] getProductsDatabase()
        {
            var productos = new List<Product>();
            string get = $"SELECT * FROM productos";

            AsegurarConexionAbierta();
            command = new SqlCommand(get, connection);
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    byte[] image_bytes = (byte[])reader["imagen"];
                    Image img;
                    var product = new Product
                    {
                        id = (int)reader["id"],
                        name = (string)reader["nombre"],
                        price = (decimal)reader["precio"],
                        quantity = (int)reader["cantidad"],
                    };

                    if (ValidacionImagenes.validateImageBytes(image_bytes))
                    {
                        img = Product.getImage((byte[])reader["imagen"]);
                        product.image = img;
                    }
                    productos.Add(product);
                }
            }
            return productos.ToArray();
        }

        public string modifyProductDatabase(Product producto)
        {
            const string update = @"
                UPDATE productos
                SET nombre = @nombre,
                    precio = @precio,
                    cantidad = @cantidad,
                    imagen = @imagen
                WHERE id = @id";

            try
            {
                AsegurarConexionAbierta();

                using (var cmd = new SqlCommand(update, connection))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int)
                        .Value = producto.id;

                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar)
                        .Value = producto.name;

                    cmd.Parameters.Add("@precio", SqlDbType.Decimal)
                        .Value = producto.price;

                    cmd.Parameters.Add("@cantidad", SqlDbType.Int)
                        .Value = producto.quantity;

                    cmd.Parameters.Add("@imagen", SqlDbType.VarBinary, -1)
                        .Value = Product.setImage(producto.image);

                    cmd.ExecuteNonQuery();
                }

                return "Actualización ejecutada";
            }
            catch (SqlException ex)
            {
                return $"Error al modificar el producto: {ex.Message}";
            }
        }
        public string insertProductDatabase(Product producto)
        {
            const string insert = @"
                    INSERT INTO productos 
                        (
                            nombre, 
                            precio, 
                            cantidad, 
                            imagen
                        ) 
                    VALUES 
                        (
                            @nombre, 
                            @precio, 
                            @cantidad, 
                            @imagen
                        )";
            try
            {
                AsegurarConexionAbierta();

                using (var cmd = new SqlCommand(insert, connection))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar)
                        .Value = producto.name;

                    cmd.Parameters.Add("@precio", SqlDbType.Decimal)
                        .Value = producto.price;

                    cmd.Parameters.Add("@cantidad", SqlDbType.Int)
                        .Value = producto.quantity;

                    cmd.Parameters.Add("@imagen", SqlDbType.VarBinary, -1)
                        .Value = Product.setImage(producto.image);

                    cmd.ExecuteNonQuery();
                }

                return "Producto insertado correctamente";
            }
            catch (SqlException ex)
            {
                return $"Error al insertar el producto: {ex.Message}";
            }
        }
    }
}
