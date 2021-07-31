using System.Drawing;

namespace ImageFilters
{
	public sealed class ContrastBrightnessAdjuster : IColorAdjuster
	{
		public const int MinChange = -255;
		public const int MaxChange = 255;
	
		public ContrastBrightnessAdjuster(int contrastChange, int brightnessChange)
		{
			Thrower.ThrowIfNotInRange(contrastChange, nameof(contrastChange), MinChange, MaxChange);
			Thrower.ThrowIfNotInRange(brightnessChange, nameof(brightnessChange), MinChange, MaxChange);
			_contrastFactor = ComputeContrastFactor(contrastChange);
			_brightnessChange = brightnessChange;
		}

		public Color Adjust(Color color)
		{
			return Utils.CreateColorByClamping(
				AdjustChannel(color.R),
				AdjustChannel(color.G),
				AdjustChannel(color.B)
				);
		}

		private float AdjustChannel(byte channel)
		{
			return _contrastFactor * (channel - ChannelHalf) + ChannelHalf + _brightnessChange;
		}

		private static float ComputeContrastFactor(int contrastChange)
		{
			// Minimum factor = 0.0 (contrast change = -255), maximum factor = 129.5 (contrast change = 255)
			return 259 * (contrastChange + 255) / (float)(255 * (259 - contrastChange));
		}

		private readonly float _contrastFactor;
		private readonly int _brightnessChange;
		private const byte ChannelHalf = 128;
	}
}
