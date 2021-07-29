using System;

namespace ImageFilters
{
    /*
	public class GaussianBlurFilter : LinearFilter
	{
		public GaussianBlurFilter(int radius, double sigma)
		{
            if (radius < 0)
            {
                throw new ArgumentException("Radius must be a nonnegative integer.");
            }
            Kernel = CreateKernel(radius, sigma);
        }

        private static float[][] CreateKernel(int radius, double sigma)
		{
            int kernelSize = 2 * radius + 1;
            double[][] kernelDouble = Utils.CreateJagged2DArray<double>(kernelSize, kernelSize);
			for (int x = -radius; x <= radius; x++)
			{
				for (int y = -radius; y <= radius; y++)
				{
                    double eExponent = -(x * x + y * y) / (2 * sigma * sigma);
                    double eExpression = Math.Pow(Math.E, eExponent);
                    double kernelValue = eExpression / (2 * Math.PI * sigma * sigma);
                    kernelDouble[x + radius][y + radius] = kernelValue;
				}
			}
            return NormalizeKernel(kernelDouble);
        }
	}
    */
}
