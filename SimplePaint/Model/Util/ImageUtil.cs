using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace SimplePaint
{
    public class ImageUtil
    {
        public static Image ToImage(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            byte[] data = File.ReadAllBytes(filePath);
            return ToImage(data);
        }

        public static Image ToImage(byte[] data)
        {
            if (data == null) return null;

            try
            {
                using (var ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        public static Image CreateImage(int width, int height, Color color)
        {
            var bitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(color);
            }
            return bitmap;
        }

    }
}
