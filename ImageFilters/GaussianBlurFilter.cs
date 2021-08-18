using System;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class GaussianBlurFilter : SeparableFilter
	{
		public GaussianBlurFilter(int radius, double sigma)
		{
			ArgChecker.Positive(radius, nameof(radius));
			ArgChecker.Positive(sigma, nameof(sigma));
			float[] vector = CreateConvolutionVector(radius, sigma);
			SetVectors(vector, vector);
		}

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
