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
			inputField.Minimum = (decimal)CropFilterSettingsModel.MinPercentageSideLength;
			inputField.Maximum = (decimal)CropFilterSettingsModel.MaxPercentageSideLength;
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
			inputField.Minimum = CropFilterSettingsModel.MinPixelSideLength;
			inputField.Maximum = CropFilterSettingsModel.MaxPixelSideLength;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		private void UpdateInputFieldsAsPercents()
		{
			_inputFieldsEnabled = false;
			ChangeLocationInputFieldToPercents(_xInput, DisplayedModel.PercentsRectangle.X);
			ChangeLocationInputFieldToPercents(_yInput, DisplayedModel.PercentsRectangle.Y);
			ChangeSizeInputFieldToPercents(_widthInput, DisplayedModel.PercentsRectangle.Width);
			ChangeSizeInputFieldToPercents(_heightInput, DisplayedModel.PercentsRectangle.Height);
			_inputFieldsEnabled = true;
		}

		private void UpdateInputFieldsAsPixels()
		{
			_inputFieldsEnabled = false;
			ChangeLocationInputFieldToPixels(_xInput, DisplayedModel.PixelsRectangle.X);
			ChangeLocationInputFieldToPixels(_yInput, DisplayedModel.PixelsRectangle.Y);
			ChangeSizeInputFieldToPixels(_widthInput, DisplayedModel.PixelsRectangle.Width);
			ChangeSizeInputFieldToPixels(_heightInput, DisplayedModel.PixelsRectangle.Height);
			_inputFieldsEnabled = true;
		}

		private void CropTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.CropType = _cropTypeBoxManager.SelectedValue;
			DisableUpdateEvents();
			UpdateDisplayedSettingsWithDisabledEvents();
			EnableUpdateEvents();
			OnDisplayedSettingsUpdated();
		}

		private void SetInputFieldDependingOnCropType(
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
					Rectangle pixelRect = DisplayedModel.PixelsRectangle;
					DisplayedModel.PixelsRectangle = pixelRectFunc.Invoke(pixelRect);
					break;
				case CropType.Percents:
					RectangleF percentRect = DisplayedModel.PercentsRectangle;
					DisplayedModel.PercentsRectangle = percentRectFunc.Invoke(percentRect);
					break;
			}
		}

		private void XInput_ValueChanged(object sender, EventArgs e)
		{
			SetInputFieldDependingOnCropType(
				pixelRect => pixelRect.WithX((int)_xInput.Value),
				percentRect => percentRect.WithX((float)_xInput.Value)
				);
		}

		private void YInput_ValueChanged(object sender, EventArgs e)
		{
			SetInputFieldDependingOnCropType(
				pixelRect => pixelRect.WithY((int)_yInput.Value),
				percentRect => percentRect.WithY((float)_yInput.Value)
				);
		}

		private void WidthInput_ValueChanged(object sender, EventArgs e)
		{
			SetInputFieldDependingOnCropType(
				pixelRect => pixelRect.WithWidth((int)_widthInput.Value),
				percentRect => percentRect.WithWidth((float)_widthInput.Value)
				);
		}

		private void HeightInput_ValueChanged(object sender, EventArgs e)
		{
			SetInputFieldDependingOnCropType(
				pixelRect => pixelRect.WithHeight((int)_heightInput.Value),
				percentRect => percentRect.WithHeight((float)_heightInput.Value)
				);
		}
	}
}
