using System.Drawing;

namespace ImageFilters
{
	// TODO: bad name
	public sealed class OverImageFilter : IImageFilter
	{
		public OverImageFilter(DirectBitmap bitmapToDrawOver, ImagePosition position, int dx, int dy)
		{
			_bitmapOver = bitmapToDrawOver;
			_position = position;
			_dx = dx;
			_dy = dy;
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			Point destination = ComputeDestinationOfImageToDraw(inputBitmap);
			using var graphics = Graphics.FromImage(inputBitmap.Bitmap);
			graphics.DrawImage(_bitmapOver.Bitmap, destination);
		}

		private readonly DirectBitmap _bitmapOver;
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
					X = inputBitmap.Width - _bitmapOver.Width - _dx,
					Y = _dy
				},
				ImagePosition.BottomLeft => new Point
				{
					X = _dx,
					Y = inputBitmap.Height - _bitmapOver.Height - _dy
				},
				ImagePosition.BottomRight => new Point
				{
					X = inputBitmap.Width - _bitmapOver.Width - _dx,
					Y = inputBitmap.Height - _bitmapOver.Height - _dy
				},
				ImagePosition.Middle => new Point
				{
					X = (inputBitmap.Width - _bitmapOver.Width) / 2 + _dx,
					Y = (inputBitmap.Height - _bitmapOver.Height) / 2 + _dy
				},
				_ => Point.Empty,
			};
		}
	}
}
