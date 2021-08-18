using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class RotationFilterSettings : FilterSettings<RotationFilterSettingsModel>
	{
		public RotationFilterSettings()
		{
			InitializeComponent();
			_angleInput.DecimalPlaces = AngleDecimalPlaces;
			_angleInput.Minimum = (decimal)RotationFilterSettingsModel.MinAngle;
			_angleInput.Maximum = (decimal)RotationFilterSettingsModel.MaxAngle;
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_angleInput.Value = (decimal)DisplayedModel.Angle;
		}

		private void AngleInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Angle = (float)_angleInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private void SelectBackgroundButton_Click(object sender, EventArgs e)
		{
			using var colorDialog = new ColorDialog();
			colorDialog.Color = DisplayedModel.BackColor;
			if (colorDialog.ShowDialog() == DialogResult.OK &&
				colorDialog.Color != DisplayedModel.BackColor)
			{
				DisplayedModel.BackColor = colorDialog.Color;
				OnDisplayedSettingsUpdated();
			}
		}

		private const int AngleDecimalPlaces = 1;
	}
}
