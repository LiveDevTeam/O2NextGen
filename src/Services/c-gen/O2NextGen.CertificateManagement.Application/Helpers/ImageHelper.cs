using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace O2NextGen.CertificateManagement.Application.Helpers;

public static class ImageHelper
{
    public static void AddedText(string text, Bitmap cert, Graphics graphics, string fontFamily, int sizeFont,
        Brush brush, int y, StringAlignment alignment, StringAlignment lineAlignment)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        var strFont = new Font(fontFamily, sizeFont);


        //SizeF size = graphics.MeasureString(text, strFont);
        using (var sf = new StringFormat
               {
                   Alignment = alignment,
                   LineAlignment = lineAlignment
               })
        {
            graphics.DrawString(text, strFont, brush, cert.Width / 2, y, sf);
        }

        graphics.Flush();
    }

    public static void AddedTextX(string text, Bitmap cert, Graphics graphics, string fontFamily, int sizeFont,
        Brush brush, int y, int x, StringAlignment alignment, StringAlignment lineAlignment)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        var strFont = new Font(fontFamily, sizeFont);


        //SizeF size = graphics.MeasureString(text, strFont);
        using (var sf = new StringFormat
               {
                   Alignment = alignment,
                   LineAlignment = lineAlignment
               })
        {
            graphics.DrawString(text, strFont, brush, x, y, sf);
        }

        graphics.Flush();
    }

    // This method is for converting bitmap into a byte array
    public static byte[] BitmapToBytes(Bitmap img)
    {
        using (var stream = new MemoryStream())
        {
            img.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }

    public static Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
    {
        var imgPhoto = Image.FromFile(stPhotoPath);

        var sourceWidth = imgPhoto.Width;
        var sourceHeight = imgPhoto.Height;

        //Consider vertical pics
        if (sourceWidth < sourceHeight)
        {
            var buff = newWidth;

            newWidth = newHeight;
            newHeight = buff;
        }

        int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
        float nPercent = 0, nPercentW = 0, nPercentH = 0;

        nPercentW = newWidth / (float) sourceWidth;
        nPercentH = newHeight / (float) sourceHeight;
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = Convert.ToInt16((newWidth -
                                     sourceWidth * nPercent) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = Convert.ToInt16((newHeight -
                                     sourceHeight * nPercent) / 2);
        }

        var destWidth = (int) (sourceWidth * nPercent);
        var destHeight = (int) (sourceHeight * nPercent);


        var bmPhoto = new Bitmap(newWidth, newHeight,
            PixelFormat.Format24bppRgb);

        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
            imgPhoto.VerticalResolution);

        var grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.Black);
        grPhoto.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        imgPhoto.Dispose();
        return bmPhoto;
    }
}