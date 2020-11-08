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

            BitmapData bmpData = trans.LockBits(new Rectangle(0, 0, trans.Width, trans.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                IntPtr ptr = bmpData.Scan0;
                int bytes = bmpData.Height * bmpData.Stride;
                byte[] rgbValues = new byte[bytes];

                Marshal.Copy(ptr, rgbValues, 0, bytes);

                for (int y = 0, index0 = 0; y < bmpData.Height; y++, index0 += bmpData.Stride)
                {
                    for (int x = 0; x < bmpData.Width; x++)
                    {
                        int index = index0 + x * 3;

                        (byte red, byte green, byte blue) = ConvertStrategy(rgbValues[index + 2], rgbValues[index + 1], rgbValues[index]);

                        rgbValues[index] = blue;
                        rgbValues[index + 1] = green;
                        rgbValues[index + 2] = red;
                    }
                }

                Marshal.Copy(rgbValues, 0, ptr, bytes);
            }
            finally
            {
                trans.UnlockBits(bmpData);
            }

            return trans;
        }

        public Bitmap ConvertBitmapWithUnsafe(Bitmap org)
        {
            Bitmap trans = (Bitmap)org.Clone();

            BitmapData bmpData = trans.LockBits(new Rectangle(0, 0, trans.Width, trans.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                unsafe
                {
                    byte* ptr = (byte*)bmpData.Scan0;

                    for (int y = 0, index0 = 0; y < bmpData.Height; y++, index0 += bmpData.Stride)
                    {
                        for (int x = 0; x < bmpData.Width; x++)
                        {
                            int index = index0 + x * 3;

                            (byte red, byte green, byte blue) = ConvertStrategy(ptr[index + 2], ptr[index + 1], ptr[index]);

                            ptr[index] = blue;
                            ptr[index + 1] = green;
                            ptr[index + 2] = red;
                        }
                    }
                }
            }
            finally
            {
                trans.UnlockBits(bmpData);
            }

            return trans;
        }
    }
}
