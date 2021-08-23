using Xunit;
using System.Drawing;

namespace ImageFilters.Tests
{
	/// <summary>
	/// Tests of the <see cref="CustomSeparableFilter"/>.
	/// </summary>
	public sealed class CustomSeparableFilterTests
	{
		[Fact]
		public void Apply_AssignedBitmapIsInputBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5);
			var oldDirectBitmap = directBitmap;
			float[] vector = MathHelper.CreateVectorOfOnes(1);
			var filter = new CustomSeparableFilter(vector, vector);

			filter.Apply(ref directBitmap);

			Assert.Same(oldDirectBitmap, directBitmap);
		}

		[Fact]
		public void Apply_DoesNotDisposeInputBitmap()
		{
			var directBitmap = new DirectBitmap(5, 5);
			var oldDirectBitmap = directBitmap;
			float[] vector = MathHelper.CreateVectorOfOnes(1);
			var filter = new CustomSeparableFilter(vector, vector);

			filter.Apply(ref directBitmap);

			Assert.False(oldDirectBitmap.IsDisposed);
		}

		[Theory]
		[InlineData(1, 1, 1, 10, 20, 30)]
		[InlineData(1, 1, 3, 10, 20, 30)]
		[InlineData(5, 5, 1, 10, 20, 30)]
		[InlineData(5, 5, 3, 10, 20, 30, 40)]
		[InlineData(5, 5, 15, 10, 20, 30, 40)]
		public void Apply_KernelOfOnes_ResultIsSumOfNeighborColors(int width, int height, int vectorLength, byte r, byte g, byte b, byte a = 255)
		{
			Color clearColor = Color.FromArgb(a, r, g, b);
			var directBitmap = new DirectBitmap(width, height);
			DirectBitmapHelper.Clear(directBitmap, clearColor);
			float[] vector = MathHelper.CreateVectorOfOnes(vectorLength);
			var filter = new CustomSeparableFilter(vector, vector);
			Color expectedColor = clearColor.Multiply(vectorLength * vectorLength).WithAlpha(a);

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
