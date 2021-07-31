using System;
using System.Drawing;

namespace ImageFilters
{
	public abstract class SeparableFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap input)
		{
			Ensure.NotNull(HorizontalVector, nameof(HorizontalVector));
			Ensure.NotNull(VerticalVector, nameof(VerticalVector));
			using var intermediateResult = new DirectBitmap(input.Width, input.Height, input.PixelFormat);
			ApplyHorizontalVector(input, intermediateResult);
			ApplyVerticalVector(intermediateResult, input);
		}

		// TODO: does not have to be protected, use private member instead?
		protected float[] HorizontalVector { get; private set; }

		protected float[] VerticalVector { get; private set; }

		protected void SetVectors(float[] horizontal, float[] vertical)
		{
			Ensure.NotNull(horizontal, nameof(horizontal));
			Ensure.NotNull(vertical, nameof(vertical));
			if (horizontal.Length != vertical.Length)
			{
				throw new ArgumentException("Vectors must have the same length.");
			}
			HorizontalVector = horizontal;
			VerticalVector = vertical;
		}

		protected static float[] NormalizeVector(double[] vector)
		{
			double sum = 0.0;
			for (int i = 0; i < vector.Length; i++)
			{
				sum += vector[i];
			}
			float[] normalizedVector = new float[vector.Length];
			for (int i = 0; i < vector.Length; i++)
			{
				normalizedVector[i] = (float)(vector[i] / sum);
			}
			return normalizedVector;
		}

		private void ApplyHorizontalVector(DirectBitmap input, DirectBitmap output)
		{
			float[] vector = HorizontalVector;
			int vectorHalf = vector.Length / 2;
			int maxY = output.Height - 1;
			for (int i = 0; i < output.Height; i++)
			{
				for (int j = 0; j < output.Width; j++)
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
					output.SetPixel(j, i, outputColor);
				}
			}
		}

		private void ApplyVerticalVector(DirectBitmap input, DirectBitmap output)
		{
			float[] vector = VerticalVector;
			int vectorHalf = vector.Length / 2;
			int maxX = output.Width - 1;
			for (int i = 0; i < output.Height; i++)
			{
				for (int j = 0; j < output.Width; j++)
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
					output.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}
