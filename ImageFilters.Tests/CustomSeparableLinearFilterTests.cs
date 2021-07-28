using Xunit;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Tests
{
	public class CustomSeparableLinearFilterTests
	{
		[Fact]
		public void Apply_AssignsNewBitmapToParameter()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			float[] vector = CreateVectorOfOnes(1);
			var filter = new CustomSeparableLinearFilter(vector, vector);

			filter.Apply(ref directBitmap);

			Assert.NotSame(oldDirectBitmap, directBitmap);
		}

		[Fact]
		public void Apply_DisposesOldBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			var oldDirectBitmap = directBitmap;
			float[] vector = CreateVectorOfOnes(1);
			var filter = new CustomSeparableLinearFilter(vector, vector);

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
		public void Apply_KernelOfOnes_ResultIsSumOfNeighborColors(int width, int height, int vectorLength, PixelFormat pixelFormat, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			var directBitmap = new DirectBitmap(width, height, pixelFormat);
			ClearBitmap(directBitmap, clearColor);
			float[] vector = CreateVectorOfOnes(vectorLength);
			var filter = new CustomSeparableLinearFilter(vector, vector);
			Color expectedColor = MultiplyColor(clearColor, vectorLength * vectorLength);

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

		private static float[] CreateVectorOfOnes(int length)
		{
			float[] vector = new float[length];
			for (int i = 0; i < length; i++)
			{
				vector[i] = 1.0f;
			}
			return vector;
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
