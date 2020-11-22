using System.Drawing;

namespace TransBitmap.Services
{
    class BitmapPixelConverter : IBitmapConverter
    {
        public Bitmap ConvertBitmapColor(Bitmap bitmap, ConvertColor converter)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color src = bitmap.GetPixel(x, y);
                    (byte red, byte green, byte blue) = converter(src.R, src.G, src.B);
                    newBitmap.SetPixel(x, y, Color.FromArgb(src.A, red, green, blue));
                }
            }

            return newBitmap;
        }
    }
}
