using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that inserts another image.
	/// </summary>
	public sealed class ImageInsertFilter : IImageFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="ImageInsertFilter"/> that will insert the given image at the given location.
		/// </summary>
		/// <param name="imageToInsert">An image to insert.</param>
		/// <param name="placement">A placement of the image to insert.</param>
		/// <param name="dx">An X offset of the image to insert.</param>
		/// <param name="dy">An Y offset of the image to insert.</param>
		public ImageInsertFilter(Bitmap imageToInsert, ImagePlacement placement, int dx, int dy)
		{
			ArgChecker.NotNull(imageToInsert, nameof(imageToInsert));
			_imageToInsert = imageToInsert;
			_placement = placement;
			_dx = dx;
			_dy = dy;
		}

		/// <inheritdoc/>
		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			Point destination = ComputeDestinationOfImageToInsert(image);
			using var graphics = Graphics.FromImage(image.Bitmap);
			using var overlayImageCopy = new Bitmap(_imageToInsert);
			overlayImageCopy.SetResolution(graphics.DpiX, graphics.DpiY);
			graphics.DrawImage(overlayImageCopy, destination);
		}

		private readonly Bitmap _imageToInsert;
		private readonly ImagePlacement _placement;
		private readonly int _dx;
		private readonly int _dy;

		/// <summary>
		/// Computes destination of the image to insert depending on the image placement and coordinates.
		/// </summary>
		/// <param name="image">An image where the image for insertion will be inserted.</param>
		/// <returns>The location where the image for insertion should be inserted.</returns>
		private Point ComputeDestinationOfImageToInsert(DirectBitmap image)
		{
			return _placement switch
			{
				ImagePlacement.TopLeft => new Point
				{
					X = _dx,
					Y = _dy
				},
				ImagePlacement.TopRight => new Point
				{
					X = image.Width - _imageToInsert.Width - _dx,
					Y = _dy
				},
				ImagePlacement.BottomLeft => new Point
				{
					X = _dx,
					Y = image.Height - _imageToInsert.Height - _dy
				},
				ImagePlacement.BottomRight => new Point
				{
					X = image.Width - _imageToInsert.Width - _dx,
					Y = image.Height - _imageToInsert.Height - _dy
				},
				ImagePlacement.Middle => new Point
				{
					X = (image.Width - _imageToInsert.Width) / 2 + _dx,
					Y = (image.Height - _imageToInsert.Height) / 2 + _dy
				},
				_ => Point.Empty,
			};
		}
	}
}
