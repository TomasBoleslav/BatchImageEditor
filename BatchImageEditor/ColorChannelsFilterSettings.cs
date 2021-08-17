using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class ColorChannelsFilterSettings : FilterSettings<ColorChannelsFilterSettingsModel>
	{
		public ColorChannelsFilterSettings()
		{
			InitializeComponent();
			InitializeDeltaInputField(_deltaRInput);
			InitializeDeltaInputField(_deltaGInput);
			InitializeDeltaInputField(_deltaBInput);
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_deltaRInput.Value = DisplayedModel.DeltaR;
			_deltaGInput.Value = DisplayedModel.DeltaG;
			_deltaBInput.Value = DisplayedModel.DeltaB;
		}

		private static void InitializeDeltaInputField(NumericUpDown inputField)
		{
			inputField.Minimum = ColorChannelsFilterSettingsModel.MinDelta;
			inputField.Maximum = ColorChannelsFilterSettingsModel.MaxDelta;
		}

		private void DeltaRInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaR = (int)_deltaRInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private void DeltaGInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaG = (int)_deltaGInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private void DeltaBInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaB = (int)_deltaBInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
