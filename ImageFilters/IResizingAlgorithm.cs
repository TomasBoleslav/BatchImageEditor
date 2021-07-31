using System.Drawing;

namespace ImageFilters
{
	public interface IResizingAlgorithm
	{
		Size ComputeNewSize(Size oldSize);
	}
}
