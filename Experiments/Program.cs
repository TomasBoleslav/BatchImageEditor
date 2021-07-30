using System;
using ImageFilters;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Experiments
{
	class Program
	{
		static void Main(string[] args)
		{
			var directBitmap = DirectBitmap.FromFile(@"C:\Users\boles\Plocha\web-inspirace.jpg");
			var filter = new RotatingFilter(45, Color.Green);
			filter.Apply(ref directBitmap);
			directBitmap.Bitmap.Save(@"C:\Users\boles\Plocha\rotatedonlyhigh.jpg");

		}

		private static double GaussianBlurSum(int radius, double sigma)
		{
			double sum = 0;
			float[] convolutionVector = new float[2 * radius + 1];
			for (int x = -radius; x <= radius; x++)
			{
				double exponent = -(x * x) / (sigma * sigma);
				double eExpression = Math.Pow(Math.E, exponent);
				double denominator = 2 * Math.PI * sigma * sigma;
				double vectorValue = Math.Sqrt(eExpression / denominator);
				convolutionVector[x + radius] = (float)vectorValue;
				sum += vectorValue;
			}
			return sum;
		}

	}
}
