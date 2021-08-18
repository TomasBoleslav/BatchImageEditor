using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BatchImageEditor
{
	internal partial class ResizingFilterSettings : FilterSettings<ResizingSettingsModel>
	{
		public ResizingFilterSettings()
		{
			InitializeComponent();
			_resizingTypeBoxManager = new EnumComboBoxManager<ResizingType>(_resizingTypeBox, ResizingTypesToText);
			_resizingTypeBoxManager.SelectedValueChanged += ResizingTypeBox_SelectedValueChanged;
		}
		
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_inputFieldsEnabled = false;
			_resizingTypeBoxManager.SelectedValue = DisplayedModel.ResizingType;
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.FixedInPixels:
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
			{ ResizingType.FixedInPixels, "In pixels" }
		};

		private static void ChangeInputFieldToPercents(NumericUpDown inputField, float value)
		{
			inputField.Minimum = (decimal)ResizingSettingsModel.MinPercentage;
			inputField.Maximum = (decimal)ResizingSettingsModel.MaxPercentage;
			inputField.DecimalPlaces = PercentageDecimalPlaces;
			inputField.Increment = (decimal)PercentageIncrement;
			inputField.Value = (decimal)value;
		}
		
		private static void ChangeInputFieldToPixels(NumericUpDown inputField, int value)
		{
			inputField.Minimum = ResizingSettingsModel.MinSideLength;
			inputField.Maximum = ResizingSettingsModel.MaxSideLength;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		private void UpdateInputFieldsInPercents()
		{
			ChangeInputFieldToPercents(_widthInput, DisplayedModel.WidthPercentage);
			ChangeInputFieldToPercents(_heightInput, DisplayedModel.HeightPercentage);
		}

		private void UpdateInputFieldsInPixels()
		{
			ChangeInputFieldToPixels(_widthInput, DisplayedModel.FixedWidth);
			ChangeInputFieldToPixels(_heightInput, DisplayedModel.FixedHeight);
		}

		private void ResizingTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			DisplayedModel.ResizingType = _resizingTypeBoxManager.SelectedValue;
			UpdateDisplayedSettings();
		}

		private void WidthInput_ValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.FixedInPixels:
					DisplayedModel.FixedWidth = (int)_widthInput.Value;
					break;
				case ResizingType.Percents:
					DisplayedModel.WidthPercentage = (float)_widthInput.Value;
					break;
			}
			OnDisplayedSettingsUpdated();
		}

		private void HeightInput_ValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.FixedInPixels:
					DisplayedModel.FixedHeight = (int)_heightInput.Value;
					break;
				case ResizingType.Percents:
					DisplayedModel.HeightPercentage = (float)_heightInput.Value;
					break;
			}
			OnDisplayedSettingsUpdated();
		}
	}
}
