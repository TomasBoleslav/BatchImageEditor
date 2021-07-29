using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
	public class ResizingFilter : IImageFilter
	{
		public ResizingFilter(int newWidth, int newHeight)
		{
			_resizingStrategy = new FixedResizing(newWidth, newHeight);
		}

		public ResizingFilter(float factor)
		{
			_resizingStrategy = new ResizingByFactor(factor);
		}

		public void Apply(ref DirectBitmap input)
		{
			Size newSize = _resizingStrategy.ComputeNewSize(input.Width, input.Height);
			var output = new DirectBitmap(newSize.Width, newSize.Height, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				graphics.DrawImage(input.Bitmap, 0, 0, output.Width, output.Height);
			}
			input.Dispose();
			input = output;
		}

		private readonly IResizingStrategy _resizingStrategy;

		private interface IResizingStrategy
		{
			Size ComputeNewSize(int width, int height);
		}

		private class ResizingByFactor : IResizingStrategy
		{
			public ResizingByFactor(float factor)
			{
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

		private class FixedResizing : IResizingStrategy
		{
			public FixedResizing(int width, int height)
			{
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
