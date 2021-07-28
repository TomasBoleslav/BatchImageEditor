
namespace ImageFilters
{
	public sealed class CustomSeparableLinearFilter : SeparableLinearFilter
	{
		public CustomSeparableLinearFilter(float[] horizontalVector, float[] verticalVector)
		{
			SetVectors(horizontalVector, verticalVector);
		}
	}
}
