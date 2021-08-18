﻿using System;

namespace BatchImageEditor
{
	public partial class GaussianBlurFilterSettings : FilterSettings<GaussianBlurFilterSettingsModel>
	{
		public GaussianBlurFilterSettings()
		{
			InitializeComponent();
			_radiusInput.Minimum = GaussianBlurFilterSettingsModel.MinRadius;
			_radiusInput.Maximum = GaussianBlurFilterSettingsModel.MaxRadius;
			_sigmaInput.Minimum = (decimal)GaussianBlurFilterSettingsModel.MinSigma;
			_sigmaInput.Maximum = (decimal)GaussianBlurFilterSettingsModel.MaxSigma;
			_sigmaInput.DecimalPlaces = SigmaDecimalPlaces;
			_sigmaInput.Increment = (decimal)SigmaIncrement;
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_radiusInput.Value = DisplayedModel.Radius;
			_sigmaInput.Value = (decimal)DisplayedModel.Sigma;
		}

		private const int SigmaDecimalPlaces = 1;
		private const double SigmaIncrement = 1.0;

		private void RadiusInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Radius = (int)_radiusInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private void SigmaInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Sigma = (double)_sigmaInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
