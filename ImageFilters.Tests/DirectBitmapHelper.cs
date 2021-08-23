using System.Drawing;

namespace ImageFilters.Tests
{
	/// <summary>
	/// A helper class containing functions related to <see cref="DirectBitmap"/>.
	/// </summary>
	internal static class DirectBitmapHelper
	{
		public static void Clear(DirectBitmap bitmap, Color color)
		{
			for (int x = 0; x < bitmap.Width; x++)
			{
				for (int y = 0; y < bitmap.Height; y++)
				{
					bitmap.SetPixel(x, y, color);
				}
			}
		}
	}
}
