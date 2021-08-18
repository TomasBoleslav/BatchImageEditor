using System;
using System.Drawing;
using ThrowHelpers;

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

		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			var outputImage = ApplyMedian(image);
			image.Dispose();
			image = outputImage;
		}

		private readonly int _radius;

		private DirectBitmap ApplyMedian(DirectBitmap inputImage)
		{
			var outputImage = new DirectBitmap(inputImage.Width, inputImage.Height);
			int diameter = 2 * _radius + 1;
			int numColorsInWindow = diameter * diameter;
			byte[] valuesR = new byte[numColorsInWindow];
			byte[] valuesG = new byte[numColorsInWindow];
			byte[] valuesB = new byte[numColorsInWindow];
			int middle = numColorsInWindow / 2;

			int maxX = inputImage.Width - 1;
			int maxY = inputImage.Height - 1;
			for (int i = 0; i < inputImage.Height; i++)
			{
				for (int j = 0; j < inputImage.Width; j++)
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
							Color inputColor = inputImage.GetPixel(x, y);
							valuesR[valuesIndex] = inputColor.R;
							valuesG[valuesIndex] = inputColor.G;
							valuesB[valuesIndex] = inputColor.B;
							valuesIndex++;
						}
					}
					Array.Sort(valuesR);
					Array.Sort(valuesG);
					Array.Sort(valuesB);
					Color oldColor = inputImage.GetPixel(j, i);
					Color outputColor = Color.FromArgb(
						oldColor.A,
						valuesR[middle],
						valuesG[middle],
						valuesB[middle]
						);
					outputImage.SetPixel(j, i, outputColor);
				}
			}
			return outputImage;
		}
	}
}
