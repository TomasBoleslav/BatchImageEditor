using Xunit;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Tests
{
	public class CustomLinearFilterTests
	{
		[Fact]
		public void Apply_AssignsNewBitmapToParameter()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			float[][] kernel = CreateMatrixOfOnes(1, 1);
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			Assert.NotSame(oldDirectBitmap, directBitmap);
		}

		[Fact]
		public void Apply_DisposesOldBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			float[][] kernel = CreateMatrixOfOnes(1, 1);
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			Assert.True(oldDirectBitmap.IsDisposed);
		}

		[Theory]
		[InlineData(1, 1, 1, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(1, 1, 3, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 5, 1, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 5, 3, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 5, 15, PixelFormat.Format24bppRgb, 1, 2, 3)]
		[InlineData(5, 5, 3, PixelFormat.Format32bppRgb, 1, 2, 3)]
		[InlineData(5, 5, 3, PixelFormat.Format32bppArgb, 1, 2, 3)]
		public void Apply_KernelOfOnes_ResultIsSumOfNeighborColors(int width, int height, int kernelSize, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			var directBitmap = new DirectBitmap(width, height, pixelFormat);
			ClearBitmap(directBitmap, clearColor);
			float[][] kernel = CreateMatrixOfOnes(kernelSize, kernelSize);
			var filter = new CustomLinearFilter(kernel);
			Color expectedColor = MultiplyColor(clearColor, kernelSize * kernelSize);

			filter.Apply(ref directBitmap);

			for (int y = 0; y < directBitmap.Height; y++)
			{
				for (int x = 0; x < directBitmap.Width; x++)
				{
					Color actualColor = directBitmap.GetPixel(x, y);
					Assert.Equal(expectedColor, actualColor);
				}
			}
		}

		private static float[][] CreateMatrixOfOnes(int rowCount, int columnCount)
		{
			float[][] matrix = new float[rowCount][];
			for (int i = 0; i < rowCount; i++)
			{
				matrix[i] = new float[columnCount];
				for (int j = 0; j < columnCount; j++)
				{
					matrix[i][j] = 1.0f;
				}
			}
			return matrix;
		}

		private static void ClearBitmap(DirectBitmap bitmap, Color color)
		{
			using (var graphics = Graphics.FromImage(bitmap.Bitmap))
			{
				graphics.Clear(color);
			}
		}

		private static Color MultiplyColor(Color color, int factor)
		{
			return Color.FromArgb(
				Math.Clamp(color.A * factor, 0, byte.MaxValue),
				Math.Clamp(color.R * factor, 0, byte.MaxValue),
				Math.Clamp(color.G * factor, 0, byte.MaxValue),
				Math.Clamp(color.B * factor, 0, byte.MaxValue)
				);
		}
	}
}
