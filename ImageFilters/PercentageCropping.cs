using System;
using System.Drawing;

namespace ImageFilters
{
	public sealed class PercentageCropping : ICroppingAlgorithm
	{
		public PercentageCropping(RectangleF percentageCropArea)
		{
			VerifyCropAreaCorectness(percentageCropArea);
			_percentageCropArea = percentageCropArea;
		}

		public Rectangle ComputeCropArea(Size size)
		{
			return new Rectangle
			{
				X = (int)(size.Width * _percentageCropArea.X),
				Y = (int)(size.Height * _percentageCropArea.Y),
				Width = (int)(size.Width * _percentageCropArea.Width),
				Height = (int)(size.Height * _percentageCropArea.Height)
			};
		}

		private static void VerifyCropAreaCorectness(RectangleF percentageCropArea)
		{
			if (!IsPercentage(percentageCropArea.X) ||
				!IsPercentage(percentageCropArea.Y) ||
				!IsPercentage(percentageCropArea.Width) ||
				!IsPercentage(percentageCropArea.Height))
			{
				throw new ArgumentException("Percentages of a crop area must belong to the inclusive range of 0 and 1.");
			}
			Ensure.Positive(percentageCropArea.Width, nameof(percentageCropArea.Width));
			Ensure.Positive(percentageCropArea.Height, nameof(percentageCropArea.Height));
		}

		private static bool IsPercentage(float value)
		{
			return 0.0f <= value && value <= 1.0f;
		}

		private readonly RectangleF _percentageCropArea;
	}
}
