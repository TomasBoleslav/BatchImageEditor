using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class FixedCropping : ICroppingAlgorithm
	{
		public FixedCropping(Rectangle fixedCropArea)
		{
			ArgChecker.Nonnegative(fixedCropArea.X, nameof(fixedCropArea.X));
			ArgChecker.Nonnegative(fixedCropArea.Y, nameof(fixedCropArea.Y));
			ArgChecker.Nonnegative(fixedCropArea.Width, nameof(fixedCropArea.Width));
			ArgChecker.Nonnegative(fixedCropArea.Height, nameof(fixedCropArea.Height));
			_fixedCropArea = fixedCropArea;
		}

		public Rectangle ComputeCropArea(Size size)
		{
			return new Rectangle
			{
				X = _fixedCropArea.X,
				Y = _fixedCropArea.Y,
				Width = Math.Min(_fixedCropArea.Width, size.Width - _fixedCropArea.X),
				Height = Math.Min(_fixedCropArea.Height, size.Height - _fixedCropArea.Y)
			};
		}

		private readonly Rectangle _fixedCropArea;
	}
}
