using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An algorithm for cropping an image with a fixed area of cropping that.
	/// </summary>
	public sealed class FixedCropping : ICroppingAlgorithm
	{
		/// <summary>
		/// Creates an instance of <see cref="FixedCropping"/> with the given fixed area for cropping.
		/// </summary>
		/// <param name="fixedCropArea">A fixed area the image will be cropped from.</param>
		public FixedCropping(Rectangle fixedCropArea)
		{
			ArgChecker.Nonnegative(fixedCropArea.X, nameof(fixedCropArea.X));
			ArgChecker.Nonnegative(fixedCropArea.Y, nameof(fixedCropArea.Y));
			ArgChecker.Nonnegative(fixedCropArea.Width, nameof(fixedCropArea.Width));
			ArgChecker.Nonnegative(fixedCropArea.Height, nameof(fixedCropArea.Height));
			_fixedCropArea = fixedCropArea;
		}

		/// <inheritdoc/>
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
