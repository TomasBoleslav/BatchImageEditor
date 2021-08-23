using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for image rotation.
	/// </summary>
	internal sealed partial class RotationFilterSettings : FilterSettings<RotationFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="RotationFilterSettings"/>.
		/// </summary>
		public RotationFilterSettings()
		{
			InitializeComponent();
			_angleInput.DecimalPlaces = AngleDecimalPlaces;
			_angleInput.Minimum = (decimal)RotationFilterSettingsModel.MinAngle;
			_angleInput.Maximum = (decimal)RotationFilterSettingsModel.MaxAngle;
		}

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_angleInput.Value = (decimal)DisplayedModel.Angle;
		}

		/// <summary>
		/// Updates the angle according to the input.
		/// </summary>
		private void AngleInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.Angle = (float)_angleInput.Value;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Opens a color dialog for the user to select a background color.
		/// </summary>
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
