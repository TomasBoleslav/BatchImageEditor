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
			byte[] array = new byte[10];
			var random = new Random(1);
			random.NextBytes(array);
			/*
			using var bitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
			using (var g = Graphics.FromImage(bitmap))
			{
				g.Clear(Color.FromArgb(50, 150, 200, 250));
			}
			Console.WriteLine(bitmap.GetPixel(0, 0));

			using var directBitmap = new DirectBitmap(1, 1, PixelFormat.Format32bppArgb);
			using (var g = Graphics.FromImage(directBitmap.Bitmap))
			{
				g.Clear(Color.FromArgb(50, 150, 200, 250));
			}

			//directBitmap.Bitmap.SetPixel(0, 0, Color.FromArgb(50, 150, 200, 250));
			Console.WriteLine(directBitmap.GetPixel(0, 0));

			directBitmap.SetPixel(0, 0, Color.FromArgb(255, 1, 2, 3));
			Console.WriteLine(directBitmap.GetPixel(0, 0));
			*/
		}

		private static void FuncWithRef(ref string value)
		{

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
