using System.Drawing;

namespace ImageFilters
{
	internal unsafe interface IPixelColorExtractor
	{
		Color GetColor(byte* pixelPointer);

		void SetColor(byte* pixelPointer, Color color);
	}
}
