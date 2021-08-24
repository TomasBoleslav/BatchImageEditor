
namespace ImageFilters
{
	/// <summary>
	/// A linear image filter with a custom kernel matrix.
	/// </summary>
	public sealed class CustomLinearFilter : LinearFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="CustomLinearFilter"/> with a custom kernel matrix.
		/// </summary>
		/// <param name="kernel">A kernel matrix to use. It must be rectangular with an odd number of rows and columns.</param>
		public CustomLinearFilter(float[][] kernel)
		{
			SetKernel(kernel);
		}
	}
}
