using System.Drawing.Drawing2D;

namespace Practica14_9_2026
{
    /// <summary>
    /// Íconos del formulario dibujados con GDI+ (no dependen de archivos externos).
    /// Se cargan en el ImageList del formulario y los botones los toman por ImageIndex.
    /// Si prefieres usar tus propios PNG, agrégalos al imageList1 desde el diseñador
    /// y quita la llamada a ConfigurarIconos().
    /// </summary>
    internal static class Iconos
    {
        // Todos los íconos se dibujan en una cuadrícula de 24x24 y se escalan al tamaño pedido
        private static Bitmap Crear(int tam, Action<Graphics> dibujar)
        {
            var bmp = new Bitmap(tam, tam);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.ScaleTransform(tam / 24f, tam / 24f);
                dibujar(g);
            }
            return bmp;
        }

        private static Pen LapizRedondo(Color color, float ancho)
        {
            return new Pen(color, ancho) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        }

        public static Bitmap Agregar(int tam) => Crear(tam, g =>
        {
            using var fondo = new SolidBrush(Color.FromArgb(67, 160, 71));
            using var cruz = LapizRedondo(Color.White, 3f);
            g.FillEllipse(fondo, 1, 1, 22, 22);
            g.DrawLine(cruz, 12, 6.5f, 12, 17.5f);
            g.DrawLine(cruz, 6.5f, 12, 17.5f, 12);
        });

        public static Bitmap Modificar(int tam) => Crear(tam, g =>
        {
            using var goma = new SolidBrush(Color.FromArgb(239, 83, 80));
            using var metal = new SolidBrush(Color.FromArgb(176, 190, 197));
            using var cuerpo = new SolidBrush(Color.FromArgb(255, 179, 0));
            using var madera = new SolidBrush(Color.FromArgb(255, 224, 178));
            using var mina = new SolidBrush(Color.FromArgb(66, 66, 66));

            // Lápiz vertical girado 45° (la punta queda abajo a la izquierda)
            g.TranslateTransform(12, 12);
            g.RotateTransform(45);
            g.FillRectangle(goma, -3, -11, 6, 3);
            g.FillRectangle(metal, -3, -8, 6, 1.5f);
            g.FillRectangle(cuerpo, -3, -6.5f, 6, 11.5f);
            g.FillPolygon(madera, new PointF[] { new(-3, 5), new(3, 5), new(0, 10.5f) });
            g.FillPolygon(mina, new PointF[] { new(-1.1f, 8.5f), new(1.1f, 8.5f), new(0, 10.5f) });
        });

        public static Bitmap Eliminar(int tam) => Crear(tam, g =>
        {
            using var rojo = new SolidBrush(Color.FromArgb(229, 57, 53));
            using var ranura = new Pen(Color.White, 1.5f);
            g.FillRectangle(rojo, 9, 2, 6, 2.5f);   // asa
            g.FillRectangle(rojo, 4, 4.5f, 16, 3);  // tapa
            g.FillPolygon(rojo, new PointF[] { new(5.5f, 9), new(18.5f, 9), new(17, 22), new(7, 22) });
            g.DrawLine(ranura, 10, 11.5f, 10, 19.5f);
            g.DrawLine(ranura, 14, 11.5f, 14, 19.5f);
        });

        public static Bitmap Limpiar(int tam) => Crear(tam, g =>
        {
            using var palo = LapizRedondo(Color.FromArgb(121, 85, 72), 2.5f);
            using var amarre = new SolidBrush(Color.FromArgb(30, 136, 229));
            using var cerdas = new SolidBrush(Color.FromArgb(253, 216, 53));
            using var brillo = LapizRedondo(Color.FromArgb(255, 241, 118), 1.3f);

            g.DrawLine(palo, 3, 3, 12.5f, 12.5f);
            g.DrawLine(brillo, 19, 4, 19, 8);
            g.DrawLine(brillo, 17, 6, 21, 6);

            g.TranslateTransform(14, 14);
            g.RotateTransform(-45);
            g.FillRectangle(amarre, -4, -3, 8, 3);
            g.FillPolygon(cerdas, new PointF[] { new(-4, 0), new(4, 0), new(6, 9), new(-6, 9) });
        });

