using System.Drawing;

namespace ImageFilters
{
	public sealed class FixedResizing : IResizingAlgorithm
	{
		public FixedResizing(int width, int height)
		{
			Ensure.Positive(width, nameof(width));
			Ensure.Positive(height, nameof(height));
			_fixedNewSize = new Size(width, height);
		}

		public Size ComputeNewSize(Size oldSize)
		{
			return _fixedNewSize;
		}

		private readonly Size _fixedNewSize;
	}
}
