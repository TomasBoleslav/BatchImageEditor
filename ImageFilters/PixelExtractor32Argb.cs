using System.Drawing;

namespace ImageFilters
{
	internal class PixelExtractor32Argb : IPixelExtractor
	{
		public PixelExtractor32Argb(byte[] buffer)
		{
			this.buffer = buffer;
		}

		public Color GetPixel(int index)
		{
			return Color.FromArgb(
				buffer[index],
				buffer[index + 1],
				buffer[index + 2],
				buffer[index + 3]);
		}

		public void SetPixel(int index, Color color)
		{
			// TODO: test that the order is correct
			buffer[index] = color.A;
			buffer[index + 1] = color.R;
			buffer[index + 2] = color.G;
			buffer[index + 3] = color.B;
		}

		private readonly byte[] buffer;
	}
}
