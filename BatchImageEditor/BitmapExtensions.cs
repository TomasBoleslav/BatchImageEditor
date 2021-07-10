using System;
using System.Collections.Generic;
using System.Drawing;

namespace BatchImageEditor
{
	static class BitmapExtensions
	{
		public static Bitmap Resize(this Bitmap bitmap, int newWidth, int newHeight)
		{
			var result = new Bitmap(newWidth, newHeight, bitmap.PixelFormat);
			using (Graphics graphics = Graphics.FromImage(result))
			{
				graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
			}
			return result;
		}

		public static Bitmap Resize(this Bitmap bitmap, double factor)
		{
			int newWidth = (int)(factor * bitmap.Width);
			int newHeight = (int)(factor * bitmap.Height);
			return bitmap.Resize(newWidth, newHeight);
		}

		public static Bitmap Fit(this Bitmap bitmap, int width, int height)
		{
			int minWidth = Math.Min(width, bitmap.Width);
			int minHeight = Math.Min(height, bitmap.Height);
			double widthFactor = minWidth / (double)bitmap.Width;
			double heightFactor = minHeight / (double)bitmap.Height;
			double resizeFactor = Math.Min(widthFactor, heightFactor);
			return bitmap.Resize(resizeFactor);
		}

		public static Bitmap Fit(this Bitmap bitmap, Size size)
		{
			return bitmap.Fit(size.Width, size.Height);
		}
	}
}
