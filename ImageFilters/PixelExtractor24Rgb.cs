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
				buffer[index + 2],
				buffer[index + 1],
				buffer[index]);
		}

		public void SetPixel(int index, Color color)
		{
			buffer[index + 2] = color.R;
			buffer[index + 1] = color.G;
			buffer[index] = color.B;
		}

		private readonly byte[] buffer;
	}
}
