using System;
using ImageFilters;
using System.Drawing;

namespace Experiments
{
	class Program
	{
		static void Main(string[] args)
		{
			Rectangle r = new Rectangle(10, 10, 100, 100);
			throw new ArgumentException("message", nameof(r.Width));
			/*/
			var directBitmap = DirectBitmap.FromFile(@"C:\Users\boles\Plocha\web-inspirace.jpg");
			var filter = new RotatingFilter(45, Color.Green);
			filter.Apply(ref directBitmap);
			directBitmap.Bitmap.Save(@"C:\Users\boles\Plocha\rotatedonlyhigh.jpg");
			/**/
			/*/
			var input = new Bitmap(@"C:\Users\boles\Plocha\web-inspirace.jpg");
			var output = new Bitmap(input.Height, input.Width, input.PixelFormat);
			Rectangle srcRect = new Rectangle
			{
				X = 0,
				Y = 0,
				Width = input.Width,
				Height = input.Height
			};
			Rectangle destRect = new Rectangle
			{
				X = input.Width,
				Y = input.Height,
				Width = -input.Width,
				Height = -input.Height
			};
			using (var graphics = Graphics.FromImage(output))
			{
				graphics.DrawImage(input, srcRect, destRect, GraphicsUnit.Pixel);
			}
			output.Save(@"C:\Users\boles\Plocha\flippedboth.jpg");
			/**/
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
