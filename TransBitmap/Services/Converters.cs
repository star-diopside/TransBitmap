using System;

namespace TransBitmap.Services
{
    static class Converters
    {
        /// <summary>
        /// ビットマップの色を変換する。
        /// </summary>
        /// <param name="data">ビットマップ内のピクセルデータ</param>
        /// <param name="height">ビットマップの高さ</param>
        /// <param name="width">ビットマップの幅</param>
        /// <param name="stride">ビットマップのストライド幅</param>
        /// <param name="converter">ピクセルごとの色の変換処理</param>
        public static void ConvertBitmapColor(Span<byte> data, int height, int width, int stride, ConvertColor converter)
        {
            for (int y = 0, index0 = 0; y < height; y++, index0 += stride)
            {
                for (int x = 0, index = index0; x < width; x++, index += 3)
                {
                    (data[index + 2], data[index + 1], data[index]) = converter(data[index + 2], data[index + 1], data[index]);
                }
            }
        }
    }
}
