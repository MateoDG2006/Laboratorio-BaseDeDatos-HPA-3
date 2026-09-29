using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Practica14_9_2026
{
    internal class Product
    {
        public int id;
        public string name;
        public decimal price;
        public int quantity;
        public Image image;
        public static Image getImage(byte[] image_bytes)
        {
            if (ValidacionImagenes.validateImageBytes(image_bytes))
            {
                using (var stream = new MemoryStream(image_bytes))
                using (var image = Image.FromStream(stream))
                {
                    return new Bitmap(image);
                }
            }
            return null;
        }
        public static byte[] setImage(Image image)
        {
            byte[] imagenBytes;
            if (ValidacionImagenes.validateImage(image))
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    image.Save(
                        stream,
                        System.Drawing.Imaging.ImageFormat.Png);

                    imagenBytes = stream.ToArray();
                }
                return imagenBytes;
            }
            return null;
        }
    }


}
