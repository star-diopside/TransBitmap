using System.Drawing;

namespace TransBitmap.Services
{
    public delegate (byte red, byte green, byte blue) ConvertColor(byte red, byte green, byte blue);

    public interface IBitmapConverter
    {
        Bitmap ConvertBitmapColor(Bitmap bitmap, ConvertColor converter);
    }
}
