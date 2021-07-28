
namespace ImageFilters
{
	public interface IImageFilter
	{
		/// <summary>
		/// Applies the image filter on a <see cref="DirectBitmap"/>.
		/// </summary>
		/// <remarks>
		/// Depending on the operation a new bitmap can be created.
		/// In that case the old bitmap is properly disposed and the reference is set to the new bitmap.
		/// Otherwise the reference remains the same and only the content of the bitmap is changed.
		/// </remarks>
		/// <param name="inputBitmap">A bitmap to which the filter will be applied.</param>
		void Apply(ref DirectBitmap inputBitmap);
	}
}
