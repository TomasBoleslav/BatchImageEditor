using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for adjusting color channels.
	/// </summary>
	internal sealed partial class ColorChannelsFilterSettings : FilterSettings<ColorChannelsFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="ColorChannelsFilterSettings"/>.
		/// </summary>
		public ColorChannelsFilterSettings()
		{
			InitializeComponent();
			InitializeDeltaInputField(_deltaRInput);
			InitializeDeltaInputField(_deltaGInput);
			InitializeDeltaInputField(_deltaBInput);
		}

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_deltaRInput.Value = DisplayedModel.DeltaR;
			_deltaGInput.Value = DisplayedModel.DeltaG;
			_deltaBInput.Value = DisplayedModel.DeltaB;
		}

		/// <summary>
		/// Initializes an input field for changing a color channel.
		/// </summary>
		/// <param name="inputField">An input field to initialize.</param>
		private static void InitializeDeltaInputField(NumericUpDown inputField)
		{
			inputField.Minimum = ColorChannelsFilterSettingsModel.MinDelta;
			inputField.Maximum = ColorChannelsFilterSettingsModel.MaxDelta;
		}

		/// <summary>
		/// Updates the red channel according to the input.
		/// </summary>
		private void DeltaRInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaR = (int)_deltaRInput.Value;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the green channel according to the input.
		/// </summary>
		private void DeltaGInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaG = (int)_deltaGInput.Value;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the blue channel according to the input.
		/// </summary>
		private void DeltaBInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaB = (int)_deltaBInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
