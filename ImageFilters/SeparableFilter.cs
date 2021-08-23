using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that is linear but with a kernel matrix separated into a product of two vectors.
	/// </summary>
	public abstract class SeparableFilter : IImageFilter
	{
		/// <inheritdoc/>
		public void Apply(ref DirectBitmap input)
		{
			ArgChecker.NotNull(HorizontalVector, nameof(HorizontalVector));
			ArgChecker.NotNull(VerticalVector, nameof(VerticalVector));
			using var intermediateResult = new DirectBitmap(input.Width, input.Height);
			ApplyHorizontalVector(input, intermediateResult);
			ApplyVerticalVector(intermediateResult, input);
		}

		/// <summary>
		/// Gets the horizontal vector of the filter.
		/// </summary>
		protected float[] HorizontalVector { get; private set; }

		/// <summary>
		/// Gets the vertical vector of the filter.
		/// </summary>
		protected float[] VerticalVector { get; private set; }

		/// <summary>
		/// Sets vectors of the filter.
		/// </summary>
		/// <param name="horizontal">The horizontal vector of the filter.</param>
		/// <param name="vertical">The vertical vector of the filter.</param>
		protected void SetVectors(float[] horizontal, float[] vertical)
		{
			ArgChecker.NotNull(horizontal, nameof(horizontal));
			ArgChecker.NotNull(vertical, nameof(vertical));
			if (horizontal.Length != vertical.Length)
			{
				throw new ArgumentException("Vectors must have the same length.");
			}
			HorizontalVector = horizontal;
			VerticalVector = vertical;
		}

		/// <summary>
		/// Normalize a vector by dividing it by the sum of its values.
		/// </summary>
		/// <param name="vector">A vector to normalize.</param>
		/// <returns>The normalized vector.</returns>
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

		/// <summary>
		/// Applies the horizontal vector to the image.
		/// </summary>
		/// <param name="inputImage">An input image.</param>
		/// <param name="outputImage">An output image.</param>
		private void ApplyHorizontalVector(DirectBitmap inputImage, DirectBitmap outputImage)
		{
			float[] vector = HorizontalVector;
			int vectorHalf = vector.Length / 2;
			int maxY = outputImage.Height - 1;
			for (int i = 0; i < outputImage.Height; i++)
			{
				for (int j = 0; j < outputImage.Width; j++)
				{
					float sumR = 0;
					float sumB = 0;
					float sumG = 0;
					for (int n = 0; n < vector.Length; n++)
					{
						int y = i + n - vectorHalf;
						y = Math.Clamp(y, 0, maxY);
						Color inputColor = inputImage.GetPixel(j, y);
						float kernelValue = vector[n];
						sumR += inputColor.R * kernelValue;
						sumG += inputColor.G * kernelValue;
						sumB += inputColor.B * kernelValue;
					}
					Color oldColor = inputImage.GetPixel(j, i);
					Color outputColor = Color.FromArgb(
						oldColor.A,
						ColorHelper.ClampColorChannel(sumR),
						ColorHelper.ClampColorChannel(sumG),
						ColorHelper.ClampColorChannel(sumB)
						);
					outputImage.SetPixel(j, i, outputColor);
				}
			}
		}

		/// <summary>
		/// Applies the vertical vector to the image.
		/// </summary>
		/// <param name="inputImage">An input image.</param>
		/// <param name="outputImage">An output image.</param>
		private void ApplyVerticalVector(DirectBitmap inputImage, DirectBitmap outputImage)
		{
			float[] vector = VerticalVector;
			int vectorHalf = vector.Length / 2;
			int maxX = outputImage.Width - 1;
			for (int i = 0; i < outputImage.Height; i++)
			{
				for (int j = 0; j < outputImage.Width; j++)
				{
					float sumR = 0;
					float sumB = 0;
					float sumG = 0;
					for (int n = 0; n < vector.Length; n++)
					{
						int x = j + n - vectorHalf;
						x = Math.Clamp(x, 0, maxX);
						Color inputColor = inputImage.GetPixel(x, i);
						float kernelValue = vector[n];
						sumR += inputColor.R * kernelValue;
						sumG += inputColor.G * kernelValue;
						sumB += inputColor.B * kernelValue;
					}
					Color oldColor = inputImage.GetPixel(j, i);
					Color outputColor = Color.FromArgb(
						oldColor.A,
						ColorHelper.ClampColorChannel(sumR),
						ColorHelper.ClampColorChannel(sumG),
						ColorHelper.ClampColorChannel(sumB)
						);
					outputImage.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}
