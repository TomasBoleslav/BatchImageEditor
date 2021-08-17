using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ResizingFilter : IImageFilter
	{
		public ResizingFilter(IResizingAlgorithm resizingAlgorithm, Size maxSize)
		{
			ArgChecker.Positive(maxSize.Width, nameof(maxSize.Width));
			ArgChecker.Positive(maxSize.Height, nameof(maxSize.Height));
			_resizingAlgorithm = resizingAlgorithm;
			_maxSize = maxSize;
		}

		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			DirectBitmap outputImage = Resize(image);
			image.Dispose();
			image = outputImage;
		}

		private readonly IResizingAlgorithm _resizingAlgorithm;
		private readonly Size _maxSize;

		private DirectBitmap Resize(DirectBitmap inputImage)
		{
			Size newSize = _resizingAlgorithm.ComputeNewSize(inputImage.Bitmap.Size);
			newSize.Width = Math.Clamp(newSize.Width, 1, _maxSize.Width);
			newSize.Height = Math.Clamp(newSize.Height, 1, _maxSize.Height);
			var outputImage = new DirectBitmap(newSize.Width, newSize.Height);
			using (var graphics = Graphics.FromImage(outputImage.Bitmap))
			{
				graphics.DrawImage(inputImage.Bitmap, 0, 0, outputImage.Width, outputImage.Height);
			}
			return outputImage;
		}
	}
}
