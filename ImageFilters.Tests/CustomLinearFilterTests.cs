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

		[Fact]
		public void Apply_Identity_ResultIsSame()
		{
			Color color = Color.FromArgb(10, 20, 30);
			var directBitmap = new DirectBitmap(5, 5, PixelFormat.Format24bppRgb);
			ClearBitmap(directBitmap, color);
			Color colorInBitmap = directBitmap.GetPixel(0, 0);
			float[][] kernel = CreateIdentityKernel();
			var filter = new CustomLinearFilter(kernel);

			filter.Apply(ref directBitmap);

			for (int y = 0; y < directBitmap.Height; y++)
			{
				for (int x = 0; x < directBitmap.Width; x++)
				{
					Color actualColor = directBitmap.GetPixel(x, y);
					Assert.Equal(color, actualColor);
				}
			}
		}

		private float[][] CreateIdentityKernel()
		{
			float[][] identity = { new[] { 1.0f } };
			return identity;
		}

		private void ClearBitmap(DirectBitmap bitmap, Color color)
		{
			using (var graphics = Graphics.FromImage(bitmap.Bitmap))
			{
				graphics.Clear(color);
			}
		}
	}
}
