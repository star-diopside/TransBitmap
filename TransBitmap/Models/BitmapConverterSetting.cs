using System;

namespace TransBitmap.Models
{
    public enum ColorSpace
    {
        Red, Green, Blue
    }

    public record BitmapConverterSetting(
        ColorSpace FromRed,
        bool ReverseRed,
        ColorSpace FromGreen,
        bool ReverseGreen,
        ColorSpace FromBlue,
        bool ReverseBlue)
    {
        public Func<byte, byte, byte, (byte red, byte green, byte blue)> GetConvertStrategy()
        {
            return (red, green, blue) => (ConvertColor(red, green, blue, FromRed, ReverseRed),
                                          ConvertColor(red, green, blue, FromGreen, ReverseGreen),
                                          ConvertColor(red, green, blue, FromBlue, ReverseBlue));
        }

        private static byte ConvertColor(byte red, byte green, byte blue, ColorSpace fromColor, bool reverse)
        {
            var color = fromColor switch
            {
                ColorSpace.Red => red,
                ColorSpace.Green => green,
                ColorSpace.Blue => blue,
                _ => throw new ArgumentException("Invalid enum value: " + fromColor, nameof(fromColor))
            };
            return reverse ? (byte)~color : color;
        }
    }
}
