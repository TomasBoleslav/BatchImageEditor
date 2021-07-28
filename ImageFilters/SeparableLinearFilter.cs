using System;
using System.Drawing;

namespace ImageFilters
{
	public abstract class SeparableLinearFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap input)
		{
			var result = new DirectBitmap(input.Width, input.Height, input.Bitmap.PixelFormat);
			ApplyHorizontalVector(input, result);
			ApplyVerticalVector(result, result);
			input = result;
		}

		protected abstract float[] GetHorizontalVector();

		protected abstract float[] GetVerticalVector();

		private void ApplyHorizontalVector(DirectBitmap input, DirectBitmap result)
		{
			float[] vector = GetHorizontalVector();
			int vectorHalf = vector.Length / 2;
			int maxY = result.Height - 1;
			for (int i = 0; i < result.Height; i++)
			{
				for (int j = 0; j < result.Width; j++)
				{
					float sumR = 0;
					float sumB = 0;
					float sumG = 0;
					for (int n = 0; n < vector.Length; n++)
					{
						int y = i + n - vectorHalf;
						y = Math.Clamp(y, 0, maxY);
						Color inputColor = input.GetPixel(j, y);
						float kernelValue = vector[n];
						sumR += inputColor.R * kernelValue;
						sumB += inputColor.G * kernelValue;
						sumG += inputColor.B * kernelValue;
					}
					Color outputColor = Utils.ColorFromNonnegativeNumbers(sumR, sumG, sumB);
					result.SetPixel(j, i, outputColor);
				}
			}
		}

		private void ApplyVerticalVector(DirectBitmap input, DirectBitmap result)
		{
			float[] vector = GetVerticalVector();
			int vectorHalf = vector.Length / 2;
			int maxX = result.Width - 1;
			for (int i = 0; i < result.Height; i++)
			{
				for (int j = 0; j < result.Width; j++)
				{
					float sumR = 0;
					float sumB = 0;
					float sumG = 0;
					for (int n = 0; n < vector.Length; n++)
					{
						int x = j + n - vectorHalf;
						x = Math.Clamp(x, 0, maxX);
						Color inputColor = input.GetPixel(x, i);
						float kernelValue = vector[n];
						sumR += inputColor.R * kernelValue;
						sumB += inputColor.G * kernelValue;
						sumG += inputColor.B * kernelValue;
					}
					Color outputColor = Utils.ColorFromNonnegativeNumbers(sumR, sumG, sumB);
					result.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}
