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
				() => new DirectBitmap(width, height)
				);
		}

		[Fact]
		public void Constructor_CreatesBitmapWith32ArgbPixelFormat()
		{
			using var directBitmap = new DirectBitmap(1, 1);
			Assert.Equal(PixelFormat.Format32bppArgb, directBitmap.Bitmap.PixelFormat);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, 10, 20, 30, 40)]
		public void SetPixel_SetsColorOnBitmap(int width, int height, int x, int y, byte r, byte g, byte b, byte a = 255)
		{
			Color expectedColor = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height);

			directBitmap.SetPixel(x, y, expectedColor);
			Color actualColor = directBitmap.Bitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, 10, 20, 30, 40)]
		public void GetPixel_AfterSetPixel_ReturnsSetColor(int width, int height, int x, int y, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height);
			directBitmap.SetPixel(x, y, color);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(color, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, 10, 20, 30, 40)]
		public void GetPixel_AfterBitmapSetPixel_ReturnsSameColor(int width, int height, int x, int y, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height);
			directBitmap.Bitmap.SetPixel(x, y, color);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(color, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, 10, 20, 30, 40)]
		public void GetPixel_AfterSetPixel_ReturnsSameColorAsBitmapGetPixel(int width, int height, int x, int y, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height);
			directBitmap.SetPixel(x, y, color);
			Color expectedColor = directBitmap.Bitmap.GetPixel(x, y);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(1, 1, 0, 0, 10, 20, 30, 40)]
		[InlineData(5, 5, 1, 1, 10, 20, 30, 40)]
		[InlineData(5, 5, 2, 3, 10, 20, 30, 40)]
		public void GetPixel_AfterBitmapClear_ReturnsSameColorAsBitmapGetPixel(int width, int height, int x, int y, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			using var directBitmap = new DirectBitmap(width, height);
			using (var graphics = Graphics.FromImage(directBitmap.Bitmap))
			{
				graphics.Clear(clearColor);
			}
			Color expectedColor = directBitmap.Bitmap.GetPixel(x, y);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(PixelFormat.Format32bppArgb, 10, 20, 30)]
		public void FromBitmap_SetsColorFromOriginalBitmap(PixelFormat pixelFormat, byte r, byte g, byte b)
		{
			Color color = Color.FromArgb(r, g, b);
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
