using System.Drawing;

namespace ImageFilters
{
	public interface IColorAdjustment
	{
		Color Apply(Color color);
	}
}
