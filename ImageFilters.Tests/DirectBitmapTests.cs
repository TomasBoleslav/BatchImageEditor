using System;
using Xunit;
using ImageFilters;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

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
		[InlineData(PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppRgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppArgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppArgb, 1, 2, 3, 4)]
		public void SetPixel_SetsColorOnBitmap(PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color expectedColor = Color.FromArgb(a, r, g, b);
			int width = 1;
			int height = 1;
			int x = 0;
			int y = 0;
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);

			directBitmap.SetPixel(x, y, expectedColor);
			Color actualColor = directBitmap.Bitmap.GetPixel(x, y);

			Assert.Equal(expectedColor, actualColor);
		}

		[Theory]
		[InlineData(PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppRgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppArgb, 1, 2, 3)]
		[InlineData(PixelFormat.Format32bppArgb, 1, 2, 3, 4)]
		public void GetPixel_ReturnsCorrectColor(PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color color = Color.FromArgb(a, r, g, b);
			int width = 1;
			int height = 1;
			int x = 0;
			int y = 0;
			using var directBitmap = new DirectBitmap(width, height, pixelFormat);
			directBitmap.SetPixel(x, y, color);

			Color actualColor = directBitmap.GetPixel(x, y);

			Assert.Equal(color, actualColor);
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
		[InlineData(PixelFormat.Format32bppArgb, 1, 2, 3, 4)]
		public void FromBitmap_PixelFormatSupported_SetsColorFromOriginalBitmap(PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			using var bitmap = CreateBitmap(1, 1, pixelFormat, clearColor);
			Color expectedColor = bitmap.GetPixel(0, 0);

			// TODO: clearing color does not work for 32bppArgb with alpha set to 4
			using var directBitmap = DirectBitmap.FromBitmap(bitmap);
			Color actualColor = directBitmap.GetPixel(0, 0);

			Assert.Equal(clearColor, actualColor);
		}

		private Bitmap CreateBitmap(int width, int height, PixelFormat pixelFormat, Color color)
		{
			var bitmap = new Bitmap(width, height, pixelFormat);
			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(color);
				graphics.FillRectangle(new SolidBrush(color), 0, 0, bitmap.Width, bitmap.Height);
				graphics.Flush();
			}
			return bitmap;
		}
	}
}
