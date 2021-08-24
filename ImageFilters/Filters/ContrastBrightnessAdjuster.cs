using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// A color adjuster for changing contrast and brightness.
	/// </summary>
	public sealed class ContrastBrightnessAdjuster : IColorAdjuster
	{
		public const int MinChange = -255;
		public const int MaxChange = 255;

		/// <summary>
		/// Creates an instance of <see cref="ContrastBrightnessAdjuster"/> with values to change contrast and brightness.
		/// </summary>
		/// <param name="contrastChange">A change in contrast.</param>
		/// <param name="brightnessChange">A change in brightness.</param>
		public ContrastBrightnessAdjuster(int contrastChange, int brightnessChange)
		{
			ArgChecker.InRangeInclusive(contrastChange, nameof(contrastChange), MinChange, MaxChange);
			ArgChecker.InRangeInclusive(brightnessChange, nameof(brightnessChange), MinChange, MaxChange);
			_contrastFactor = ComputeContrastFactor(contrastChange);
			_brightnessChange = brightnessChange;
		}

		/// <inheritdoc/>
		public Color Adjust(Color color)
		{
			return Color.FromArgb(
				color.A,
				ColorHelper.ClampColorChannel(ComputeChannel(color.R)),
				ColorHelper.ClampColorChannel(ComputeChannel(color.G)),
				ColorHelper.ClampColorChannel(ComputeChannel(color.B))
				);
		}

		/// <summary>
		/// Computes a color channel by changing its contrast and brightness.
		/// </summary>
		/// <param name="channel">A color channel.</param>
		/// <returns>A new color channel.</returns>
		private float ComputeChannel(byte channel)
		{
			return _contrastFactor * (channel - ChannelHalf) + ChannelHalf + _brightnessChange;
		}

		/// <summary>
		/// Computes a factor for changing the contrast.
		/// </summary>
		/// <param name="contrastChange">A change in contrast.</param>
		/// <returns>A factor for changing the contrast.</returns>
		private static float ComputeContrastFactor(int contrastChange)
		{
			// minimum 0.0 (contrastChange == -255), maximum = 129.5 (contrastChange == 255)
			return 259 * (contrastChange + 255) / (float)(255 * (259 - contrastChange));
		}

		private readonly float _contrastFactor;
		private readonly int _brightnessChange;
		private const byte ChannelHalf = 128;
	}
}
