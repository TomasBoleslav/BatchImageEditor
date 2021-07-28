using Xunit;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Tests
{
	public class CustomLinearFilterTests
	{
		[Fact]
		public void Apply_DisposesOldBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			float[][] kernel = CreateIdentityKernel();
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			Assert.True(oldDirectBitmap.IsDisposed);
		}

		[Theory]
		[InlineData(1, 1, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(5, 5, PixelFormat.Format24bppRgb, 10, 20, 30)]
		[InlineData(1, 1, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(5, 5, PixelFormat.Format32bppRgb, 10, 20, 30)]
		[InlineData(1, 1, PixelFormat.Format32bppArgb, 10, 20, 30)]
		[InlineData(5, 5, PixelFormat.Format32bppArgb, 10, 20, 30)]
		public void Apply_Identity_ResultHasSameColor(int width, int height, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			var directBitmap = new DirectBitmap(width, height, pixelFormat);
			ClearBitmap(directBitmap, clearColor);
			float[][] kernel = CreateIdentityKernel();
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			for (int y = 0; y < directBitmap.Height; y++)
			{
				for (int x = 0; x < directBitmap.Width; x++)
				{
					Color actualColor = directBitmap.GetPixel(x, y);
					Assert.Equal(clearColor, actualColor);
				}
			}
		}

		private static float[][] CreateIdentityKernel()
		{
			float[][] identity = { new[] { 1.0f } };
			return identity;
		}

		private static void ClearBitmap(DirectBitmap bitmap, Color color)
		{
			using (var graphics = Graphics.FromImage(bitmap.Bitmap))
			{
				graphics.Clear(color);
			}
		}
	}
}
