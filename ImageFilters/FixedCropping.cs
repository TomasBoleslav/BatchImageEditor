using System.Drawing;

namespace ImageFilters
{
	public sealed class FixedCropping : ICroppingAlgorithm
	{
		public FixedCropping(Rectangle fixedCropArea)
		{
			Ensure.Positive(fixedCropArea.Width, nameof(fixedCropArea.Width));
			Ensure.Positive(fixedCropArea.Height, nameof(fixedCropArea.Height));
			_fixedCropArea = fixedCropArea;
		}

		public Rectangle ComputeCropArea(Size size)
		{
			return _fixedCropArea;
		}

		private readonly Rectangle _fixedCropArea;
	}
}
