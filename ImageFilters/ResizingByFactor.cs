using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ResizingByFactor : IResizingAlgorithm
	{
		public ResizingByFactor(float widthFactor, float heightFactor)
		{
			ArgChecker.Positive(widthFactor, nameof(widthFactor));
			ArgChecker.Positive(heightFactor, nameof(heightFactor));
			_widthFactor = widthFactor;
			_heightFactor = heightFactor;
		}

		public Size ComputeNewSize(Size oldSize)
		{
			return new Size
			{
				Width = (int)(oldSize.Width * _widthFactor),
				Height = (int)(oldSize.Height * _heightFactor)
			};
		}

		private readonly float _widthFactor;
		private readonly float _heightFactor;
	}
}
