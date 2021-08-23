using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for median filter.
	/// </summary>
	internal sealed partial class MedianFilterSettings : FilterSettings<MedianSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="MedianFilterSettings"/>.
		/// </summary>
		public MedianFilterSettings()
		{
			InitializeComponent();
			_radiusInput.Minimum = MedianSettingsModel.MinRadius;
			_radiusInput.Maximum = MedianSettingsModel.MaxRadius;
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			int radius = (int)_radiusInput.Value;
			var filter = new MedianFilter(radius);
			yield return filter;
		}

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_radiusInput.Value = DisplayedModel.Radius;
		}

		/// <summary>
		/// Updates the radius according to the input.
		/// </summary>
		private void RadiusInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Radius = (int)_radiusInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
