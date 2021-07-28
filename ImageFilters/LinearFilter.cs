using System;
using System.Drawing;

namespace ImageFilters
{
	public abstract class LinearFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap input)
		{
			// TODO: make speed test for gaussian blur using LinearFilter and SeparableFilter where 2 bitmaps are created
			// TODO: or just use LinearFilter
			ThrowHelper.ThrowIfNull(input, nameof(input));
			ThrowHelper.ThrowIfNull(Kernel, nameof(input));
			var result = new DirectBitmap(input.Width, input.Height, input.Bitmap.PixelFormat);
			ApplyKernel(input, result);
			input.Dispose();
			input = result;
		}

		protected float[][] Kernel
		{
			get
			{
				return _kernel;
			}
			set
			{
				VerifyKernel(value);
				_kernel = value;
			}
		}

		protected static float[][] NormalizeKernel(double[][] kernel)
		{
			int rowCount = kernel.Length;
			int columnCount = kernel[0].Length;
			double sum = 0.0;
			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < columnCount; j++)
				{
					sum += kernel[i][j];
				}
			}
			float[][] normalizedKernel = Utils.CreateJagged2DArray<float>(rowCount, columnCount);
			for (int i = 0; i < kernel.Length; i++)
			{
				for (int j = 0; j < kernel[0].Length; j++)
				{
					normalizedKernel[i][j] = (float)(kernel[i][j] / sum);
				}
			}
			return normalizedKernel;
		}

		private float[][] _kernel;

		private static void VerifyKernel(float[][] kernel)
		{
			ThrowHelper.ThrowIfNull(kernel, nameof(kernel));
			if (kernel.Length == 0)
			{
				throw new ArgumentException("Kernel matrix cannot be empty.");
			}
			else if (kernel.Length % 2 == 0)
			{
				throw new ArgumentException("Kernel matrix must have an odd number of rows.");
			}
			int rowLength = -1;
			for (int i = 0; i < kernel.Length; i++)
			{
				if (kernel[i] == null)
				{
					throw new ArgumentException("Kernel matrix must have nonnull rows.");
				}
				// Row length not yet assigned
				if (rowLength < 0)
				{
					if (rowLength % 2 == 0)
					{
						throw new ArgumentException("Kernel matrix must have an odd number of columns.");
					}
					rowLength = kernel[i].Length;
				}
				// Row length already assigned before
				else if (kernel[i].Length != rowLength)
				{
					throw new ArgumentException("Kernel matrix must be rectangular.");
				}
			}
		}

		private void ApplyKernel(DirectBitmap input, DirectBitmap result)
		{
			int kernelHeight = Kernel.Length;
			int kernelWidth = Kernel[0].Length;
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
							Color inputColor = input.GetPixel(x, y);
							float kernelValue = Kernel[n][m];
							sumR += inputColor.R * kernelValue;
							sumG += inputColor.G * kernelValue;
							sumB += inputColor.B * kernelValue;
						}
					}
					Color outputColor = Utils.GetColorByClamping(sumR, sumG, sumB);
					result.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}