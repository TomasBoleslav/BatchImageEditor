
namespace ImageFilters
{
	public sealed class CustomLinearFilter : LinearFilter
	{
		public CustomLinearFilter(float[][] kernel)
		{
			SetKernel(kernel);
		}
	}
}
