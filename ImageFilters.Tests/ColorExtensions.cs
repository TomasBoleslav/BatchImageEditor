using System;
using System.Drawing;

namespace ImageFilters.Tests
{
	internal static class ColorExtensions
	{
		public static Color Multiply(this Color color, int factor)
		{
			return Color.FromArgb(
				Math.Clamp(color.A * factor, 0, byte.MaxValue),
				Math.Clamp(color.R * factor, 0, byte.MaxValue),
				Math.Clamp(color.G * factor, 0, byte.MaxValue),
				Math.Clamp(color.B * factor, 0, byte.MaxValue)
				);
		}

		public static Color Add(this Color color, Color other)
		{
			return Color.FromArgb(
				Math.Clamp(color.A + other.A, 0, byte.MaxValue),
				Math.Clamp(color.R + other.R, 0, byte.MaxValue),
				Math.Clamp(color.G + other.G, 0, byte.MaxValue),
				Math.Clamp(color.B + other.B, 0, byte.MaxValue)
				);
		}

		public static Color ToColor(this int value)
		{
			return Color.FromArgb(value, value, value);
		}

		public static Color WithAlpha(this Color color, int alpha)
		{
			return Color.FromArgb(alpha, color);
		}
	}
}
