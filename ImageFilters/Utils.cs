using System.Drawing;

namespace ImageFilters
{
	internal static class Utils
	{
		public static byte ClampColorChannel(float channel)
		{
			return channel < 255.0f ? (byte)channel : byte.MaxValue;
		}

		public static Color ColorFromNonnegativeNumbers(float r, float g, float b)
		{
			return Color.FromArgb(
				r < 255.0f ? (byte)r : byte.MaxValue,
				g < 255.0f ? (byte)g : byte.MaxValue,
				b < 255.0f ? (byte)b : byte.MaxValue
				);
		}
	}
}
