using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	// TODO: bad name
	public sealed class OverImageFilter : IImageFilter
	{
		public OverImageFilter(DirectBitmap imageToDrawOver, ImagePosition position, int dx, int dy)
		{
			ArgChecker.NotNull(imageToDrawOver, nameof(imageToDrawOver));
			_imageOver = imageToDrawOver;
			_position = position;
			_dx = dx;
			_dy = dy;
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ArgChecker.NotNull(inputBitmap, nameof(inputBitmap));
			Point destination = ComputeDestinationOfImageToDraw(inputBitmap);
			using var graphics = Graphics.FromImage(inputBitmap.Bitmap);
			graphics.DrawImage(_imageOver.Bitmap, destination);
		}

		private readonly DirectBitmap _imageOver;
		private readonly ImagePosition _position;
		private readonly int _dx;
		private readonly int _dy;

		private Point ComputeDestinationOfImageToDraw(DirectBitmap inputBitmap)
		{
			return _position switch
			{
				ImagePosition.TopLeft => new Point
				{
					X = _dx,
					Y = _dy
				},
				ImagePosition.TopRight => new Point
				{
					X = inputBitmap.Width - _imageOver.Width - _dx,
					Y = _dy
				},
				ImagePosition.BottomLeft => new Point
				{
					X = _dx,
					Y = inputBitmap.Height - _imageOver.Height - _dy
				},
				ImagePosition.BottomRight => new Point
				{
					X = inputBitmap.Width - _imageOver.Width - _dx,
					Y = inputBitmap.Height - _imageOver.Height - _dy
				},
				ImagePosition.Middle => new Point
				{
					X = (inputBitmap.Width - _imageOver.Width) / 2 + _dx,
					Y = (inputBitmap.Height - _imageOver.Height) / 2 + _dy
				},
				_ => Point.Empty,
			};
		}
	}
}
