using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace BatchImageEditor
{
	public partial class CropFilterSettings : FilterSettings<CropFilterSettingsModel>
	{
		public CropFilterSettings()
		{
			InitializeComponent();
			_cropTypeBoxManager = new EnumComboBoxManager<CropType>(_cropTypeComboBox, CropTypesToText);
			_cropTypeBoxManager.SelectedValueChanged += CropTypeBox_SelectedValueChanged;
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_inputFieldsEnabled = false;
			_cropTypeBoxManager.SelectedValue = DisplayedModel.CropType;
			switch (DisplayedModel.CropType)
			{
				case CropType.Percents:
					UpdateInputFieldsAsPercents();
					break;
				case CropType.Pixels:
					UpdateInputFieldsAsPixels();
					break;
			}
			_inputFieldsEnabled = true;
		}

		private const int PercentageDecimalPlaces = 2;
		private const float PercentageIncrement = 0.1f;
		private static readonly Dictionary<CropType, string> CropTypesToText = new()
		{
			{ CropType.Percents, "In percents" },
			{ CropType.Pixels, "In pixels" }
		};

		private readonly EnumComboBoxManager<CropType> _cropTypeBoxManager;
		private bool _inputFieldsEnabled = true;

		private static void ChangeLocationInputFieldToPercents(NumericUpDown inputField, float value)
		{
			inputField.Minimum = (decimal)CropFilterSettingsModel.MinPercentageLocation;
			inputField.Maximum = (decimal)CropFilterSettingsModel.MaxPercentageLocation;
			inputField.DecimalPlaces = PercentageDecimalPlaces;
			inputField.Increment = (decimal)PercentageIncrement;
			inputField.Value = (decimal)value;
		}

		private static void ChangeSizeInputFieldToPercents(NumericUpDown inputField, float value)
		{
			inputField.Minimum = (decimal)CropFilterSettingsModel.MinPercentageSize;
			inputField.Maximum = (decimal)CropFilterSettingsModel.MaxPercentageSize;
			inputField.DecimalPlaces = PercentageDecimalPlaces;
			inputField.Increment = (decimal)PercentageIncrement;
			inputField.Value = (decimal)value;
		}

		private static void ChangeLocationInputFieldToPixels(NumericUpDown inputField, int value)
		{
			inputField.Minimum = CropFilterSettingsModel.MinPixelLocation;
			inputField.Maximum = CropFilterSettingsModel.MaxPixelLocation;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		private static void ChangeSizeInputFieldToPixels(NumericUpDown inputField, int value)
		{
			inputField.Minimum = CropFilterSettingsModel.MinPixelSize;
			inputField.Maximum = CropFilterSettingsModel.MaxPixelSize;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		private void UpdateInputFieldsAsPercents()
		{
			ChangeLocationInputFieldToPercents(_xInput, DisplayedModel.PercentsCropRect.X);
			ChangeLocationInputFieldToPercents(_yInput, DisplayedModel.PercentsCropRect.Y);
			ChangeSizeInputFieldToPercents(_widthInput, DisplayedModel.PercentsCropRect.Width);
			ChangeSizeInputFieldToPercents(_heightInput, DisplayedModel.PercentsCropRect.Height);
		}

		private void UpdateInputFieldsAsPixels()
		{
			ChangeLocationInputFieldToPixels(_xInput, DisplayedModel.PixelsCropRect.X);
			ChangeLocationInputFieldToPixels(_yInput, DisplayedModel.PixelsCropRect.Y);
			ChangeSizeInputFieldToPixels(_widthInput, DisplayedModel.PixelsCropRect.Width);
			ChangeSizeInputFieldToPixels(_heightInput, DisplayedModel.PixelsCropRect.Height);
		}

		private void CropTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			DisplayedModel.CropType = _cropTypeBoxManager.SelectedValue;
			UpdateDisplayedSettings();
		}

		private void ChangeCropRectDependingOnCropType(
			Func<Rectangle, Rectangle> pixelRectFunc,
			Func<RectangleF, RectangleF> percentRectFunc)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			switch (DisplayedModel.CropType)
			{
				case CropType.Pixels:
					Rectangle pixelRect = DisplayedModel.PixelsCropRect;
					DisplayedModel.PixelsCropRect = pixelRectFunc.Invoke(pixelRect);
					break;
				case CropType.Percents:
					RectangleF percentRect = DisplayedModel.PercentsCropRect;
					DisplayedModel.PercentsCropRect = percentRectFunc.Invoke(percentRect);
					break;
			}
			OnDisplayedSettingsUpdated();
		}

		private void XInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithX((int)_xInput.Value),
				percentRect => percentRect.WithX((float)_xInput.Value)
				);
		}

		private void YInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithY((int)_yInput.Value),
				percentRect => percentRect.WithY((float)_yInput.Value)
				);
		}

		private void WidthInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithWidth((int)_widthInput.Value),
				percentRect => percentRect.WithWidth((float)_widthInput.Value)
				);
		}

		private void HeightInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithHeight((int)_heightInput.Value),
				percentRect => percentRect.WithHeight((float)_heightInput.Value)
				);
		}
	}
}
