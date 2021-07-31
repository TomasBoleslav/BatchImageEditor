using System.Drawing;

namespace ImageFilters
{
	public interface ICroppingAlgorithm
	{
		Rectangle ComputeCropArea(Size size);
	}
}