        public static Bitmap Salir(int tam) => Crear(tam, g =>
        {
            using var fondo = new SolidBrush(Color.FromArgb(229, 57, 53));
            using var simbolo = LapizRedondo(Color.White, 2.4f);
            g.FillEllipse(fondo, 1, 1, 22, 22);
            g.DrawArc(simbolo, 6.5f, 7, 11, 11, -50, 280);
            g.DrawLine(simbolo, 12, 5.5f, 12, 12);
        });

        public static Bitmap Buscar(int tam) => Crear(tam, g =>
        {
            using var mango = LapizRedondo(Color.FromArgb(93, 64, 55), 4f);
            using var vidrio = new SolidBrush(Color.FromArgb(179, 229, 252));
            using var aro = new Pen(Color.FromArgb(120, 144, 156), 2.2f);
            using var brillo = LapizRedondo(Color.White, 1.5f);
            g.DrawLine(mango, 14.5f, 14.5f, 21, 21);
            g.FillEllipse(vidrio, 2, 2, 14, 14);
            g.DrawEllipse(aro, 2, 2, 14, 14);
            g.DrawArc(brillo, 5, 5, 8, 8, 190, 70);
        });

        public static Bitmap Bolsa(int tam) => Crear(tam, g =>
        {
            using var hojas = new SolidBrush(Color.FromArgb(102, 187, 106));
            using var fruta = new SolidBrush(Color.FromArgb(255, 112, 67));
            using var bolsa = new SolidBrush(Color.FromArgb(255, 204, 128));
            using var doblez = new SolidBrush(Color.FromArgb(255, 183, 77));
            g.FillEllipse(hojas, 7, 1, 5, 9);
            g.FillEllipse(hojas, 11, 0, 5, 9);
            g.FillEllipse(fruta, 14, 3, 5, 7);
            g.FillPolygon(bolsa, new PointF[] { new(4, 8), new(20, 8), new(19, 23), new(5, 23) });
            g.FillRectangle(doblez, 4, 8, 16, 3);
        });

        /// <summary>
        /// Dibuja el ícono "agregar imagen" (marco, sol, montañas y +) dentro del rectángulo indicado.
        /// Se usa como marcador cuando el PictureBox no tiene imagen, sin asignarlo a .Image
        /// (así nunca se guarda por error en la base de datos).
        /// </summary>
        public static void DibujarMarcadorImagen(Graphics g, RectangleF area)
        {
            GraphicsState estado = g.Save();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(area.X, area.Y);
            g.ScaleTransform(area.Width / 100f, area.Height / 100f);

            var marco = new RectangleF(2, 8, 80, 70);
            using (var rutaMarco = Redondeado(marco, 12))
            using (var fondo = new SolidBrush(Color.FromArgb(69, 84, 104)))
            using (var sol = new SolidBrush(Color.FromArgb(251, 192, 45)))
            using (var montes = new SolidBrush(Color.FromArgb(38, 166, 154)))
            {
                g.FillPath(fondo, rutaMarco);
                g.FillEllipse(sol, 36, 20, 14, 14);

                GraphicsState recorte = g.Save();
                g.SetClip(rutaMarco, CombineMode.Intersect);
                g.FillPolygon(montes, new PointF[]
                {
                    new(2, 78), new(2, 60), new(26, 38), new(46, 58), new(62, 44), new(82, 62), new(82, 78)
                });
                g.Restore(recorte);
            }

            using (var blanco = new SolidBrush(Color.White))
            using (var cruz = LapizRedondo(Color.FromArgb(0, 137, 123), 7f))
            {
                g.FillEllipse(blanco, 58, 54, 40, 40);
                g.DrawLine(cruz, 78, 63, 78, 85);
                g.DrawLine(cruz, 67, 74, 89, 74);
            }

            g.Restore(estado);
        }

        private static GraphicsPath Redondeado(RectangleF r, float radio)
        {
            float d = radio * 2;
            var ruta = new GraphicsPath();
            ruta.AddArc(r.X, r.Y, d, d, 180, 90);
            ruta.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            ruta.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            ruta.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            ruta.CloseFigure();
            return ruta;
        }
    }
}
