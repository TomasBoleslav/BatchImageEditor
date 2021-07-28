using System.Drawing;

namespace ImageFilters
{
	/*
	public class ImageOverFilter : IImageFilter
	{
		public ImageOverFilter(Bitmap bitmapToDraw, ImagePosition position, int dx, int dy)
		{
			this.bitmapToDraw = bitmapToDraw;
			this.position = position;
			this.dx = dx;
			this.dy = dy;
		}

		public Bitmap Apply(Bitmap bitmap)
		{
			Point destination = GetDestination(bitmap);
			using var graphics = Graphics.FromImage(bitmap);
			graphics.DrawImage(bitmapToDraw, destination);
			return bitmap;
		}

		private Point GetDestination(Bitmap bitmap)
		{
			return position switch
			{
				ImagePosition.TopLeft => new Point
				{
					X = dx,
					Y = dy
				},
				ImagePosition.TopRight => new Point
				{
					X = bitmap.Width - bitmapToDraw.Width - dx,
					Y = dy
				},
				ImagePosition.BottomLeft => new Point
				{
					X = dx,
					Y = bitmap.Height - bitmapToDraw.Height - dy
				},
				ImagePosition.BottomRight => new Point
				{
					X = bitmap.Width - bitmapToDraw.Width - dx,
					Y = bitmap.Height - bitmapToDraw.Height - dy
				},
				ImagePosition.Middle => new Point
				{
					X = (bitmap.Width - bitmapToDraw.Width) / 2 + dx,
					Y = (bitmap.Height - bitmapToDraw.Height) / 2 + dy
				},
				_ => Point.Empty,
			};
		}

		private readonly Bitmap bitmapToDraw;
		private readonly ImagePosition position;
		private readonly int dx;
		private readonly int dy;
	}*/
}
