using System.ComponentModel;
using TransBitmap.Services;

namespace TransBitmap.Models
{
    public enum ColorSpace
    {
        Red, Green, Blue
    }

    public record BitmapConverterSetting
    {
        public ColorSpace FromRed { get; init; } = ColorSpace.Red;

        public bool ReverseRed { get; init; } = false;

        public ColorSpace FromGreen { get; init; } = ColorSpace.Green;

        public bool ReverseGreen { get; init; } = false;

        public ColorSpace FromBlue { get; init; } = ColorSpace.Blue;

        public bool ReverseBlue { get; init; } = false;

        public ConvertColor ConvertStrategy =>
            (red, green, blue) => (ConvertColor(red, green, blue, FromRed, ReverseRed),
                                   ConvertColor(red, green, blue, FromGreen, ReverseGreen),
                                   ConvertColor(red, green, blue, FromBlue, ReverseBlue));

        private static byte ConvertColor(byte red, byte green, byte blue, ColorSpace fromColor, bool reverse)
        {
            var color = fromColor switch
            {
                ColorSpace.Red => red,
                ColorSpace.Green => green,
                ColorSpace.Blue => blue,
                _ => throw new InvalidEnumArgumentException(nameof(fromColor), (int)fromColor, typeof(ColorSpace))
            };
            return reverse ? (byte)~color : color;
        }
    }
}
