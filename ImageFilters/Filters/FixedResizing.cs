using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An algorithm for resizing an image that returns a fixed size in pixels for every image.
	/// </summary>
	public sealed class FixedResizing : IResizingAlgorithm
	{
		/// <summary>
		/// Creates an instance of <see cref="FixedResizing"/> that will return the given size for every image.
		/// </summary>
		/// <param name="width">A width to resize to.</param>
		/// <param name="height">A height to resize to.</param>
		public FixedResizing(int width, int height)
		{
			ArgChecker.Positive(width, nameof(width));
			ArgChecker.Positive(height, nameof(height));
			_fixedNewSize = new Size(width, height);
		}

		/// <inheritdoc/>
		public Size ComputeNewSize(Size oldSize)
		{
			return _fixedNewSize;
		}

		private readonly Size _fixedNewSize;
	}
}
