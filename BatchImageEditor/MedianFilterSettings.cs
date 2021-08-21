﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class MedianFilterSettings : FilterSettings<MedianSettingsModel>
	{
		public MedianFilterSettings()
		{
			InitializeComponent();
			_radiusInput.Minimum = MedianSettingsModel.MinRadius;
			_radiusInput.Maximum = MedianSettingsModel.MaxRadius;
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			// TODO: maybe radius can be hacked by user, try it
			int radius = (int)_radiusInput.Value;
			var filter = new MedianFilter(radius);
			yield return filter;
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_radiusInput.Value = DisplayedModel.Radius;
		}

		private void RadiusInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Radius = (int)_radiusInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}