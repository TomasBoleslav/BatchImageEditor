using System.Drawing;

namespace ImageFilters
{
	/// <summary>
	/// An algorithm for the image crop operation.
	/// </summary>
	public interface ICroppingAlgorithm
	{
		/// <summary>
		/// Computes an area from where the image should be cropped.
		/// </summary>
		/// <param name="size">A size of an image.</param>
		/// <returns>The computed crop area.</returns>
		Rectangle ComputeCropArea(Size size);
	}
}
