
namespace ImageFilters
{
	public class CustomLinearFilter : LinearFilter
	{
		public CustomLinearFilter(float[][] kernel)
		{
			SetKernel(kernel);
		}
	}
}
