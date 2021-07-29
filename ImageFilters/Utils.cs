using System;
using System.Drawing;

namespace ImageFilters
{
	internal static class Utils
	{
		public static byte ClampColorChannel(float channel)
		{
			if (channel <= 0.0f)
			{
				return 0;
			}
			else if (channel >= 255.0f)
			{
				return byte.MaxValue;
			}
			return (byte)channel;
		}

		public static Color ColorFromNonnegativeNumbers(float r, float g, float b)
		{
			return Color.FromArgb(
				r < 255.0f ? (byte)r : byte.MaxValue,
				g < 255.0f ? (byte)g : byte.MaxValue,
				b < 255.0f ? (byte)b : byte.MaxValue
				);
		}

		public static Color CreateColorByClamping(float r, float g, float b)
		{
			return Color.FromArgb(
				ClampColorChannel(r),
				ClampColorChannel(g),
				ClampColorChannel(b)
				);
		}

		public static Color CreateColorByClamping(int r, int g, int b)
		{
			return Color.FromArgb(
				Math.Clamp(r, 0, byte.MaxValue),
				Math.Clamp(g, 0, byte.MaxValue),
				Math.Clamp(b, 0, byte.MaxValue)
				);
		}

		public static T[][] CreateJagged2DArray<T>(int rows, int columns)
		{
			if (rows <= 0 || columns <= 0)
			{
				throw new ArgumentException("The number of rows and columns must be greater than zero.");
			}
			T[][] array = new T[rows][];
			for (int i = 0; i < rows; i++)
			{
				array[i] = new T[columns];
			}
			return array;
		}
	}
}
