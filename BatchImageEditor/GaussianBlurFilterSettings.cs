using System;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for Gaussian blur.
	/// </summary>
	internal sealed partial class GaussianBlurFilterSettings : FilterSettings<GaussianBlurFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="GaussianBlurFilterSettings"/>.
		/// </summary>
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

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_radiusInput.Value = DisplayedModel.Radius;
			_sigmaInput.Value = (decimal)DisplayedModel.Sigma;
		}

		private const int SigmaDecimalPlaces = 1;
		private const double SigmaIncrement = 1.0;

		/// <summary>
		/// Updates the radius according to the input.
		/// </summary>
		private void RadiusInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Radius = (int)_radiusInput.Value;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the sigma value according to the input.
		/// </summary>
		private void SigmaInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Sigma = (double)_sigmaInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
