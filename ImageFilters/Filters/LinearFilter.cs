﻿using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that uses a convolution matrix to compute new colors.
	/// </summary>
	public abstract class LinearFilter : IImageFilter
	{
		/// <inheritdoc/>
		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			ArgChecker.NotNull(_kernel, nameof(_kernel));
			var outputImage = ApplyKernel(image);
			image.Dispose();
			image = outputImage;
		}

		/// <summary>
		/// Verifies and sets a convolution kernel.
		/// </summary>
		/// <param name="kernel">A convolution kernel.</param>
		protected void SetKernel(float[][] kernel)
		{
			VerifyKernelCorrectness(kernel);
			_kernel = kernel;
			_kernelHeight = kernel.Length;
			_kernelWidth = kernel[0].Length;
			_radiusVertical = _kernelHeight / 2;
			_radiusHorizontal = _kernelWidth / 2;
		}

		/// <summary>
		/// Normalizes a convolution kernel by dividing each value by sum of all values in the kernel.
		/// </summary>
		/// <param name="kernel">A convolution kernel.</param>
		/// <returns>A normalized kernel.</returns>
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
			float[][] normalizedKernel = new float[rowCount][];
			for (int i = 0; i < rowCount; i++)
			{
				normalizedKernel[i] = new float[columnCount];
				for (int j = 0; j < columnCount; j++)
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

		/// <summary>
		/// Verifies that the given convolution kernel is valid.
		/// </summary>
		/// <param name="kernel">A convolution kernel.</param>
		private static void VerifyKernelCorrectness(float[][] kernel)
		{
			ArgChecker.NotNull(kernel, nameof(kernel));
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

		/// <summary>
		/// Applies the kernel to an image.
		/// </summary>
		/// <param name="inputImage">An image the kernel will applied to.</param>
		/// <returns>The resulting image.</returns>
		private DirectBitmap ApplyKernel(DirectBitmap inputImage)
		{
			var outputImage = new DirectBitmap(inputImage.Width, inputImage.Height);
			int maxX = inputImage.Width - 1;
			int maxY = inputImage.Height - 1;
			for (int i = 0; i < inputImage.Height; i++)
			{
				for (int j = 0; j < inputImage.Width; j++)
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
							Color inputColor = inputImage.GetPixel(x, y);
							float kernelValue = _kernel[n][m];
							sumR += inputColor.R * kernelValue;
							sumG += inputColor.G * kernelValue;
							sumB += inputColor.B * kernelValue;
						}
					}
					Color oldColor = inputImage.GetPixel(j, i);
					Color outputColor = Color.FromArgb(
						oldColor.A,
						ColorHelper.ClampColorChannel(sumR),
						ColorHelper.ClampColorChannel(sumG),
						ColorHelper.ClampColorChannel(sumB)
						);
					outputImage.SetPixel(j, i, outputColor);
				}
			}
			return outputImage;
		}
	}
}