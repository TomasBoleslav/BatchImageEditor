using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
	public class RgbAdjustingFilter : ColorAdjustingFilter
	{
		public RgbAdjustingFilter(int dR, int dG, int dB)
		{
			_dR = dR;
			_dG = dG;
			_dB = dB;
		}

		protected override Color AdjustColor(Color color)
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
