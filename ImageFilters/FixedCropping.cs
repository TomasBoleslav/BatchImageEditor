using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class FixedCropping : ICroppingAlgorithm
	{
		public FixedCropping(Rectangle fixedCropArea)
		{
			ArgChecker.Positive(fixedCropArea.Width, nameof(fixedCropArea.Width));
			ArgChecker.Positive(fixedCropArea.Height, nameof(fixedCropArea.Height));
			_fixedCropArea = fixedCropArea;
		}

		public Rectangle ComputeCropArea(Size size)
		{
			return _fixedCropArea;
		}

		private readonly Rectangle _fixedCropArea;
	}
}
