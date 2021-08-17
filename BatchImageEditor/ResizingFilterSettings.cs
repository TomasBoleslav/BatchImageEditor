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
			_resizingTypeBoxManager.SelectedValue = DisplayedModel.ResizingType;
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.Fixed:
					UpdateSizeForFixedResizing();
					break;
				case ResizingType.Percentage:
					UpdateSizeForResizingByFactor();
					break;
			}
		}

		private const int PercentageDecimalPlaces = 2;
		private const float PercentageIncrement = 0.1f;
		private readonly EnumComboBoxManager<ResizingType> _resizingTypeBoxManager;

		private bool _inputFieldEventsEnabled = true;

		private static readonly Dictionary<ResizingType, string> ResizingTypesToText = new()
		{
			{ ResizingType.Percentage, "In percents" },
			{ ResizingType.Fixed, "In pixels" }
		};

		private void ResizingTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.ResizingType = _resizingTypeBoxManager.SelectedValue;
			DisableUpdateEvents();
			UpdateDisplayedSettingsWithDisabledEvents();
			EnableUpdateEvents();
			OnDisplayedSettingsUpdated();
		}

		private void UpdateSizeForResizingByFactor()
		{
			_inputFieldEventsEnabled = false;
			ChangeInputFieldToPercents(_widthInput, DisplayedModel.WidthPercentage);
			ChangeInputFieldToPercents(_heightInput, DisplayedModel.HeightPercentage);
			_inputFieldEventsEnabled = true;
		}

		private void UpdateSizeForFixedResizing()
		{
			_inputFieldEventsEnabled = false;
			ChangeInputFieldToPixels(_widthInput, DisplayedModel.FixedWidth);
			ChangeInputFieldToPixels(_heightInput, DisplayedModel.FixedHeight);
			_inputFieldEventsEnabled = true;
		}

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

		private void WidthInput_ValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldEventsEnabled)
			{
				return;
			}
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.Fixed:
					DisplayedModel.FixedWidth = (int)_widthInput.Value;
					break;
				case ResizingType.Percentage:
					DisplayedModel.WidthPercentage = (float)_widthInput.Value;
					break;
			}
			OnDisplayedSettingsUpdated();
		}

		private void HeightInput_ValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldEventsEnabled)
			{
				return;
			}
			switch (DisplayedModel.ResizingType)
			{
				case ResizingType.Fixed:
					DisplayedModel.FixedHeight = (int)_heightInput.Value;
					break;
				case ResizingType.Percentage:
					DisplayedModel.HeightPercentage = (float)_heightInput.Value;
					break;
			}
			OnDisplayedSettingsUpdated();
		}
	}
}
