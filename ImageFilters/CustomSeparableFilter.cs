
namespace ImageFilters
{
	public sealed class CustomSeparableFilter : SeparableFilter
	{
		public CustomSeparableFilter(float[] horizontalVector, float[] verticalVector)
		{
			SetVectors(horizontalVector, verticalVector);
		}
	}
}
