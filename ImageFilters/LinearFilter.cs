using System;
using System.Drawing;

namespace ImageFilters
{
	public abstract class LinearFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap inputBitmap)
		{
			var result = new DirectBitmap(inputBitmap.Width, inputBitmap.Height, inputBitmap.Bitmap.PixelFormat);
			float[][] kernel = GetConvolutionKernel();
			int kernelHeight = kernel.Length;
			int kernelWidth = kernel[0].Length;
			int kernelTop = kernelHeight / 2;
			int kernelLeft = kernelWidth / 2;
			int maxX = result.Width - 1;
			int maxY = result.Height - 1;

			for (int i = 0; i < result.Height; i++)
			{
				for (int j = 0; j < result.Width; j++)
				{
					float sumR = 0;
					float sumB = 0;
					float sumG = 0;
					for (int n = 0; n < kernelHeight; n++)
					{
						for (int m = 0; m < kernelWidth; m++)
						{
							// Input pixel coordinates
							int y = i + n - kernelTop;
							int x = j + m - kernelLeft;
							y = Math.Clamp(y, 0, maxY);
							x = Math.Clamp(x, 0, maxX);
							Color inputColor = inputBitmap.GetPixel(x, y);
							float kernelValue = kernel[n][m];
							sumR += inputColor.R * kernelValue;
							sumB += inputColor.G * kernelValue;
							sumG += inputColor.B * kernelValue;
						}
					}
					Color outputColor = Utils.ColorFromNonnegativeNumbers(sumR, sumG, sumB);
					result.SetPixel(j, i, outputColor);
				}
			}
			inputBitmap = result;
		}

		protected abstract float[][] GetConvolutionKernel();

		private static void CheckKernelCorrectness(float[][] kernel)
		{
			ThrowHelper.ThrowIfNull(kernel, nameof(kernel));
			if (kernel.Length == 0)
			{
				throw new FormatException("Kernel must be a rectangular matrix of odd length of rows and columns with nonnull values.");
			}
			for (int i = 0; i < kernel.Length; i++)
			{
				if (kernel[i] == null)
				{
					throw new FormatException(); // TODO
				}
				for (int j = 0; j < kernel[i].Length; j++)
				{

				}
			}
			if (kernel.Length == 0)
			{
				
			}
		}
	}
}