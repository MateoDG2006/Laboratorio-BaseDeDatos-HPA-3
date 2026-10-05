using System.Drawing.Imaging;

namespace Practica14_9_2026
{
    public partial class Form1 : Form
    {
        private const string Tabla = "productos";

        // Lista con los registros traídos de la tabla productos
        private List<Producto> listaProductos;

        // Diccionario columna -> valor que se envía a InsertSeguro / UpdateSeguro
        private readonly Dictionary<string, object?> myProducto = new Dictionary<string, object?>();

        // Folio del producto seleccionado en la rejilla (null = ninguno, se está capturando uno nuevo)
        private int? folioSeleccionado;

        public Form1()
        {
            InitializeComponent();
            listaProductos = new List<Producto>();
            ConfigurarIconos();
            ConfigurarTabla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();

            if (!string.IsNullOrEmpty(Conexion.UltimoError))
            {
                MostrarError("No se pudieron cargar los productos.");
            }
        }

        #region Configuración visual

        private void ConfigurarIconos()
        {
            // El ImageList no se escala solo con los DPI: se calcula el tamaño real del ícono
            int tam = LogicalToDeviceUnits(24);
            imageList1.ImageSize = new Size(tam, tam);
            imageList1.Images.Add("agregar", Iconos.Agregar(tam));
            imageList1.Images.Add("modificar", Iconos.Modificar(tam));
            imageList1.Images.Add("eliminar", Iconos.Eliminar(tam));
            imageList1.Images.Add("limpiar", Iconos.Limpiar(tam));
            imageList1.Images.Add("salir", Iconos.Salir(tam));

            // Vinculamos cada botón con su imagen a través del ImageIndex
            Button[] botones = { btn_agregar, btn_modificar, btn_eliminar, btn_limpiar, btn_salir };
            for (int i = 0; i < botones.Length; i++)
            {
                botones[i].ImageList = imageList1;
                botones[i].ImageIndex = i;
            }

            pb_titulo.Image = Iconos.Bolsa(LogicalToDeviceUnits(42));
            pb_buscar.Image = Iconos.Buscar(LogicalToDeviceUnits(34));
        }

        private void ConfigurarTabla()
        {
            precio.DefaultCellStyle.Format = "N2";
            precio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            folio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Sin esto, las filas sin imagen muestran el ícono de "imagen rota"
            imagen.DefaultCellStyle.NullValue = null;
            imagen.DefaultCellStyle.Padding = new Padding(2);
        }

        private void pb_imagen_Paint(object? sender, PaintEventArgs e)
        {
            // Marco interior del recuadro
            Rectangle interior = Rectangle.Inflate(pb_imagen.ClientRectangle, -3, -3);
            using (var lapiz = new Pen(Color.FromArgb(110, 110, 110)))
            {
                e.Graphics.DrawRectangle(lapiz, interior);
            }

            // Si no hay imagen se dibuja el ícono de "agregar imagen"
            if (pb_imagen.Image == null)
            {
                Rectangle area = pb_imagen.ClientRectangle;
                float lado = Math.Min(area.Width, area.Height) * 0.82f;
                var destino = new RectangleF(
                    area.X + (area.Width - lado) / 2f,
                    area.Y + (area.Height - lado) / 2f + lado * 0.04f,
                    lado,
                    lado);
                Iconos.DibujarMarcadorImagen(e.Graphics, destino);
            }
        }

        #endregion

        #region Cargar y buscar

        private void cargarProductos(string filtro = "")
        {
            LimpiarRejilla();
            listaProductos = Conexion.GetProductos(filtro);

            // Recorrido de la Lista de Productos
            foreach (var prod in listaProductos)
            {
                Image? img = BytesAImagenParaRejilla(prod.Imagen);
                dgv_productos.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img);
            }

            dgv_productos.ClearSelection();
        }

