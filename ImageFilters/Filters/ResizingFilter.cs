using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that resizes an image.
	/// </summary>
	public sealed class ResizingFilter : IImageFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="ResizingFilter"/> with an algorithm for resizing and
		/// the maximum size allowed for an image.
		/// </summary>
		/// <param name="resizingAlgorithm">An algorithm to use for computing new size.</param>
		/// <param name="maxSize">The maximum size allowed for an image.</param>
		public ResizingFilter(IResizingAlgorithm resizingAlgorithm, Size maxSize)
		{
			ArgChecker.Positive(maxSize.Width, nameof(maxSize.Width));
			ArgChecker.Positive(maxSize.Height, nameof(maxSize.Height));
			_resizingAlgorithm = resizingAlgorithm;
			_maxSize = maxSize;
		}

		/// <inheritdoc/>
		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			DirectBitmap outputImage = Resize(image);
			image.Dispose();
			image = outputImage;
		}

		private readonly IResizingAlgorithm _resizingAlgorithm;
		private readonly Size _maxSize;

		/// <summary>
		/// Resizes an image.
		/// </summary>
		/// <param name="inputImage">An image to resize.</param>
		/// <returns>The resized image.</returns>
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
