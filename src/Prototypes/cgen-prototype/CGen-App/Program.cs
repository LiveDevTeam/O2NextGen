using System;
using System.Drawing;
using System.IO;

namespace CGen_App
{
    class ImageHelper
    {
        // This method is for converting bitmap into a byte array
        public static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("========= CGen App! =========");
                var bmp = new Bitmap(1024, 1024);
                using (Graphics g = Graphics.FromImage(bmp)) {
                    g.Clear(Color.Gray); 
                    g.Save();
                }
                var bs = ImageHelper.BitmapToBytes(bmp);
                System.IO.File.WriteAllBytes("canvas.png", bs);

                Console.WriteLine("========= End CGen App! =========");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

