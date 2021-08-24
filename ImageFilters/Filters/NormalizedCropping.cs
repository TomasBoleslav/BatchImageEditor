using System;
using System.Drawing;

namespace ImageFilters
{
	/// <summary>
	/// A cropping algorithm that uses normalized coordinates to compute the final area for cropping.
	/// </summary>
	public sealed class NormalizedCropping : ICroppingAlgorithm
	{
		public const float MinNormalizedValue = 0.0f;
		public const float MaxNormalizedValue = 1.0f;

		/// <summary>
		/// Creates an instance of <see cref="NormalizedCropping"/> with the given normalized area for cropping.
		/// </summary>
		/// <param name="normalizedCropArea">A normalized area for cropping.</param>
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

		/// <inheritdoc/>
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

		/// <summary>
		/// Checks whether a value is normalized.
		/// </summary>
		/// <param name="value">A value.</param>
		/// <returns>True if the given value is normalized, otherwise false.</returns>
		private static bool IsValueNormalized(float value)
		{
			return MinNormalizedValue <= value && value <= MaxNormalizedValue;
		}

		private readonly RectangleF _normalizedCropArea;
	}
}
