using Xunit;
using System.Drawing;

namespace ImageFilters.Tests
{
	public sealed class CustomLinearFilterTests
	{
		[Fact]
		public void Apply_AssignsNewBitmapToParameter()
		{
			var directBitmap = new DirectBitmap(5, 5);
			var oldDirectBitmap = directBitmap;
			float[][] kernel = MathHelper.CreateMatrixOfOnes(1, 1);
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			Assert.NotSame(oldDirectBitmap, directBitmap);
		}

		[Fact]
		public void Apply_DisposesOldBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5);
			var oldDirectBitmap = directBitmap;
			float[][] kernel = MathHelper.CreateMatrixOfOnes(1, 1);
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			Assert.True(oldDirectBitmap.IsDisposed);
		}

		[Theory]
		[InlineData(1, 1, 1, 10, 20, 30)]
		[InlineData(1, 1, 3, 10, 20, 30)]
		[InlineData(5, 5, 1, 10, 20, 30)]
		[InlineData(5, 5, 3, 10, 20, 30, 40)]
		[InlineData(5, 5, 15, 10, 20, 30, 40)]
		public void Apply_KernelOfOnes_ResultIsSumOfNeighborColors(int width, int height, int kernelSize, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			var directBitmap = new DirectBitmap(width, height);
			DirectBitmapHelper.Clear(directBitmap, clearColor);
			float[][] kernel = MathHelper.CreateMatrixOfOnes(kernelSize, kernelSize);
			var filter = new CustomLinearFilter(kernel);
			Color expectedColor = clearColor.Multiply(kernelSize * kernelSize).WithAlpha(a);

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
	}
}
