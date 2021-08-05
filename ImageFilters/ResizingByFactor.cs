using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ResizingByFactor : IResizingAlgorithm
	{
		public ResizingByFactor(float factor)
		{
			ArgChecker.Positive(factor, nameof(factor));
			_factor = factor;
		}

		public Size ComputeNewSize(Size oldSize)
		{
			return new Size
			{
				Width = (int)(oldSize.Width * _factor),
				Height = (int)(oldSize.Height * _factor)
			};
		}

		private readonly float _factor;
	}
}
