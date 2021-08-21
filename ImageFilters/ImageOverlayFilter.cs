﻿using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	// TODO: bad name, ImageInsertionFilter?
	public sealed class ImageOverlayFilter : IImageFilter
	{
		public ImageOverlayFilter(Bitmap overlayImage, ImagePlacement placement, int dx, int dy)
		{
			ArgChecker.NotNull(overlayImage, nameof(overlayImage));
			_overlayImage = overlayImage;
			_placement = placement;
			_dx = dx;
			_dy = dy;
		}

		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			Point destination = ComputeDestinationOfImageToDraw(image);
			using var graphics = Graphics.FromImage(image.Bitmap);
			using var overlayImageCopy = new Bitmap(_overlayImage);
			overlayImageCopy.SetResolution(graphics.DpiX, graphics.DpiY);
			graphics.DrawImage(overlayImageCopy, destination);
		}

		private readonly Bitmap _overlayImage;
		private readonly ImagePlacement _placement;
		private readonly int _dx;
		private readonly int _dy;

		private Point ComputeDestinationOfImageToDraw(DirectBitmap image)
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
					X = image.Width - _overlayImage.Width - _dx,
					Y = _dy
				},
				ImagePlacement.BottomLeft => new Point
				{
					X = _dx,
					Y = image.Height - _overlayImage.Height - _dy
				},
				ImagePlacement.BottomRight => new Point
				{
					X = image.Width - _overlayImage.Width - _dx,
					Y = image.Height - _overlayImage.Height - _dy
				},
				ImagePlacement.Middle => new Point
				{
					X = (image.Width - _overlayImage.Width) / 2 + _dx,
					Y = (image.Height - _overlayImage.Height) / 2 + _dy
				},
				_ => Point.Empty,
			};
		}
	}
}