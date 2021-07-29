using System;
using System.Drawing;

namespace ImageFilters
{
	public abstract class LinearFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap input)
		{
			ThrowHelper.ThrowIfNull(input, nameof(input));
			ThrowHelper.ThrowIfNull(_kernel, nameof(_kernel));
			var result = new DirectBitmap(input.Width, input.Height, input.PixelFormat);
			ApplyKernel(input, result);
			input.Dispose();
			input = result;
		}

		protected void SetKernel(float[][] kernel)
		{
			VerifyKernelCorectness(kernel);
			_kernel = kernel;
			_kernelHeight = kernel.Length;
			_kernelWidth = kernel[0].Length;
			_radiusVertical = _kernelHeight / 2;
			_radiusHorizontal = _kernelWidth / 2;
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
		private int _kernelHeight;
		private int _kernelWidth;
		private int _radiusVertical;
		private int _radiusHorizontal;

		private static void VerifyKernelCorectness(float[][] kernel)
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

		private void ApplyKernel(DirectBitmap input, DirectBitmap output)
		{
			int maxX = input.Width - 1;
			int maxY = input.Height - 1;
			for (int i = 0; i < input.Height; i++)
			{
				for (int j = 0; j < input.Width; j++)
				{
					float sumR = 0;
					float sumB = 0;
					float sumG = 0;
					for (int n = 0; n < _kernelHeight; n++)
					{
						for (int m = 0; m < _kernelWidth; m++)
						{
							// Input pixel coordinates
							int y = i + n - _radiusVertical;
							int x = j + m - _radiusHorizontal;
							y = Math.Clamp(y, 0, maxY);
							x = Math.Clamp(x, 0, maxX);
							Color inputColor = input.GetPixel(x, y);
							float kernelValue = _kernel[n][m];
							sumR += inputColor.R * kernelValue;
							sumG += inputColor.G * kernelValue;
							sumB += inputColor.B * kernelValue;
						}
					}
					Color outputColor = Utils.GetColorByClamping(sumR, sumG, sumB);
					output.SetPixel(j, i, outputColor);
				}
			}
		}
	}
}