﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TransBitmap.Services
{
    class BitmapLockBitsConverter : IBitmapConverter
    {
        public Bitmap ConvertBitmapColor(Bitmap bitmap, ConvertColor converter)
        {
            var copy = bitmap.Clone() as Bitmap;
            BitmapData data = copy.LockBits(new Rectangle(0, 0, copy.Width, copy.Height),
                                            ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr ptr = data.Scan0;
                byte[] rgbValues = new byte[data.Height * data.Stride];

                Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
                Converters.ConvertBitmapColor(rgbValues, data.Width, data.Height, data.Stride, converter);
                Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
            }
            finally
            {
                copy.UnlockBits(data);
            }

            return copy;
        }
    }
}
