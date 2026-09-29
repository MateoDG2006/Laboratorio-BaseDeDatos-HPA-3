using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace Practica14_9_2026
{
    internal class Validaciones
    {
        static public int validateID(string id)
        {
            BaseDeDatos database = new BaseDeDatos();

            database.AsegurarConexionAbierta();

            if (!int.TryParse(id, out int numero) || numero <= 0)
            {
                MessageBox.Show("El ID debe ser un número entero mayor que cero.");
            }


            const string query = @"
                SELECT COALESCE(MAX(CAST(id AS BIGINT)), 0) + 1
                FROM productos";

            using (var cmd = new SqlCommand(query, database.connection))
            {
                long siguienteID = Convert.ToInt64(cmd.ExecuteScalar());

                if (numero != siguienteID)
                {
                    numero = (int)siguienteID;
                }
            }

            return numero;
        }
        static public string validateName(string name)
        {
            Regex regex_without_numbers = new Regex(@"^[^\d]+$");
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return "";
            }
            if (!regex_without_numbers.IsMatch(name))
            {
                MessageBox.Show("El nombre no puede contener números.");
                return "";
            }

            return name;
        }
        static public decimal validatePrice(object price)
        {
            decimal new_price = 0;
            try
            {
                new_price = Convert.ToDecimal(price);
                if (new_price <= 0)
                {
                    MessageBox.Show("El precio debe ser un número decimal mayor que cero.");
                    return 0;
                }
                return new_price;
            }
            catch
            {
                MessageBox.Show("El precio debe ser un número decimal válido.");
                return 0;
            }
        }

        static public int validateQuantity(object quantity)
        {
            if (int.TryParse(quantity.ToString(), out int new_quantity))
            {
                if (new_quantity <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor que cero.");
                    return 0;
                }
                return new_quantity;
            }
            else
            {
                MessageBox.Show("La cantidad debe ser un número entero válido.");
                return 0;
            }
        }

    }
    internal class ValidacionImagenes
    {
        static public bool validateImageBytes(byte[] imageData )
        {
            if (imageData == null || imageData.Length == 0)
            {
                return false;
            }
            return true;
        }
        static public bool validateImage(Image image)
        {
            if(image != null)
            {
                return true;
            }
            return false;
        }
    }
}
