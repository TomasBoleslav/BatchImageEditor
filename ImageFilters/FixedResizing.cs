using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class FixedResizing : IResizingAlgorithm
	{
		public FixedResizing(int width, int height)
		{
			ArgChecker.Positive(width, nameof(width));
			ArgChecker.Positive(height, nameof(height));
			_fixedNewSize = new Size(width, height);
		}

		public Size ComputeNewSize(Size oldSize)
		{
			return _fixedNewSize;
		}

		private readonly Size _fixedNewSize;
	}
}
