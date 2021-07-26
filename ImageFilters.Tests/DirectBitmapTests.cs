using System;
using Xunit;
using ImageFilters;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Tests
{
	public class DirectBitmapTests
	{ 
		[Theory]
		[InlineData(0, 1)]
		[InlineData(-1, 1)]
		[InlineData(1, 0)]
		[InlineData(1, -1)]
		[InlineData(0, 0)]
		[InlineData(-1, -1)]
		public void Constructor_WidthOrHeightNotPositive_ThrowsArgumentException(int width, int height)
		{
			Assert.Throws<ArgumentException>(
				() => new DirectBitmap(width, height, PixelFormat.Format24bppRgb)
				);
		}

		private Bitmap CreateBitmap(int width, int height, PixelFormat pixelFormat, Color color)
		{
			var bitmap = new Bitmap(width, height, pixelFormat);
			using var graphics = Graphics.FromImage(bitmap);
			graphics.Clear(color);
			return bitmap;
		}
	}
}
