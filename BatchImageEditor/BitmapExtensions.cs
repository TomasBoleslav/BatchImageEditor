using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BatchImageEditor
{
	public static partial class BitmapExtensions
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

		public static Bitmap Resize(this Bitmap bitmap, float factor)
		{
			int newWidth = Math.Max((int)(factor * bitmap.Width), 1);
			int newHeight = Math.Max((int)(factor * bitmap.Height), 1);
			return bitmap.Resize(newWidth, newHeight);
		}

		public static Bitmap Fit(this Bitmap bitmap, int width, int height)
		{
			int minWidth = Math.Min(width, bitmap.Width);
			int minHeight = Math.Min(height, bitmap.Height);
			float widthFactor = minWidth / (float)bitmap.Width;
			float heightFactor = minHeight / (float)bitmap.Height;
			float resizeFactor = Math.Min(widthFactor, heightFactor);
			return bitmap.Resize(resizeFactor);
		}

		public static Bitmap Fit(this Bitmap bitmap, Size size)
		{
			return bitmap.Fit(size.Width, size.Height);
		}

		public static Bitmap Copy(this Bitmap bitmap)
		{
			var result = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
			using (Graphics graphics = Graphics.FromImage(result))
			{
				graphics.DrawImage(bitmap, Point.Empty);
			}
			return result;
		}

		public static Bitmap Reformat(this Bitmap bitmap, PixelFormat newPixelFormat)
		{
			var result = new Bitmap(bitmap.Width, bitmap.Height, newPixelFormat);
			using (Graphics graphics = Graphics.FromImage(result))
			{
				graphics.DrawImage(bitmap, Point.Empty);
			}
			return result;
		}
	}
}
