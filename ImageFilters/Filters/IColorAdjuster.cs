using System.Drawing;

namespace ImageFilters
{
	/// <summary>
	/// Represents an algorithm that adjusts a color.
	/// </summary>
	public interface IColorAdjuster
	{
		/// <summary>
		/// Adjusts a color.
		/// </summary>
		/// <param name="color">A color to change.</param>
		/// <returns>A new color.</returns>
		Color Adjust(Color color);
	}
}
