using System.Collections.Generic;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of color channels filter settings.
	/// </summary>
	internal sealed class ColorChannelsFilterSettingsModel : IFilterSettingsModel<ColorChannelsFilterSettingsModel>
	{
		public const int MinDelta = -255;
		public const int MaxDelta = 255;
		public const int DefaultDelta = 0;

		/// <summary>
		/// Creates an instance of <see cref="ColorChannelsFilterSettingsModel"/> with default settings.
		/// </summary>
		public ColorChannelsFilterSettingsModel()
		{
			DeltaR = DefaultDelta;
			DeltaG = DefaultDelta;
			DeltaB = DefaultDelta;
		}

		/// <summary>
		/// Gets or sets a change in the red channel.
		/// </summary>
		public int DeltaR
		{
			get
			{
				return _deltaR;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_deltaR = value;
			}
		}

		/// <summary>
		/// Gets or sets a change in the green channel.
		/// </summary>
		public int DeltaG
		{
			get
			{
				return _deltaG;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_deltaG = value;
			}
		}

		/// <summary>
		/// Gets or sets a change in the blue channel.
		/// </summary>
		public int DeltaB
		{
			get
			{
				return _deltaB;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_deltaB = value;
			}
		}

		/// <inheritdoc/>
		public ColorChannelsFilterSettingsModel Copy()
		{
			return new ColorChannelsFilterSettingsModel
			{
				DeltaR = DeltaR,
				DeltaG = DeltaG,
				DeltaB = DeltaB
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			var colorAdjuster = new RgbColorAdjuster(DeltaR, DeltaG, DeltaB);
			yield return new ColorAdjustingFilter(colorAdjuster);
		}

		private int _deltaR;
		private int _deltaG;
		private int _deltaB;
	}
}
