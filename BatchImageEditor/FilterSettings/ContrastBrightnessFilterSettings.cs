using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for adjusting contrast and brightness.
	/// </summary>
	internal sealed partial class ContrastBrightnessFilterSettings : FilterSettings<ContrastBrightnessFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="ContrastBrightnessFilterSettings"/>.
		/// </summary>
		public ContrastBrightnessFilterSettings()
		{
			InitializeComponent();
			InitializeDeltaInputField(_contrastInput);
			InitializeDeltaInputField(_brightnessInput);
		}

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_contrastInput.Value = DisplayedModel.ContrastDelta;
			_brightnessInput.Value = DisplayedModel.BrightnessDelta;
		}

		/// <summary>
		/// Initializes an input field for changing contrast or brightness.
		/// </summary>
		/// <param name="inputField">An input field to initialize.</param>
		private static void InitializeDeltaInputField(NumericUpDown inputField)
		{
			inputField.Minimum = ContrastBrightnessFilterSettingsModel.MinDelta;
			inputField.Maximum = ContrastBrightnessFilterSettingsModel.MaxDelta;
		}

		/// <summary>
		/// Updates the contrast based on the user's input.
		/// </summary>
		private void ContrastInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.ContrastDelta = (int)_contrastInput.Value;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the brightness based on the user's input.
		/// </summary>
		private void BrightnessInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.BrightnessDelta = (int)_brightnessInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