        // Libera las imágenes de la rejilla antes de volver a llenarla.
        // Al buscar se recarga en cada tecla, y sin esto se acumulan bitmaps en memoria.
        private void LimpiarRejilla()
        {
            var imagenes = new List<Image>();
            foreach (DataGridViewRow fila in dgv_productos.Rows)
            {
                if (fila.Cells[imagen.Index].Value is Image img)
                {
                    imagenes.Add(img);
                }
            }

            dgv_productos.Rows.Clear();
            dgv_productos.Refresh();

            foreach (Image img in imagenes)
            {
                img.Dispose();
            }
        }

        private static Image? BytesAImagenParaRejilla(byte[]? bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                using (Bitmap bmp = new Bitmap(ms))
                {
                    return new Bitmap(bmp); // Esto clona la imagen y evita que falle al cerrar el MemoryStream
                }
            }
            catch (ArgumentException)
            {
                return null; // bytes que no son una imagen válida
            }
        }

        private void txt_busqueda_TextChanged(object sender, EventArgs e)
        {
            cargarProductos(txt_busqueda.Text.Trim());
        }

        private void pb_buscar_Click(object sender, EventArgs e)
        {
            cargarProductos(txt_busqueda.Text.Trim());
            txt_busqueda.Focus();
        }

        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // clic en el encabezado

            int id = Convert.ToInt32(dgv_productos.Rows[e.RowIndex].Cells[folio.Index].Value);
            Producto? prod = listaProductos.Find(p => p.Id == id);
            if (prod != null)
            {
                MostrarProducto(prod);
            }
        }

        private void MostrarProducto(Producto prod)
        {
            folioSeleccionado = prod.Id;
            txt_folio.Text = prod.Id.ToString();
            txt_nombre.Text = prod.Nombre;
            txt_precio.Text = prod.Precio.ToString("0.00");
            txt_cantidad.Text = prod.Cantidad.ToString();

            try
            {
                EstablecerImagen(ImagenDesdeBytes(prod.Imagen));
            }
            catch (ArgumentException)
            {
                EstablecerImagen(null); // la imagen guardada está dañada
            }
        }

        #endregion

        #region Imagen del producto

        private void pb_imagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var info = new FileInfo(openFileDialog.FileName);
                    if (info.Length > Validaciones.TamanoMaximoImagen)
                    {
                        MessageBox.Show("La imagen no puede pesar más de 5 MB.", "Imagen demasiado grande",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Se lee a memoria en vez de Image.FromFile para no dejar el archivo bloqueado
                    byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);
                    EstablecerImagen(ImagenDesdeBytes(bytes));
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or ArgumentException)
                {
                    MessageBox.Show("No se pudo abrir la imagen seleccionada.\n\n" + ex.Message, "Imagen",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Crea la imagen conservando su formato original (RawFormat: JPEG, PNG, BMP...).
        // El MemoryStream no se cierra a propósito: GDI+ lo necesita abierto mientras viva la imagen.
        private static Image? ImagenDesdeBytes(byte[]? bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            return Image.FromStream(new MemoryStream(bytes));
        }

        private void EstablecerImagen(Image? nueva)
        {
            Image? anterior = pb_imagen.Image;
            pb_imagen.Image = nueva;
            anterior?.Dispose();
            pb_imagen.Invalidate();
        }

        private static byte[]? ImageToByteArray(Image? image)
        {
            if (image == null)
                return null;

            // Guardamos la imagen usando su formato original (RawFormat).
            // Un Bitmap creado en memoria (MemoryBmp) no tiene codificador, así que se guarda como PNG.
            ImageFormat formato = image.RawFormat;
            bool tieneCodificador = ImageCodecInfo.GetImageEncoders().Any(c => c.FormatID == formato.Guid);
            if (!tieneCodificador)
            {
                formato = ImageFormat.Png;
            }

            using (MemoryStream mMemoryStream = new MemoryStream())
            {
                image.Save(mMemoryStream, formato);
                return mMemoryStream.ToArray();
            }
        }

        #endregion

        #region Botones CRUD

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (!datosCorrectos())
            {
                return; // No vamos a hacer nada; se detiene en este punto
            }

            if (folioSeleccionado != null)
            {
                var respuesta = MessageBox.Show(
                    $"Tiene seleccionado el folio {folioSeleccionado}.\n¿Desea agregar estos datos como un producto NUEVO?\n\n(Para cambiar el existente use Modificar)",
                    "Agregar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta != DialogResult.Yes) return;
            }

            CargarDatosProductos();

            if (Conexion.InsertSeguro(Tabla, myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro", "Agregar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                // Refrescamos el grid volviendo a consultar la base de datos
                cargarProductos(txt_busqueda.Text.Trim());
            }
            else
            {
                MostrarError("No se pudo guardar el registro.");
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (folioSeleccionado == null)
            {
                MessageBox.Show("Seleccione en la tabla el producto que desea modificar.", "Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!datosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            if (Conexion.UpdateSeguro(Tabla, myProducto, folioSeleccionado.Value))
            {
                MessageBox.Show("Se ha modificado satisfactoriamente el registro", "Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                cargarProductos(txt_busqueda.Text.Trim());
            }
            else if (string.IsNullOrEmpty(Conexion.UltimoError))
            {
                MessageBox.Show("El producto ya no existe en la base de datos.", "Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarFormulario();
                cargarProductos(txt_busqueda.Text.Trim());
            }
            else
            {
                MostrarError("No se pudo modificar el registro.");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (folioSeleccionado == null)
            {
                MessageBox.Show("Seleccione en la tabla el producto que desea eliminar.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar el producto \"{txt_nombre.Text.Trim()}\" (folio {folioSeleccionado})?\nEsta acción no se puede deshacer.",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (confirmacion != DialogResult.Yes) return;

            if (Conexion.DeleteSeguro(Tabla, folioSeleccionado.Value))
            {
                MessageBox.Show("Se ha eliminado el registro", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!string.IsNullOrEmpty(Conexion.UltimoError))
            {
                MostrarError("No se pudo eliminar el registro.");
                return;
            }

            LimpiarFormulario();
            cargarProductos(txt_busqueda.Text.Trim());
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            if (txt_busqueda.Text.Length > 0)
            {
                txt_busqueda.Clear(); // dispara TextChanged y recarga todos los productos
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Validación y armado de datos

        private bool datosCorrectos()
        {
            string? error = Validaciones.ValidarNombre(txt_nombre.Text.Trim());
            if (error != null) return Rechazar(error, txt_nombre);

            error = Validaciones.ValidarPrecio(txt_precio.Text.Trim(), out _);
            if (error != null) return Rechazar(error, txt_precio);

            // Ojo: aquí se valida txt_cantidad (en el PDF hay un error a propósito que valida txt_precio)
            error = Validaciones.ValidarCantidad(txt_cantidad.Text.Trim(), out _);
            if (error != null) return Rechazar(error, txt_cantidad);

            return true;
        }

        private static bool Rechazar(string mensaje, TextBox campo)
        {
            MessageBox.Show(mensaje, "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
            campo.SelectAll();
            return false;
        }

        private void CargarDatosProductos()
        {
            myProducto.Clear();
            myProducto["Nombre"] = txt_nombre.Text.Trim();
            myProducto["Precio"] = decimal.Parse(txt_precio.Text.Trim());
            myProducto["Cantidad"] = int.Parse(txt_cantidad.Text.Trim());
            myProducto["Imagen"] = ImageToByteArray(pb_imagen.Image);
        }

        private void LimpiarFormulario()
        {
            folioSeleccionado = null;
            txt_folio.Clear();
            txt_nombre.Clear();
            txt_precio.Clear();
            txt_cantidad.Clear();
            EstablecerImagen(null);
            dgv_productos.ClearSelection();
            txt_nombre.Focus();
        }

        private static void MostrarError(string mensaje)
        {
            string detalle = string.IsNullOrEmpty(Conexion.UltimoError) ? "" : "\n\nDetalle: " + Conexion.UltimoError;
            MessageBox.Show(mensaje + detalle, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
