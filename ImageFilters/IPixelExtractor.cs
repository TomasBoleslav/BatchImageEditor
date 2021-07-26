using System.Drawing;

namespace ImageFilters
{
	internal interface IPixelExtractor
	{
		Color GetPixel(int index);

		void SetPixel(int index, Color color);
	}
}
