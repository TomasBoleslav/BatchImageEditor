using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class ContrastBrightnessFilterSettings : FilterSettings<ContrastBrightnessFilterSettingsModel>
	{
		public ContrastBrightnessFilterSettings()
		{
			InitializeComponent();
			InitializeDeltaInputField(_contrastInput);
			InitializeDeltaInputField(_brightnessInput);
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_contrastInput.Value = DisplayedModel.ContrastDelta;
			_brightnessInput.Value = DisplayedModel.BrightnessDelta;
		}

		private static void InitializeDeltaInputField(NumericUpDown inputField)
		{
			inputField.Minimum = ContrastBrightnessFilterSettingsModel.MinDelta;
			inputField.Maximum = ContrastBrightnessFilterSettingsModel.MaxDelta;
		}

		private void ContrastInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.ContrastDelta = (int)_contrastInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private void BrightnessInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.BrightnessDelta = (int)_brightnessInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
