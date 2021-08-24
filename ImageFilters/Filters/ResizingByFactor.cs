using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// A resizing algorithm that computes the new size of an image by multiplying the old size by a fixed factor.
	/// </summary>
	public sealed class ResizingByFactor : IResizingAlgorithm
	{
		/// <summary>
		/// Creates an instance of <see cref="ResizingByFactor"/> with the given factors for width and height.
		/// </summary>
		/// <param name="widthFactor">A factor by which the width should be multiplied.</param>
		/// <param name="heightFactor">A factor by which the height should be multiplied.</param>
		public ResizingByFactor(float widthFactor, float heightFactor)
		{
			ArgChecker.Positive(widthFactor, nameof(widthFactor));
			ArgChecker.Positive(heightFactor, nameof(heightFactor));
			_widthFactor = widthFactor;
			_heightFactor = heightFactor;
		}

		/// <inheritdoc/>
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
