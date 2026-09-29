using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
namespace Practica14_9_2026
{
    public partial class Form1 : Form
    {
        BaseDeDatos database = new BaseDeDatos();

        public Form1()
        {
            InitializeComponent();
        }
        private void CargarProductos()
        {
            Product[] productos = database.getProductsDatabase();

            dgv_productos.Rows.Clear();

            foreach (Product producto in productos)
            {
                dgv_productos.Rows.Add(
                    producto.id,
                    producto.name,
                    producto.price,
                    producto.quantity,
                    producto.image);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Product producto = new Product();
            producto.id = Validaciones.validateID(txt_folio.Text);
            producto.name = Validaciones.validateName(txt_nombre.Text);
            producto.price = Validaciones.validatePrice(txt_precio.Text);
            producto.quantity = Validaciones.validateQuantity(txt_cantidad.Text);
            if (ValidacionImagenes.validateImage(pb_imagenes.Image))
            {
                producto.image = pb_imagenes.Image;
            }
            else
            {
                producto.image = null;
            }

            string result = database.insertProductDatabase(producto);
            MessageBox.Show(result);
            CargarProductos();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            Product producto = new Product();
            producto.id = int.Parse(txt_folio.Text);
            producto.name = txt_nombre.Text;
            producto.price = decimal.Parse(txt_precio.Text);
            producto.quantity = int.Parse(txt_cantidad.Text);
            if (ValidacionImagenes.validateImage(pb_imagenes.Image))
            {
                producto.image = pb_imagenes.Image;
            }
            else
            {
                producto.image = null;
            }

            string result = database.modifyProductDatabase(producto);
            MessageBox.Show(result);
            CargarProductos();
        }

        private void btn_cargar_imagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            // Si el usuario selecciona una imagen y presiona Aceptar
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Cargamos la imagen en el PictureBox usando la ruta seleccionada
                pb_imagenes.Image = Image.FromFile(openFileDialog1.FileName);
            }
            CargarProductos();
        }
    }
}
