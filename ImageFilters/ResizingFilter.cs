using System;
using System.Drawing;

namespace ImageFilters
{
	// TODO: make abstract, use ResizingByFactorFilter, FixedResizingFilter
	public class ResizingFilter : IImageFilter
	{
		public ResizingFilter(int newWidth, int newHeight)
		{
			_resizingAlgorithm = new FixedResizing(newWidth, newHeight);
		}

		public ResizingFilter(float factor)
		{
			_resizingAlgorithm = new ResizingByFactor(factor);
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			DirectBitmap output = Resize(inputBitmap);
			inputBitmap.Dispose();
			inputBitmap = output;
		}

		private readonly IResizingAlgorithm _resizingAlgorithm;

		private DirectBitmap Resize(DirectBitmap input)
		{
			Size newSize = _resizingAlgorithm.ComputeNewSize(input.Width, input.Height);
			newSize = new Size
			{
				Width = Math.Max(newSize.Width, 1),
				Height = Math.Max(newSize.Height, 1)
			};
			var output = new DirectBitmap(newSize.Width, newSize.Height, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				graphics.DrawImage(input.Bitmap, 0, 0, output.Width, output.Height);
			}
			return output;
		}

		private interface IResizingAlgorithm
		{
			Size ComputeNewSize(int width, int height);
		}

		private class ResizingByFactor : IResizingAlgorithm
		{
			public ResizingByFactor(float factor)
			{
				ThrowHelper.ThrowIfNotPositive(factor, nameof(factor));
				_factor = factor;
			}

			public Size ComputeNewSize(int width, int height)
			{
				return new Size
				{
					Width = (int)(width * _factor),
					Height = (int)(height * _factor)
				};
			}

			private readonly float _factor;
		}

		private class FixedResizing : IResizingAlgorithm
		{
			public FixedResizing(int width, int height)
			{
				ThrowHelper.ThrowIfNotPositive(width, nameof(width));
				ThrowHelper.ThrowIfNotPositive(height, nameof(height));
				_newWidth = width;
				_newHeight = height;
			}

			public Size ComputeNewSize(int width, int height)
			{
				return new Size(_newWidth, _newHeight);
			}

			private readonly int _newWidth;
			private readonly int _newHeight;
		}
	}
}
