using System;

namespace ImageFilters
{
	public sealed class GaussianBlurFilter : SeparableFilter
	{
		public GaussianBlurFilter(int radius, double sigma)
		{
			if (radius <= 0)
			{
				throw new ArgumentException("Radius must be a positive integer.");
			}
			if (sigma <= 0.0)
			{
				throw new ArgumentException("Sigma must be a positive value.");
			}
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
