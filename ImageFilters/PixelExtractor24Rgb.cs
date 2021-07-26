using System.Drawing;

namespace ImageFilters
{
	internal class PixelExtractor24Rgb : IPixelExtractor
	{
		public PixelExtractor24Rgb(byte[] buffer)
		{
			this.buffer = buffer;
		}

		public Color GetPixel(int index)
		{
			return Color.FromArgb(
				buffer[index],
				buffer[index + 1],
				buffer[index + 2]);
		}

		public void SetPixel(int index, Color color)
		{
			buffer[index] = color.R;
			buffer[index + 1] = color.G;
			buffer[index + 2] = color.B;
		}

		private readonly byte[] buffer;
	}
}
