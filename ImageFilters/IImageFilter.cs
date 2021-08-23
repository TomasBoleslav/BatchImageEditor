
namespace ImageFilters
{
	/// <summary>
	/// An image filter that performs an operation on an image.
	/// </summary>
	public interface IImageFilter
	{
		/// <summary>
		/// Applies the filter to an image.
		/// The ownership of the image is passed to this function and the resulting image will be assigned to the given variable.
		/// </summary>
		/// <param name="image">An image the filter will be applied to.</param>
		void Apply(ref DirectBitmap image);
	}
}
