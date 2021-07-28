using System;

namespace ImageFilters
{
	public sealed class GaussianBlurSeparableFilter : SeparableLinearFilter
	{
		public GaussianBlurSeparableFilter(int radius, double sigma)
		{
			if (radius < 0)
			{
				throw new ArgumentException("Radius must be a nonnegative integer.");
			}
			float[] vector = ComputeConvolutionVector(radius, sigma);
			SetVectors(vector, vector);
		}

		private static float[] ComputeConvolutionVector(int radius, double sigma)
		{
			double sum = 0.0;
			double[] vectorDouble = new double[2 * radius + 1];
			for (int x = -radius; x <= radius; x++)
			{
				double exponent = -(x * x) / (sigma * sigma);
				double eExpression = Math.Pow(Math.E, exponent);
				double denominator = Math.Sqrt(2 * Math.PI * sigma * sigma);
				double vectorValue = eExpression / denominator;
				vectorDouble[x + radius] = vectorValue;
				sum += vectorValue;
			}
			float[] normalizedVector = new float[vectorDouble.Length];
			for (int i = 0; i < normalizedVector.Length; i++)
			{
				normalizedVector[i] = (float)(vectorDouble[i] / sum);
			}
			return normalizedVector;
		}
	}
}
