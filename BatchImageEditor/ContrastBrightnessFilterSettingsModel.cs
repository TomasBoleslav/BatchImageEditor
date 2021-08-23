using ImageFilters;
using System.Collections.Generic;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of contrast and brightness filter settings.
	/// </summary>
	internal sealed class ContrastBrightnessFilterSettingsModel : IFilterSettingsModel<ContrastBrightnessFilterSettingsModel>
	{
		public const int MaxDelta = ContrastBrightnessAdjuster.MaxChange;
		public const int MinDelta = ContrastBrightnessAdjuster.MinChange;
		public const int DefaultDelta = 0;

		/// <summary>
		/// Creates an instance of <see cref="ContrastBrightnessFilterSettingsModel"/> with default settings.
		/// </summary>
		public ContrastBrightnessFilterSettingsModel()
		{
			ContrastDelta = DefaultDelta;
			BrightnessDelta = DefaultDelta;
		}

		/// <summary>
		/// Gets or sets a change in the contrast.
		/// </summary>
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

		/// <summary>
		/// Gets or sets a change in the brightness.
		/// </summary>
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

		/// <inheritdoc/>
		public ContrastBrightnessFilterSettingsModel Copy()
		{
			return new ContrastBrightnessFilterSettingsModel
			{
				ContrastDelta = ContrastDelta,
				BrightnessDelta = BrightnessDelta
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			var colorAdjuster = new ContrastBrightnessAdjuster(ContrastDelta, BrightnessDelta);
			yield return new ColorAdjustingFilter(colorAdjuster);
		}

		private int _contrastDelta;
		private int _brightnessDelta;
	}
}
