using System;
using System.Drawing;

namespace ImageFilters
{
	public class RgbColorAdjustment : IColorAdjustment
	{
		public RgbColorAdjustment(int dR, int dG, int dB)
		{
			_dR = dR;
			_dG = dG;
			_dB = dB;
		}

		public Color Apply(Color color)
		{
			int outR = color.R + _dR;
			int outG = color.G + _dG;
			int outB = color.B + _dB;
			return Utils.CreateColorByClamping(outR, outG, outB);
		}

		private readonly int _dR;
		private readonly int _dG;
		private readonly int _dB;
	}
}
