namespace Practica14_9_2026
{
    /// <summary>
    /// Modelo de un registro de la tabla productos.
    /// La imagen se guarda como byte[] porque en la base de datos es VARBINARY(MAX)
    /// (el equivalente en SQL Server del LONGBLOB de MySQL que muestra el laboratorio).
    /// </summary>
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public byte[]? Imagen { get; set; }
    }
}
