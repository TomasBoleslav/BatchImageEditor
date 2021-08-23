using System;
using System.Drawing;

namespace ImageFilters
{
	/// <summary>
	/// A color adjuster for rgb color channels.
	/// </summary>
	public sealed class RgbColorAdjuster : IColorAdjuster
	{
		/// <summary>
		/// Creates an instance of <see cref="RgbColorAdjuster"/> with the given changes in color channels.
		/// </summary>
		/// <param name="dR">A change in red channel.</param>
		/// <param name="dG">A change in green channel.</param>
		/// <param name="dB">A change in blue channel.</param>
		public RgbColorAdjuster(int dR, int dG, int dB)
		{
			_dR = dR;
			_dG = dG;
			_dB = dB;
		}

		/// <inheritdoc/>
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
