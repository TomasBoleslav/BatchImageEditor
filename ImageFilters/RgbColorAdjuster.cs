using System;
using System.Drawing;

namespace ImageFilters
{
	public sealed class RgbColorAdjuster : IColorAdjuster
	{
		public RgbColorAdjuster(int dR, int dG, int dB)
		{
			_dR = dR;
			_dG = dG;
			_dB = dB;
		}

		public Color Adjust(Color color)
		{
			return Color.FromArgb(
				color.A,
				Math.Clamp(color.R + _dR, 0, 255),
				Math.Clamp(color.G + _dG, 0, 255),
				Math.Clamp(color.B + _dB, 0, 255)
				);
		}

		private readonly int _dR;
		private readonly int _dG;
		private readonly int _dB;
	}
}
