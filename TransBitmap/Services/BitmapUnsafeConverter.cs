using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace TransBitmap.Services
{
    class BitmapUnsafeConverter : IBitmapConverter
    {
        public Bitmap ConvertBitmapColor(Bitmap bitmap, ConvertColor converter)
        {
            var copy = bitmap.Clone() as Bitmap;
            BitmapData data = copy.LockBits(new Rectangle(0, 0, copy.Width, copy.Height),
                                            ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            try
            {
                unsafe
                {
                    Converters.ConvertBitmapColor(new Span<byte>((void*)data.Scan0, data.Height * data.Stride),
                                                  data.Height, data.Width, data.Stride, converter);
                }
            }
            finally
            {
                copy.UnlockBits(data);
            }

            return copy;
        }
    }
}
