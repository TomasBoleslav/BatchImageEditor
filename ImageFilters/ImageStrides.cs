using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters
{
	internal static class ImageStrides
	{
		public static int GetStride(PixelFormat pixelFormat)
		{
			if (cachedStrides.TryGetValue(pixelFormat, out int stride))
			{
				return stride;
			}
			stride = ComputeStride(pixelFormat);
			cachedStrides.Add(pixelFormat, stride);
			return stride;
		}

		private static readonly IDictionary<PixelFormat, int> cachedStrides = new Dictionary<PixelFormat, int>();

		private static int ComputeStride(PixelFormat pixelFormat)
		{
			try
			{
				using var bitmap = new Bitmap(1, 1, pixelFormat);
				BitmapData data = bitmap.LockBits(new Rectangle(0, 0, 1, 1), ImageLockMode.ReadOnly, pixelFormat);
				int stride = data.Stride;
				bitmap.UnlockBits(data);
				return stride;
			}
			catch (ArgumentException e)
			{
				throw new ArgumentException("The given pixel format is not valid", e);
			}
		}
	}
}
