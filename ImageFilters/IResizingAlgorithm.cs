using System.Drawing;

namespace ImageFilters
{
	/// <summary>
	/// An algorithm for resizing an image.
	/// </summary>
	public interface IResizingAlgorithm
	{
		/// <summary>
		/// Computes new size of an image from its old size.
		/// </summary>
		/// <param name="oldSize">An old size of an image.</param>
		/// <returns>A new size of the image.</returns>
		Size ComputeNewSize(Size oldSize);
	}
}
