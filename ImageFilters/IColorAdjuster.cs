using System.Drawing;

namespace ImageFilters
{
	public interface IColorAdjuster
	{
		Color Adjust(Color color);
	}
}
