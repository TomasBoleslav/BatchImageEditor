using System.Drawing;

namespace ImageFilters
{
	public interface IImageFilter
	{
		Bitmap Apply(Bitmap bitmap);
	}
}
