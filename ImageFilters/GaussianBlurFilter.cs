using System;

namespace ImageFilters
{
	public class GaussianBlurFilter : SeparableLinearFilter
	{
		public GaussianBlurFilter(int radius, double sigma)
		{
			double sum = 0.0;
			double[] vectorDouble = new double[2 * radius + 1];
			for (int x = -radius; x <= radius; x++)
			{
				double exponent = -(x * x) / (sigma * sigma);
				double eExpression = Math.Pow(Math.E, exponent);
				double denominator = Math.Sqrt(2 * Math.PI * sigma * sigma);
				double vectorValue = eExpression / denominator;
				convolutionVector[x + radius] = (float)vectorValue;
				sum += vectorValue;
			}
			convolutionVector = new float[vectorDouble.Length];
			for (int i = 0; i < convolutionVector.Length; i++)
			{
				convolutionVector[i] = (float)(vectorDouble[i] / sum);
			}
		}

		protected override float[] GetHorizontalVector()
		{
			return convolutionVector;
		}

		protected override float[] GetVerticalVector()
		{
			return convolutionVector;
		}

		private readonly float[] convolutionVector;
	}
}
