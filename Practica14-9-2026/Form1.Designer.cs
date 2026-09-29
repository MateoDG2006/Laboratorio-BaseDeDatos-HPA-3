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
            button1 = new Button();
            lbl_folio = new Label();
            dgv_productos = new DataGridView();
            folio = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            imagenes = new DataGridViewImageColumn();
            label1 = new Label();
            txt_nombre = new TextBox();
            lbl_precio = new Label();
            txt_precio = new TextBox();
            lbl_cantidad = new Label();
            txt_cantidad = new TextBox();
            imageList1 = new ImageList(components);
            pb_imagenes = new PictureBox();
            label2 = new Label();
            txt_folio = new TextBox();
            btn_limpiar = new Button();
            btn_eliminar = new Button();
            btn_modificar = new Button();
            btn_guardar = new Button();
            btn_cargar_imagen = new Button();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgv_productos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_imagenes).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(411, 190);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // lbl_folio
            // 
            lbl_folio.AutoSize = true;
            lbl_folio.Location = new Point(21, 24);
            lbl_folio.Name = "lbl_folio";
            lbl_folio.Size = new Size(51, 25);
            lbl_folio.TabIndex = 2;
            lbl_folio.Text = "Folio";
            // 
            // dgv_productos
            // 
            dgv_productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_productos.Columns.AddRange(new DataGridViewColumn[] { folio, nombre, precio, cantidad, imagenes });
            dgv_productos.Location = new Point(21, 415);
            dgv_productos.Name = "dgv_productos";
            dgv_productos.RowHeadersWidth = 62;
            dgv_productos.Size = new Size(1025, 225);
            dgv_productos.TabIndex = 3;
            // 
            // folio
            // 
            folio.HeaderText = "Folio";
            folio.MinimumWidth = 8;
            folio.Name = "folio";
            folio.Width = 150;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.MinimumWidth = 8;
            nombre.Name = "nombre";
            nombre.Width = 150;
            // 
            // precio
            // 
            precio.HeaderText = "Precio";
            precio.MinimumWidth = 8;
            precio.Name = "precio";
            precio.Width = 150;
            // 
            // cantidad
            // 
            cantidad.HeaderText = "Cantidad";
            cantidad.MinimumWidth = 8;
            cantidad.Name = "cantidad";
            cantidad.Width = 150;
            // 
            // imagenes
            // 
            imagenes.HeaderText = "Imagenes";
            imagenes.MinimumWidth = 8;
            imagenes.Name = "imagenes";
            imagenes.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 118);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 5;
            label1.Text = "Nombre";
            // 
            // txt_nombre
            // 
            txt_nombre.Location = new Point(21, 159);
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(150, 31);
            txt_nombre.TabIndex = 4;
            // 
            // lbl_precio
            // 
            lbl_precio.AutoSize = true;
            lbl_precio.Location = new Point(21, 219);
            lbl_precio.Name = "lbl_precio";
            lbl_precio.Size = new Size(60, 25);
            lbl_precio.TabIndex = 7;
            lbl_precio.Text = "Precio";
            // 
            // txt_precio
            // 
            txt_precio.Location = new Point(21, 260);
            txt_precio.Name = "txt_precio";
            txt_precio.Size = new Size(150, 31);
            txt_precio.TabIndex = 6;
            // 
            // lbl_cantidad
            // 
            lbl_cantidad.AutoSize = true;
            lbl_cantidad.Location = new Point(21, 321);
            lbl_cantidad.Name = "lbl_cantidad";
            lbl_cantidad.Size = new Size(83, 25);
            lbl_cantidad.TabIndex = 9;
            lbl_cantidad.Text = "Cantidad";
            // 
            // txt_cantidad
            // 
            txt_cantidad.Location = new Point(21, 362);
            txt_cantidad.Name = "txt_cantidad";
            txt_cantidad.Size = new Size(150, 31);
            txt_cantidad.TabIndex = 8;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pb_imagenes
            // 
            pb_imagenes.Location = new Point(194, 65);
            pb_imagenes.Name = "pb_imagenes";
            pb_imagenes.Size = new Size(371, 262);
            pb_imagenes.TabIndex = 10;
            pb_imagenes.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 24);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 11;
            label2.Text = "Imagen";
            // 
            // txt_folio
            // 
            txt_folio.Location = new Point(21, 65);
            txt_folio.Name = "txt_folio";
            txt_folio.Size = new Size(150, 31);
            txt_folio.TabIndex = 12;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(591, 286);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(194, 41);
            btn_limpiar.TabIndex = 13;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            // 
            // btn_eliminar
            // 
            btn_eliminar.Location = new Point(591, 213);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(194, 41);
            btn_eliminar.TabIndex = 14;
            btn_eliminar.Text = "Eliminar";
            btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            btn_modificar.Location = new Point(591, 133);
            btn_modificar.Name = "btn_modificar";
            btn_modificar.Size = new Size(194, 41);
            btn_modificar.TabIndex = 15;
            btn_modificar.Text = "Modificar";
            btn_modificar.UseVisualStyleBackColor = true;
            btn_modificar.Click += btn_modificar_Click;
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(591, 65);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(194, 41);
            btn_guardar.TabIndex = 16;
            btn_guardar.Text = "Guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // btn_cargar_imagen
            // 
            btn_cargar_imagen.Location = new Point(371, 342);
            btn_cargar_imagen.Name = "btn_cargar_imagen";
            btn_cargar_imagen.Size = new Size(194, 41);
            btn_cargar_imagen.TabIndex = 17;
            btn_cargar_imagen.Text = "Cargar Imagen";
            btn_cargar_imagen.UseVisualStyleBackColor = true;
            btn_cargar_imagen.Click += btn_cargar_imagen_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 652);
            Controls.Add(btn_cargar_imagen);
            Controls.Add(btn_guardar);
            Controls.Add(btn_modificar);
            Controls.Add(btn_eliminar);
            Controls.Add(btn_limpiar);
            Controls.Add(txt_folio);
            Controls.Add(label2);
            Controls.Add(pb_imagenes);
            Controls.Add(lbl_cantidad);
            Controls.Add(txt_cantidad);
            Controls.Add(lbl_precio);
            Controls.Add(txt_precio);
            Controls.Add(label1);
            Controls.Add(txt_nombre);
            Controls.Add(dgv_productos);
            Controls.Add(lbl_folio);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_productos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_imagenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Label lbl_folio;
        private DataGridView dgv_productos;
        private DataGridViewTextBoxColumn folio;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewImageColumn imagenes;
        private Label label1;
        private TextBox txt_nombre;
        private Label lbl_precio;
        private TextBox txt_precio;
        private Label lbl_cantidad;
        private TextBox txt_cantidad;
        private ImageList imageList1;
        private PictureBox pb_imagenes;
        private Label label2;
        private TextBox txt_folio;
        private Button btn_limpiar;
        private Button btn_eliminar;
        private Button btn_modificar;
        private Button btn_guardar;
        private Button btn_cargar_imagen;
        private OpenFileDialog openFileDialog1;
    }
}
