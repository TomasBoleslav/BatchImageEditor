using System;
using System.Drawing;

namespace ImageFilters
{
	public sealed class MedianFilter : IImageFilter
	{
		public MedianFilter(int radius)
		{
			if (radius < 1)
			{
				throw new ArgumentException("Radius must be a non-zero positive integer.");
			}
			_radius = radius;
		}

		public void Apply(ref DirectBitmap input)
		{
			var output = new DirectBitmap(input.Width, input.Height, input.PixelFormat);
			ApplyMean(input, output);
			input.Dispose();
			input = output;
		}

		private readonly int _radius;

		private void ApplyMean(DirectBitmap input, DirectBitmap output)
		{
			int diameter = 2 * _radius + 1;
			int numColorsInWindow = diameter * diameter;
			byte[] valuesR = new byte[numColorsInWindow];
			byte[] valuesG = new byte[numColorsInWindow];
			byte[] valuesB = new byte[numColorsInWindow];
			int middle = numColorsInWindow / 2;

			int maxX = input.Width - 1;
			int maxY = input.Height - 1;
			for (int i = 0; i < input.Height; i++)
			{
				for (int j = 0; j < input.Width; j++)
				{
					int valuesIndex = 0;
					for (int n = 0; n < diameter; n++)
					{
						for (int m = 0; m < diameter; m++)
						{
							// Input pixel coordinates
							int y = i + n - _radius;
							int x = j + m - _radius;
							y = Math.Clamp(y, 0, maxY);
							x = Math.Clamp(x, 0, maxX);
							Color inputColor = input.GetPixel(x, y);
							valuesR[valuesIndex] = inputColor.R;
							valuesG[valuesIndex] = inputColor.G;
							valuesB[valuesIndex] = inputColor.B;
							valuesIndex++;
						}
					}
					Array.Sort(valuesR);
					Array.Sort(valuesG);
					Array.Sort(valuesB);
					Color outputColor = Color.FromArgb(
						valuesR[middle],
						valuesG[middle],
						valuesB[middle]
						);
					output.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}
