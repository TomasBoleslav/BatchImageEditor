using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that rotates an image.
	/// </summary>
	public sealed class RotationFilter : IImageFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="RotationFilter"/> that will rotate images by the given angle.
		/// </summary>
		/// <param name="angleDeg">The rotation angle in degrees.</param>
		/// <param name="backgroundColor">The background color to use around adges.</param>
		public RotationFilter(float angleDeg, Color backgroundColor)
		{
			_angleDeg = angleDeg;
			_backgroundColor = backgroundColor;
		}

		/// <inheritdoc/>
		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			DirectBitmap outputImage = RotateImage(image);
			image.Dispose();
			image = outputImage;
		}
		
		private readonly float _angleDeg;
		private readonly Color _backgroundColor;

		/// <summary>
		/// Rotates a <see cref="PointF"/> around a center point by the given amount.
		/// </summary>
		/// <param name="point">A point to rotate.</param>
		/// <param name="center">A center point around which the point will be rotated.</param>
		/// <param name="angleDeg">A rotation angle in degrees.</param>
		/// <returns>The rotated point.</returns>
		private static PointF RotatePointF(PointF point, PointF center, float angleDeg)
		{
			double angleRad = Math.PI * angleDeg / 180;
			double sin = Math.Sin(angleRad);
			double cos = Math.Cos(angleRad);
			PointF shiftedToCenter = new PointF
			{
				X = point.X - center.X,
				Y = point.Y - center.Y
			};
			PointF rotated = new PointF
			{
				X = (float)(shiftedToCenter.X * cos - shiftedToCenter.Y * sin),
				Y = (float)(shiftedToCenter.Y * sin + shiftedToCenter.X * cos)
			};
			PointF shiftedBack = new PointF
			{
				X = rotated.X + center.X,
				Y = rotated.Y + center.Y
			};
			return shiftedBack;
		}

		/// <summary>
		/// Rotates an image.
		/// </summary>
		/// <param name="inputImage">An image to rotate.</param>
		/// <returns>The rotated image.</returns>
		private DirectBitmap RotateImage(DirectBitmap inputImage)
		{
			Size outputSize = ComputeResultSize(inputImage.Bitmap.Size);
			var outputImage = new DirectBitmap(outputSize.Width, outputSize.Height);
			using (var graphics = Graphics.FromImage(outputImage.Bitmap))
			{
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (_backgroundColor != Color.Transparent)
				{
					graphics.Clear(_backgroundColor);
				}
				graphics.TranslateTransform(outputImage.Width / 2f, outputImage.Height / 2f);
				graphics.RotateTransform(_angleDeg);
				graphics.TranslateTransform(-inputImage.Width / 2f, -inputImage.Height / 2f);
				graphics.DrawImage(inputImage.Bitmap, 0, 0);
			}
			return outputImage;
		}
		
		/// <summary>
		/// Computes the size of the output image to contain the whole rotated image without cutting off the edges.
		/// </summary>
		/// <param name="inputSize">The size of an input image.</param>
		/// <returns>The size of the output image to contain the whole rotated input image.</returns>
		private Size ComputeResultSize(Size inputSize)
		{
			PointF origin = new PointF(0f, 0f);
			PointF[] bounds = new PointF[]
			{
				RotatePointF(new PointF(0f, 0f), origin, _angleDeg),
				RotatePointF(new PointF(inputSize.Width, 0f), origin, _angleDeg),
				RotatePointF(new PointF(inputSize.Width, inputSize.Height), origin, _angleDeg),
				RotatePointF(new PointF(0f, inputSize.Height), origin, _angleDeg),
			};
			float minX = bounds.Min(point => point.X);
			float maxX = bounds.Max(point => point.X);
			float minY = bounds.Min(point => point.Y);
			float maxY = bounds.Max(point => point.Y);
			return new Size
			{
				Width = (int)Math.Ceiling(maxX - minX),
				Height = (int)Math.Ceiling(maxY - minY),
			};
		}
	}
}
