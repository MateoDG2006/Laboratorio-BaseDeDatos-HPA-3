using System.Globalization;

namespace Practica14_9_2026
{
    /// <summary>
    /// Reglas de validación de los campos del producto.
    /// Cada método devuelve null si el dato es correcto, o el mensaje de error a mostrar.
    /// </summary>
    internal static class Validaciones
    {
        // Límites que impone la tabla: NVARCHAR(100) y DECIMAL(10,2)
        public const int LargoMaximoNombre = 100;
        public const decimal PrecioMaximo = 99_999_999.99m;

        // Límite razonable para no cargar fotos enormes en la tabla
        public const long TamanoMaximoImagen = 5 * 1024 * 1024;

        public static string? ValidarNombre(string nombre)
        {
            if (nombre.Equals(""))
                return "Ingrese el Nombre del Producto";

            if (nombre.Length > LargoMaximoNombre)
                return $"El nombre no puede superar {LargoMaximoNombre} caracteres.";

            if (nombre.Any(char.IsDigit))
                return "El nombre no puede contener números.";

            return null;
        }

        public static string? ValidarPrecio(string texto, out decimal precio)
        {
            precio = 0;

            if (texto.Equals(""))
                return "Ingrese el Precio";

            // decimal.TryParse no lanza excepción: devuelve false si el texto no es un número
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out precio))
                return "Ingrese un Precio correcto";

            if (precio <= 0)
                return "El precio debe ser mayor que cero.";

            if (precio > PrecioMaximo)
                return $"El precio no puede ser mayor que {PrecioMaximo:N2}.";

            if (decimal.Round(precio, 2) != precio)
                return "El precio admite como máximo 2 decimales.";

            return null;
        }

        public static string? ValidarCantidad(string texto, out int cantidad)
        {
            cantidad = 0;

            if (texto.Equals(""))
                return "Ingrese la Cantidad";

            if (!int.TryParse(texto, out cantidad))
                return "Ingrese una Cantidad correcta (número entero)";

            if (cantidad <= 0)
                return "La cantidad debe ser mayor que cero.";

            return null;
        }
    }
}
