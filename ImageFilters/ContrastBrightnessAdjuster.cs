﻿using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ContrastBrightnessAdjuster : IColorAdjuster
	{
		public const int MinChange = -255;
		public const int MaxChange = 255;
	
		public ContrastBrightnessAdjuster(int contrastChange, int brightnessChange)
		{
			ArgChecker.InRangeInclusive(contrastChange, nameof(contrastChange), MinChange, MaxChange);
			ArgChecker.InRangeInclusive(brightnessChange, nameof(brightnessChange), MinChange, MaxChange);
			_contrastFactor = ComputeContrastFactor(contrastChange);
			_brightnessChange = brightnessChange;
		}

		public Color Adjust(Color color)
		{
			return Color.FromArgb(
				color.A,
				Utils.ClampColorChannel(AdjustChannel(color.R)),
				Utils.ClampColorChannel(AdjustChannel(color.G)),
				Utils.ClampColorChannel(AdjustChannel(color.B))
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