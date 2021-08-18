using System;
using System.Drawing;

namespace ImageFilters
{
	// TODO: instead of size, pass the whole Bitmap - there can be SmartCropping that inspects the whole image to compute ideal crop area
	public sealed class NormalizedCropping : ICroppingAlgorithm
	{
		public const float MinNormalizedValue = 0.0f;
		public const float MaxNormalizedValue = 1.0f;

		public NormalizedCropping(RectangleF normalizedCropArea)
		{
			if (!IsValueNormalized(normalizedCropArea.X) ||
				!IsValueNormalized(normalizedCropArea.Y) ||
				!IsValueNormalized(normalizedCropArea.Width) ||
				!IsValueNormalized(normalizedCropArea.Height))
			{
				throw new ArgumentException(
					"Values of a normalized crop area must belong to the inclusive range of" +
					$"{MinNormalizedValue} and {MaxNormalizedValue}.",
					nameof(normalizedCropArea));
			}
			_normalizedCropArea = normalizedCropArea;
		}

		public Rectangle ComputeCropArea(Size size)
		{
			int computedX = (int)(size.Width * _normalizedCropArea.X);
			int computedY = (int)(size.Height * _normalizedCropArea.Y);
			int computedWidth = (int)(size.Width * _normalizedCropArea.Width);
			int computedHeight = (int)(size.Height * _normalizedCropArea.Height);
			return new Rectangle
			{
				X = computedX,
				Y = computedY,
				Width = Math.Min(computedWidth, size.Width - computedX),
				Height = Math.Min(computedHeight, size.Height - computedY)
			};
		}

		private static bool IsValueNormalized(float value)
		{
			return MinNormalizedValue <= value && value <= MaxNormalizedValue;
		}

		private readonly RectangleF _normalizedCropArea;
	}
}
