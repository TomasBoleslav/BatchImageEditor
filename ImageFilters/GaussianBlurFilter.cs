using System;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that blurs images using Gaussian blur.
	/// </summary>
	public sealed class GaussianBlurFilter : SeparableFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="GaussianBlurFilter"/> with the given window radius and standard deviation.
		/// </summary>
		/// <param name="radius">The radius of the blur filter.</param>
		/// <param name="sigma">The standard deviation of the blur filter.</param>
		public GaussianBlurFilter(int radius, double sigma)
		{
			ArgChecker.Positive(radius, nameof(radius));
			ArgChecker.Positive(sigma, nameof(sigma));
			float[] vector = CreateConvolutionVector(radius, sigma);
			SetVectors(vector, vector);
		}

		/// <summary>
		/// Creates a "convolution vector" that will be used as a horizontal and vertical vector for the separable filter.
		/// </summary>
		/// <param name="radius">The radius of the blur filter.</param>
		/// <param name="sigma">The standard deviation of the blur filter.</param>
		/// <returns>A vector that will be used as a horizontal and vertical vector for the separable filter.</returns>
		private static float[] CreateConvolutionVector(int radius, double sigma)
		{
			double[] vectorDouble = new double[2 * radius + 1];
			for (int x = -radius; x <= radius; x++)
			{
				double exponent = -(x * x) / (sigma * sigma);
				double vectorValue = Math.Pow(Math.E, exponent);	// denominator skipped, vector will be normalized
				vectorDouble[x + radius] = vectorValue;
			}
			return NormalizeVector(vectorDouble);
		}
	}
}
