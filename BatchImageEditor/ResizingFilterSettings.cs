using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for resizing an image.
	/// </summary>
	internal sealed partial class ResizingFilterSettings : FilterSettings<ResizingFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="ResizingFilterSettings"/>.
		/// </summary>
		public ResizingFilterSettings()
		{
			InitializeComponent();
			_resizingTypeBoxManager = new EnumComboBoxManager<ResizingType>(_resizingTypeBox, ResizingTypesToText);
			_resizingTypeBoxManager.SelectedValueChanged += ResizingTypeBox_SelectedValueChanged;
		}
		
		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_inputFieldsEnabled = false;
			_resizingTypeBoxManager.SelectedValue = DisplayedModel.ResizingType;
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.Pixels:
					UpdateInputFieldsInPixels();
					break;
				case ResizingType.Percents:
					UpdateInputFieldsInPercents();
					break;
			}
			_inputFieldsEnabled = true;
		}

		private const int PercentageDecimalPlaces = 2;
		private const float PercentageIncrement = 0.1f;
		private readonly EnumComboBoxManager<ResizingType> _resizingTypeBoxManager;

		private bool _inputFieldsEnabled = true;

		private static readonly Dictionary<ResizingType, string> ResizingTypesToText = new()
		{
			{ ResizingType.Percents, "In percents" },
			{ ResizingType.Pixels, "In pixels" }
		};

		/// <summary>
		/// Changes an input field to hold percents.
		/// </summary>
		/// <param name="inputField">An input field to change.</param>
		/// <param name="value">A value to set.</param>
		private static void ChangeInputFieldToPercents(NumericUpDown inputField, float value)
		{
			inputField.Minimum = (decimal)ResizingFilterSettingsModel.MinPercentage;
			inputField.Maximum = (decimal)ResizingFilterSettingsModel.MaxPercentage;
			inputField.DecimalPlaces = PercentageDecimalPlaces;
			inputField.Increment = (decimal)PercentageIncrement;
			inputField.Value = (decimal)value;
		}

		/// <summary>
		/// Changes an input field to hold pixels.
		/// </summary>
		/// <param name="inputField">An input field to change.</param>
		/// <param name="value">A value to set.</param>
		private static void ChangeInputFieldToPixels(NumericUpDown inputField, int value)
		{
			inputField.Minimum = ResizingFilterSettingsModel.MinSideLength;
			inputField.Maximum = ResizingFilterSettingsModel.MaxSideLength;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		/// <summary>
		/// Updates input fields to contain set percents. 
		/// </summary>
		private void UpdateInputFieldsInPercents()
		{
			ChangeInputFieldToPercents(_widthInput, DisplayedModel.WidthInPercents);
			ChangeInputFieldToPercents(_heightInput, DisplayedModel.HeightInPercents);
		}

		/// <summary>
		/// Updates input fields to contain set pixels. 
		/// </summary>
		private void UpdateInputFieldsInPixels()
		{
			ChangeInputFieldToPixels(_widthInput, DisplayedModel.WidthInPixels);
			ChangeInputFieldToPixels(_heightInput, DisplayedModel.HeightPixels);
		}

		/// <summary>
		/// Updates the type of resizing according to the input.
		/// </summary>
		private void ResizingTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			DisplayedModel.ResizingType = _resizingTypeBoxManager.SelectedValue;
			UpdateDisplayedSettings();
		}

		/// <summary>
		/// Updates the width according to the input.
		/// </summary>
		private void WidthInput_ValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.Pixels:
					DisplayedModel.WidthInPixels = (int)_widthInput.Value;
					break;
				case ResizingType.Percents:
					DisplayedModel.WidthInPercents = (float)_widthInput.Value;
					break;
			}
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the height according to the input.
		/// </summary>
		private void HeightInput_ValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.Pixels:
					DisplayedModel.HeightPixels = (int)_heightInput.Value;
					break;
				case ResizingType.Percents:
					DisplayedModel.HeightInPercents = (float)_heightInput.Value;
					break;
			}
			OnDisplayedSettingsUpdated();
		}
	}
}
