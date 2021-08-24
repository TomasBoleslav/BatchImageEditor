
namespace ImageFilters
{
	/// <summary>
	/// A separable filter with a custom vectors.
	/// </summary>
	public sealed class CustomSeparableFilter : SeparableFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="CustomSeparableFilter"/> with given vectors.
		/// </summary>
		/// <param name="horizontalVector">A horizontal vector of the separable filter.</param>
		/// <param name="verticalVector">A vertical vector of the separable filter.</param>
		public CustomSeparableFilter(float[] horizontalVector, float[] verticalVector)
		{
			SetVectors(horizontalVector, verticalVector);
		}
	}
}
