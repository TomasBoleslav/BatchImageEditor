using System.Collections.Generic;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class ColorChannelsFilterSettingsModel : IFilterSettingsModel<ColorChannelsFilterSettingsModel>
	{
		public const int MinDelta = -255;
		public const int MaxDelta = 255;
		public const int DefaultDelta = 0;

		public ColorChannelsFilterSettingsModel()
		{
			DeltaR = DefaultDelta;
			DeltaG = DefaultDelta;
			DeltaB = DefaultDelta;
		}

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

		public ColorChannelsFilterSettingsModel Copy()
		{
			return new ColorChannelsFilterSettingsModel
			{
				DeltaR = DeltaR,
				DeltaG = DeltaG,
				DeltaB = DeltaB
			};
		}

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
