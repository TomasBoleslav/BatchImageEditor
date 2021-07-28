using System;
using System.Drawing;

namespace ImageFilters
{
	public abstract class SeparableLinearFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap input)
		{
			ThrowHelper.ThrowIfNull(HorizontalVector, nameof(HorizontalVector));
			ThrowHelper.ThrowIfNull(VerticalVector, nameof(VerticalVector));
			var intermediate = new DirectBitmap(input.Width, input.Height, input.PixelFormat);
			ApplyHorizontalVector(input, intermediate);
			var result = new DirectBitmap(input.Width, input.Height, input.PixelFormat);
			ApplyVerticalVector(intermediate, result);
			input.Dispose();
			intermediate.Dispose();
			input = result;
		}

		protected float[] HorizontalVector { get; private set; }

		protected float[] VerticalVector { get; private set; }

		protected void SetVectors(float[] horizontal, float[] vertical)
		{
			ThrowHelper.ThrowIfNull(horizontal, nameof(horizontal));
			ThrowHelper.ThrowIfNull(vertical, nameof(vertical));
			if (horizontal.Length != vertical.Length)
			{
				throw new ArgumentException("Vectors must have the same length.");
			}
			HorizontalVector = horizontal;
			VerticalVector = vertical;
		}

		private void ApplyHorizontalVector(DirectBitmap input, DirectBitmap result)
		{
			float[] vector = HorizontalVector;
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
						sumG += inputColor.G * kernelValue;
						sumB += inputColor.B * kernelValue;
					}
					Color outputColor = Utils.ColorFromNonnegativeNumbers(sumR, sumG, sumB);
					result.SetPixel(j, i, outputColor);
				}
			}
		}

		private void ApplyVerticalVector(DirectBitmap input, DirectBitmap result)
		{
			float[] vector = VerticalVector;
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
						sumG += inputColor.G * kernelValue;
						sumB += inputColor.B * kernelValue;
					}
					Color outputColor = Utils.ColorFromNonnegativeNumbers(sumR, sumG, sumB);
					result.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}
