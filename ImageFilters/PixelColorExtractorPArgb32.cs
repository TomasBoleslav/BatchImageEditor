using System.Drawing;

namespace ImageFilters
{
	internal class PixelColorExtractorPArgb32 : IPixelColorExtractor
	{
		public unsafe Color GetColor(byte* pixelPointer)
		{
			return Color.FromArgb(
				alpha: pixelPointer[3],
				red: pixelPointer[2],
				green: pixelPointer[1],
				blue: pixelPointer[0]
				);
		}

		public unsafe void SetColor(byte* pixelPointer, Color color)
		{
			pixelPointer[0] = color.B;
			pixelPointer[1] = color.G;
			pixelPointer[2] = color.R;
			pixelPointer[3] = color.A;
		}
	}
}
