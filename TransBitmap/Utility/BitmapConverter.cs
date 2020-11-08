using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TransBitmap.Utility
{
    public class BitmapConverter
    {
        public Func<byte, byte, byte, (byte red, byte green, byte blue)> ConvertStrategy { get; set; } = (red, green, blue) => (red, green, blue);

        public Bitmap ConvertBitmapWithPixel(Bitmap org)
        {
            Bitmap trans = new Bitmap(org.Width, org.Height, org.PixelFormat);

            for (int x = 0; x < org.Width; x++)
            {
                for (int y = 0; y < org.Height; y++)
                {
                    Color src = org.GetPixel(x, y);
                    (byte red, byte green, byte blue) = ConvertStrategy(src.R, src.G, src.B);
                    trans.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }

            return trans;
        }

        public Bitmap ConvertBitmapWithLockBits(Bitmap org)
        {
            Bitmap trans = (Bitmap)org.Clone();
            BitmapData data = trans.LockBits(new Rectangle(0, 0, trans.Width, trans.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                IntPtr ptr = data.Scan0;
                int bytes = data.Height * data.Stride;
                byte[] rgbValues = new byte[bytes];

                Marshal.Copy(ptr, rgbValues, 0, bytes);
                ConvertBitmap(rgbValues, data.Height, data.Width, data.Stride);
                Marshal.Copy(rgbValues, 0, ptr, bytes);
            }
            finally
            {
                trans.UnlockBits(data);
            }

            return trans;
        }

        public Bitmap ConvertBitmapWithUnsafe(Bitmap org)
        {
            Bitmap trans = (Bitmap)org.Clone();
            BitmapData data = trans.LockBits(new Rectangle(0, 0, trans.Width, trans.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                unsafe
                {
                    ConvertBitmap(new Span<byte>((void*)data.Scan0, data.Height * data.Stride), data.Height, data.Width, data.Stride);
                }
            }
            finally
            {
                trans.UnlockBits(data);
            }

            return trans;
        }

        private void ConvertBitmap(Span<byte> bmp, int height, int width, int stride)
        {
            for (int y = 0, index0 = 0; y < height; y++, index0 += stride)
            {
                for (int x = 0, index = index0; x < width; x++, index += 3)
                {
                    (bmp[index + 2], bmp[index + 1], bmp[index]) = ConvertStrategy(bmp[index + 2], bmp[index + 1], bmp[index]);
                }
            }
        }
    }
}
