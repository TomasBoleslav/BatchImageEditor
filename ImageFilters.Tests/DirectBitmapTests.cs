using Xunit;
using System;
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

		[Theory]
		[InlineData(PixelFormat.Format24bppRgb)]
		[InlineData(PixelFormat.Format32bppRgb)]
		[InlineData(PixelFormat.Format32bppArgb)]
		public void Constructor_SupportedPixelFormat_CreatesBitmapOfSameFormat(PixelFormat pixelFormat)
		{
			using var directBitmap = new DirectBitmap(1, 1, pixelFormat);
			Assert.Equal(pixelFormat, directBitmap.Bitmap.PixelFormat);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		public void SetPixel_SetsColorOnBitmap(int width, int height, int x, int y, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color expectedColor = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);

			directBitmap.SetPixel(x, y, expectedColor);
			Color actualColor = directBitmap.Bitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		public void GetPixel_AfterSetPixel_ReturnsSameColor(int width, int height, int x, int y, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);
			directBitmap.SetPixel(x, y, color);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(color, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		public void GetPixel_AfterBitmapSetPixel_ReturnsSameColor(int width, int height, int x, int y, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);
			directBitmap.Bitmap.SetPixel(x, y, color);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(color, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		public void GetPixel_AfterSetPixel_ReturnsSameColorAsBitmapGetPixel(int width, int height, int x, int y, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);
			directBitmap.SetPixel(x, y, color);
			Color expectedColor = directBitmap.Bitmap.GetPixel(x, y);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30)]
		[InlineData(1, 1, 0, 0, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, PixelFormat.Format32bppArgb, 10, 20, 30, 40)]
		public void GetPixel_AfterBitmapClear_ReturnsSameColorAsBitmapGetPixel(int width, int height, int x, int y, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);
			using (var graphics = Graphics.FromImage(directBitmap.Bitmap))
			{
				graphics.Clear(clearColor);
			}
			Color expectedColor = directBitmap.Bitmap.GetPixel(x, y);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(PixelFormat.Format16bppArgb1555)]
		[InlineData(PixelFormat.Format16bppRgb555)]
		[InlineData(PixelFormat.Format16bppRgb565)]
		[InlineData(PixelFormat.Format32bppPArgb)]
		[InlineData(PixelFormat.Format48bppRgb)]
		[InlineData(PixelFormat.Format64bppArgb)]
		[InlineData(PixelFormat.Format64bppPArgb)]
		[InlineData(PixelFormat.Format1bppIndexed)]
		[InlineData(PixelFormat.Format4bppIndexed)]
		[InlineData(PixelFormat.Format8bppIndexed)]
		public void FromBitmap_PixelFormatNotSupported_ReformatsTo32Argb(PixelFormat pixelFormat)
		{
			PixelFormat expectedFormat = PixelFormat.Format32bppArgb;
			using var bitmap = new Bitmap(1, 1, pixelFormat);
			
			using var directBitmap = DirectBitmap.FromBitmap(bitmap);
			PixelFormat actualFormat = directBitmap.Bitmap.PixelFormat;
			
			Assert.Equal(expectedFormat, actualFormat);
		}

		[Theory]
		[InlineData(PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppRgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppArgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppArgb, 50, 100, 150, 200)]
		public void FromBitmap_PixelFormatSupported_SetsColorFromOriginalBitmap(PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var bitmap = CreateBitmapWithColor(1, 1, pixelFormat, color);
			Color expectedColor = bitmap.GetPixel(0, 0);

			using var directBitmap = DirectBitmap.FromBitmap(bitmap);
			Color actualColor = directBitmap.GetPixel(0, 0);

			Assert.Equal(expectedColor, actualColor);

		}

		private static Bitmap CreateBitmapWithColor(int width, int height, PixelFormat pixelFormat, Color color)
		{
			var bitmap = new Bitmap(width, height, pixelFormat);
			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(color);
			}
			return bitmap;
		}
	}
}
