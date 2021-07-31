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
			return Utils.CreateColorByClamping(
				color.R + _dR,
				color.G + _dG,
				color.B + _dB
				);
		}

		private readonly int _dR;
		private readonly int _dG;
		private readonly int _dB;
	}
}
