namespace LotusCatering.Services
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public class ImageService
    {
        public static async Task<byte[]> ConvertIFormFileToByteArray(IFormFile file)
        {
            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            return destinationImage;
        }

        public static byte[] AddWaterMark(byte[] imageArr, string rootPath)
        {
            var image = ByteArrayToImage(imageArr);
            rootPath += @"/images/logo.png";
            var logo = Image.FromFile(rootPath);

            int newLogoWidth = (int)Math.Floor((double)image.Width / 2);
            int newLogoHeight = (int)Math.Floor(logo.Height * (double)newLogoWidth / logo.Width);
            logo = ResizeImage(logo, newLogoHeight, newLogoWidth);

            var imageBitmap = new Bitmap(image);
            var logoBitmap = new Bitmap(logo);

            DrawWatermark(
                logoBitmap,
                imageBitmap,
                (image.Width / 2) - (logo.Width / 2),
                (image.Height / 2) - (logo.Height / 2));

            MemoryStream ms = new MemoryStream();
            imageBitmap.Save(ms, ImageFormat.Bmp);
            byte[] bitmapData = ms.ToArray();

            return bitmapData;
        }

        private static void DrawWatermark(Bitmap watermark_bm, Bitmap result_bm, int x, int y)
        {
            const byte ALPHA = 70;

            Color clr;
            for (int py = 0; py < watermark_bm.Height; py++)
            {
                for (int px = 0; px < watermark_bm.Width; px++)
                {
                    clr = watermark_bm.GetPixel(px, py);
                    watermark_bm.SetPixel(px, py, Color.FromArgb(ALPHA, clr.R, clr.G, clr.B));
                }
            }

            watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0));

            using Graphics gr = Graphics.FromImage(result_bm);
            gr.DrawImage(watermark_bm, x, y);
        }

        private static Image ResizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
