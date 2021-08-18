using ImageFilters;
using System.Collections.Generic;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class ContrastBrightnessFilterSettingsModel : IFilterSettingsModel<ContrastBrightnessFilterSettingsModel>
	{
		public const int MaxDelta = ContrastBrightnessAdjuster.MaxChange;
		public const int MinDelta = ContrastBrightnessAdjuster.MinChange;
		public const int DefaultDelta = 0;

		public ContrastBrightnessFilterSettingsModel()
		{
			ContrastDelta = DefaultDelta;
			BrightnessDelta = DefaultDelta;
		}

		public int ContrastDelta
		{
			get
			{
				return _contrastDelta;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_contrastDelta = value;
			}
		}

		public int BrightnessDelta
		{
			get
			{
				return _brightnessDelta;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_brightnessDelta = value;
			}
		}

		public ContrastBrightnessFilterSettingsModel Copy()
		{
			return new ContrastBrightnessFilterSettingsModel
			{
				ContrastDelta = ContrastDelta,
				BrightnessDelta = BrightnessDelta
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			var colorAdjuster = new ContrastBrightnessAdjuster(ContrastDelta, BrightnessDelta);
			yield return new ColorAdjustingFilter(colorAdjuster);
		}

		private int _contrastDelta;
		private int _brightnessDelta;
	}
}
