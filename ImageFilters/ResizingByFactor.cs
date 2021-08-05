using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ResizingByFactor : IResizingAlgorithm
	{
		public ResizingByFactor(float factorWidth, float factorHeight)
		{
			ArgChecker.Positive(factorWidth, nameof(factorWidth));
			_factorWidth = factorWidth;
			_factorHeight = factorHeight;
		}

		public Size ComputeNewSize(Size oldSize)
		{
			return new Size
			{
				Width = (int)(oldSize.Width * _factorWidth),
				Height = (int)(oldSize.Height * _factorHeight)
			};
		}

		private readonly float _factorWidth;
		private readonly float _factorHeight;
	}
}
