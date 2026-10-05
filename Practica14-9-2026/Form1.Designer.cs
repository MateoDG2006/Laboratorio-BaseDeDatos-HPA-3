namespace Practica14_9_2026
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnl_encabezado = new Panel();
            pb_titulo = new PictureBox();
            lbl_titulo = new Label();
            lbl_folio = new Label();
            txt_folio = new TextBox();
            lbl_nombre = new Label();
            txt_nombre = new TextBox();
            lbl_precio = new Label();
            txt_precio = new TextBox();
            lbl_cantidad = new Label();
            txt_cantidad = new TextBox();
            lbl_imagen = new Label();
            pb_imagen = new PictureBox();
            pnl_busqueda = new Panel();
            pb_buscar = new PictureBox();
            txt_busqueda = new TextBox();
            lbl_busqueda = new Label();
            dgv_productos = new DataGridView();
            folio = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            imagen = new DataGridViewImageColumn();
            btn_agregar = new Button();
            btn_modificar = new Button();
            btn_eliminar = new Button();
            btn_limpiar = new Button();
            btn_salir = new Button();
            imageList1 = new ImageList(components);
            toolTip1 = new ToolTip(components);
            pnl_encabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_titulo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_imagen).BeginInit();
            pnl_busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_buscar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_productos).BeginInit();
            SuspendLayout();
            //
            // pnl_encabezado
            //
            pnl_encabezado.BackColor = Color.FromArgb(0, 114, 206);
            pnl_encabezado.Controls.Add(pb_titulo);
            pnl_encabezado.Controls.Add(lbl_titulo);
            pnl_encabezado.Dock = DockStyle.Top;
            pnl_encabezado.Location = new Point(0, 0);
            pnl_encabezado.Name = "pnl_encabezado";
            pnl_encabezado.Size = new Size(600, 64);
            pnl_encabezado.TabIndex = 0;
            //
            // pb_titulo
            //
            pb_titulo.Location = new Point(330, 11);
            pb_titulo.Name = "pb_titulo";
            pb_titulo.Size = new Size(42, 42);
            pb_titulo.SizeMode = PictureBoxSizeMode.Zoom;
            pb_titulo.TabIndex = 1;
            pb_titulo.TabStop = false;
            //
            // lbl_titulo
            //
            lbl_titulo.AutoSize = true;
            lbl_titulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl_titulo.ForeColor = Color.White;
            lbl_titulo.Location = new Point(80, 14);
            lbl_titulo.Name = "lbl_titulo";
            lbl_titulo.Size = new Size(229, 32);
            lbl_titulo.TabIndex = 0;
            lbl_titulo.Text = "CRUD de productos";
            //
            // lbl_folio
            //
            lbl_folio.AutoSize = true;
            lbl_folio.BackColor = Color.Transparent;
            lbl_folio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbl_folio.ForeColor = Color.White;
            lbl_folio.Location = new Point(36, 88);
            lbl_folio.Name = "lbl_folio";
            lbl_folio.Size = new Size(48, 20);
            lbl_folio.TabIndex = 1;
            lbl_folio.Text = "Folio:";
            //
            // txt_folio
            //
            txt_folio.BackColor = Color.White;
            txt_folio.BorderStyle = BorderStyle.FixedSingle;
            txt_folio.Font = new Font("Segoe UI", 10F);
            txt_folio.Location = new Point(132, 86);
            txt_folio.Name = "txt_folio";
            txt_folio.ReadOnly = true;
            txt_folio.Size = new Size(180, 25);
            txt_folio.TabIndex = 2;
            txt_folio.TabStop = false;
            toolTip1.SetToolTip(txt_folio, "El folio lo asigna la base de datos. Seleccione un producto de la tabla para verlo.");
            //
            // lbl_nombre
            //
            lbl_nombre.AutoSize = true;
            lbl_nombre.BackColor = Color.Transparent;
            lbl_nombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbl_nombre.ForeColor = Color.White;
            lbl_nombre.Location = new Point(36, 126);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(69, 20);
            lbl_nombre.TabIndex = 3;
            lbl_nombre.Text = "Nombre:";
            //
            // txt_nombre
            //
            txt_nombre.BorderStyle = BorderStyle.FixedSingle;
            txt_nombre.Font = new Font("Segoe UI", 10F);
            txt_nombre.Location = new Point(132, 124);
            txt_nombre.MaxLength = 100;
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(180, 25);
            txt_nombre.TabIndex = 4;
            //
            // lbl_precio
            //
            lbl_precio.AutoSize = true;
            lbl_precio.BackColor = Color.Transparent;
            lbl_precio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbl_precio.ForeColor = Color.White;
            lbl_precio.Location = new Point(36, 164);
            lbl_precio.Name = "lbl_precio";
            lbl_precio.Size = new Size(55, 20);
            lbl_precio.TabIndex = 5;
            lbl_precio.Text = "Precio:";
            //
            // txt_precio
            //
            txt_precio.BorderStyle = BorderStyle.FixedSingle;
            txt_precio.Font = new Font("Segoe UI", 10F);
            txt_precio.Location = new Point(132, 162);
            txt_precio.Name = "txt_precio";
            txt_precio.Size = new Size(180, 25);
            txt_precio.TabIndex = 6;
            //
            // lbl_cantidad
            //
            lbl_cantidad.AutoSize = true;
            lbl_cantidad.BackColor = Color.Transparent;
            lbl_cantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbl_cantidad.ForeColor = Color.White;
            lbl_cantidad.Location = new Point(36, 202);
            lbl_cantidad.Name = "lbl_cantidad";
            lbl_cantidad.Size = new Size(75, 20);
            lbl_cantidad.TabIndex = 7;
            lbl_cantidad.Text = "Cantidad:";
            //
            // txt_cantidad
            //
            txt_cantidad.BorderStyle = BorderStyle.FixedSingle;
            txt_cantidad.Font = new Font("Segoe UI", 10F);
            txt_cantidad.Location = new Point(132, 200);
            txt_cantidad.Name = "txt_cantidad";
            txt_cantidad.Size = new Size(180, 25);
            txt_cantidad.TabIndex = 8;
            //
            // lbl_imagen
            //
            lbl_imagen.AutoSize = true;
            lbl_imagen.BackColor = Color.Transparent;
            lbl_imagen.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lbl_imagen.ForeColor = Color.White;
            lbl_imagen.Location = new Point(340, 88);
            lbl_imagen.Name = "lbl_imagen";
            lbl_imagen.Size = new Size(66, 20);
            lbl_imagen.TabIndex = 9;
            lbl_imagen.Text = "Imagen:";
            //
            // pb_imagen
            //
            pb_imagen.BackColor = Color.FromArgb(158, 158, 158);
            pb_imagen.BorderStyle = BorderStyle.FixedSingle;
            pb_imagen.Cursor = Cursors.Hand;
            pb_imagen.Location = new Point(424, 82);
            pb_imagen.Name = "pb_imagen";
            pb_imagen.Padding = new Padding(7);
            pb_imagen.Size = new Size(152, 144);
            pb_imagen.SizeMode = PictureBoxSizeMode.Zoom;
            pb_imagen.TabIndex = 10;
            pb_imagen.TabStop = false;
            toolTip1.SetToolTip(pb_imagen, "Clic para seleccionar la imagen del producto");
            pb_imagen.Click += pb_imagen_Click;
            pb_imagen.Paint += pb_imagen_Paint;
            //
            // pnl_busqueda
            //
            pnl_busqueda.BackColor = Color.FromArgb(0, 114, 206);
            pnl_busqueda.Controls.Add(pb_buscar);
            pnl_busqueda.Controls.Add(txt_busqueda);
            pnl_busqueda.Controls.Add(lbl_busqueda);
            pnl_busqueda.Location = new Point(24, 240);
            pnl_busqueda.Name = "pnl_busqueda";
            pnl_busqueda.Size = new Size(552, 52);
            pnl_busqueda.TabIndex = 11;
            //
            // pb_buscar
            //
            pb_buscar.Cursor = Cursors.Hand;
            pb_buscar.Location = new Point(418, 9);
            pb_buscar.Name = "pb_buscar";
            pb_buscar.Size = new Size(34, 34);
            pb_buscar.SizeMode = PictureBoxSizeMode.Zoom;
            pb_buscar.TabIndex = 2;
            pb_buscar.TabStop = false;
            toolTip1.SetToolTip(pb_buscar, "Buscar por folio, nombre, precio o cantidad");
            pb_buscar.Click += pb_buscar_Click;
            //
            // txt_busqueda
            //
            txt_busqueda.BorderStyle = BorderStyle.FixedSingle;
            txt_busqueda.Font = new Font("Segoe UI", 10F);
            txt_busqueda.Location = new Point(112, 13);
            txt_busqueda.Name = "txt_busqueda";
            txt_busqueda.Size = new Size(296, 25);
            txt_busqueda.TabIndex = 1;
            txt_busqueda.TextChanged += txt_busqueda_TextChanged;
            //
            // lbl_busqueda
            //
            lbl_busqueda.AutoSize = true;
            lbl_busqueda.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl_busqueda.ForeColor = Color.White;
            lbl_busqueda.Location = new Point(14, 14);
            lbl_busqueda.Name = "lbl_busqueda";
            lbl_busqueda.Size = new Size(85, 21);
            lbl_busqueda.TabIndex = 0;
            lbl_busqueda.Text = "Búsqueda:";
            //
            // dgv_productos
            //
            dgv_productos.AllowUserToAddRows = false;
            dgv_productos.AllowUserToDeleteRows = false;
            dgv_productos.AllowUserToResizeRows = false;
            dgv_productos.BackgroundColor = Color.FromArgb(171, 171, 171);
            dgv_productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_productos.Columns.AddRange(new DataGridViewColumn[] { folio, nombre, precio, cantidad, imagen });
            dgv_productos.Location = new Point(24, 304);
            dgv_productos.MultiSelect = false;
            dgv_productos.Name = "dgv_productos";
            dgv_productos.ReadOnly = true;
            dgv_productos.RowHeadersWidth = 30;
            dgv_productos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_productos.RowTemplate.Height = 60;
            dgv_productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_productos.Size = new Size(552, 212);
            dgv_productos.TabIndex = 12;
            dgv_productos.CellClick += dgv_productos_CellClick;
            //
            // folio
            //
            folio.HeaderText = "Folio";
            folio.Name = "folio";
            folio.ReadOnly = true;
            folio.Width = 55;
            //
            // nombre
            //
            nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            nombre.ReadOnly = true;
            //
            // precio
            //
            precio.HeaderText = "Precio";
            precio.Name = "precio";
            precio.ReadOnly = true;
            precio.Width = 90;
            //
            // cantidad
            //
            cantidad.HeaderText = "Cantidad";
            cantidad.Name = "cantidad";
            cantidad.ReadOnly = true;
            cantidad.Width = 75;
            //
            // imagen
            //
            imagen.HeaderText = "Imagen";
            imagen.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imagen.Name = "imagen";
            imagen.ReadOnly = true;
            imagen.Width = 125;
            //
            // btn_agregar
            //
            btn_agregar.Font = new Font("Segoe UI", 9.75F);
            btn_agregar.Location = new Point(24, 528);
            btn_agregar.Name = "btn_agregar";
            btn_agregar.Size = new Size(104, 42);
            btn_agregar.TabIndex = 13;
            btn_agregar.Text = "Agregar";
            btn_agregar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_agregar.UseVisualStyleBackColor = true;
            btn_agregar.Click += btn_agregar_Click;
            //
            // btn_modificar
            //
            btn_modificar.Font = new Font("Segoe UI", 9.75F);
            btn_modificar.Location = new Point(136, 528);
            btn_modificar.Name = "btn_modificar";
            btn_modificar.Size = new Size(104, 42);
            btn_modificar.TabIndex = 14;
            btn_modificar.Text = "Modificar";
            btn_modificar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_modificar.UseVisualStyleBackColor = true;
            btn_modificar.Click += btn_modificar_Click;
            //
            // btn_eliminar
            //
            btn_eliminar.Font = new Font("Segoe UI", 9.75F);
            btn_eliminar.Location = new Point(248, 528);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(104, 42);
            btn_eliminar.TabIndex = 15;
            btn_eliminar.Text = "Eliminar";
            btn_eliminar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_eliminar.UseVisualStyleBackColor = true;
            btn_eliminar.Click += btn_eliminar_Click;
            //
            // btn_limpiar
            //
            btn_limpiar.Font = new Font("Segoe UI", 9.75F);
            btn_limpiar.Location = new Point(360, 528);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(104, 42);
            btn_limpiar.TabIndex = 16;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            //
            // btn_salir
            //
            btn_salir.Font = new Font("Segoe UI", 9.75F);
            btn_salir.Location = new Point(472, 528);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(104, 42);
            btn_salir.TabIndex = 17;
            btn_salir.Text = "Salir";
            btn_salir.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            //
            // imageList1
            //
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(24, 24);
            imageList1.TransparentColor = Color.Transparent;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(155, 183, 215);
            ClientSize = new Size(600, 586);
            Controls.Add(btn_salir);
            Controls.Add(btn_limpiar);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_modificar);
            Controls.Add(btn_agregar);
            Controls.Add(dgv_productos);
            Controls.Add(pnl_busqueda);
            Controls.Add(pb_imagen);
            Controls.Add(lbl_imagen);
            Controls.Add(txt_cantidad);
            Controls.Add(lbl_cantidad);
            Controls.Add(txt_precio);
            Controls.Add(lbl_precio);
            Controls.Add(txt_nombre);
            Controls.Add(lbl_nombre);
            Controls.Add(txt_folio);
            Controls.Add(lbl_folio);
            Controls.Add(pnl_encabezado);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRUD Productos";
            Load += Form1_Load;
            pnl_encabezado.ResumeLayout(false);
            pnl_encabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_titulo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_imagen).EndInit();
            pnl_busqueda.ResumeLayout(false);
            pnl_busqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_buscar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_productos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnl_encabezado;
        private Label lbl_titulo;
        private PictureBox pb_titulo;
        private Label lbl_folio;
        private TextBox txt_folio;
        private Label lbl_nombre;
        private TextBox txt_nombre;
        private Label lbl_precio;
        private TextBox txt_precio;
        private Label lbl_cantidad;
        private TextBox txt_cantidad;
        private Label lbl_imagen;
        private PictureBox pb_imagen;
        private Panel pnl_busqueda;
        private Label lbl_busqueda;
        private TextBox txt_busqueda;
        private PictureBox pb_buscar;
        private DataGridView dgv_productos;
        private DataGridViewTextBoxColumn folio;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewImageColumn imagen;
        private Button btn_agregar;
        private Button btn_modificar;
        private Button btn_eliminar;
        private Button btn_limpiar;
        private Button btn_salir;
        private ImageList imageList1;
        private ToolTip toolTip1;
    }
}
