using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ResizingFilter : IImageFilter
	{
		public ResizingFilter(IResizingAlgorithm resizingAlgorithm)
		{
			_resizingAlgorithm = resizingAlgorithm;
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ArgChecker.NotNull(inputBitmap, nameof(inputBitmap));
			DirectBitmap output = Resize(inputBitmap);
			inputBitmap.Dispose();
			inputBitmap = output;
		}

		private readonly IResizingAlgorithm _resizingAlgorithm;

		private DirectBitmap Resize(DirectBitmap input)
		{
			Size newSize = _resizingAlgorithm.ComputeNewSize(input.Bitmap.Size);
			newSize.Width = Math.Max(newSize.Width, 1);
			newSize.Height = Math.Max(newSize.Height, 1);
			var output = new DirectBitmap(newSize.Width, newSize.Height, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				// TODO: high quality settings?
				graphics.DrawImage(input.Bitmap, 0, 0, output.Width, output.Height);
			}
			return output;
		}
	}
}
