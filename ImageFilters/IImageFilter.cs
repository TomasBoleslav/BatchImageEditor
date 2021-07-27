
namespace ImageFilters
{
	// TOOD: Apply(ref DirectBitmap) instead of returning?
	public interface IImageFilter
	{
		/// <summary>
		/// Applies the image filter on a <see cref="DirectBitmap"/>.
		/// </summary>
		/// <remarks>
		/// In some cases the filter is applied directly on the given bitmap and the same bitmap is returned.
		/// In other cases a new bitmap is created and returned as a result, in which case the old bitmap is disposed.
		/// </remarks>
		/// <param name="directBitmap"></param>
		/// <returns></returns>
		DirectBitmap Apply(DirectBitmap directBitmap);
	}
}
