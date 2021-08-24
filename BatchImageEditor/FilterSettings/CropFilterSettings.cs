using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for image cropping.
	/// </summary>
	internal sealed partial class CropFilterSettings : FilterSettings<CropFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="CropFilterSettings"/>.
		/// </summary>
		public CropFilterSettings()
		{
			InitializeComponent();
			_cropTypeBoxManager = new EnumComboBoxManager<CropType>(_cropTypeComboBox, CropTypesToText);
			_cropTypeBoxManager.SelectedValueChanged += CropTypeBox_SelectedValueChanged;
		}

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_inputFieldsEnabled = false;
			_cropTypeBoxManager.SelectedValue = DisplayedModel.CropType;
			switch (DisplayedModel.CropType)
			{
				case CropType.Percents:
					ChangeInputFieldsToPercents();
					break;
				case CropType.Pixels:
					ChangeInputFieldsToPixels();
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

		/// <summary>
		/// Changes an input field for cropped image location to be an input for percents.
		/// </summary>
		/// <param name="inputField">An input field to change.</param>
		/// <param name="value">A value to set.</param>
		private static void ChangeLocationInputFieldToPercents(NumericUpDown inputField, float value)
		{
			inputField.Minimum = (decimal)CropFilterSettingsModel.MinPercentageLocation;
			inputField.Maximum = (decimal)CropFilterSettingsModel.MaxPercentageLocation;
			inputField.DecimalPlaces = PercentageDecimalPlaces;
			inputField.Increment = (decimal)PercentageIncrement;
			inputField.Value = (decimal)value;
		}

		/// <summary>
		/// Changes an input field for cropped image size to be an input for percents.
		/// </summary>
		/// <param name="inputField">An input field to change.</param>
		/// <param name="value">A value to set.</param>
		private static void ChangeSizeInputFieldToPercents(NumericUpDown inputField, float value)
		{
			inputField.Minimum = (decimal)CropFilterSettingsModel.MinPercentageSize;
			inputField.Maximum = (decimal)CropFilterSettingsModel.MaxPercentageSize;
			inputField.DecimalPlaces = PercentageDecimalPlaces;
			inputField.Increment = (decimal)PercentageIncrement;
			inputField.Value = (decimal)value;
		}

		/// <summary>
		/// Changes an input field for cropped image location to be an input for pixels.
		/// </summary>
		/// <param name="inputField">An input field to change.</param>
		/// <param name="value">A value to set.</param>
		private static void ChangeLocationInputFieldToPixels(NumericUpDown inputField, int value)
		{
			inputField.Minimum = CropFilterSettingsModel.MinPixelLocation;
			inputField.Maximum = CropFilterSettingsModel.MaxPixelLocation;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		/// <summary>
		/// Changes an input field for cropped image size to be an input for pixels.
		/// </summary>
		/// <param name="inputField">An input field to change.</param>
		/// <param name="value">A value to set.</param>
		private static void ChangeSizeInputFieldToPixels(NumericUpDown inputField, int value)
		{
			inputField.Minimum = CropFilterSettingsModel.MinPixelSize;
			inputField.Maximum = CropFilterSettingsModel.MaxPixelSize;
			inputField.DecimalPlaces = 0;
			inputField.Increment = 1;
			inputField.Value = value;
		}

		/// <summary>
		/// Changes input fields to hold percents.
		/// </summary>
		private void ChangeInputFieldsToPercents()
		{
			ChangeLocationInputFieldToPercents(_xInput, DisplayedModel.PercentsCropRect.X);
			ChangeLocationInputFieldToPercents(_yInput, DisplayedModel.PercentsCropRect.Y);
			ChangeSizeInputFieldToPercents(_widthInput, DisplayedModel.PercentsCropRect.Width);
			ChangeSizeInputFieldToPercents(_heightInput, DisplayedModel.PercentsCropRect.Height);
		}

		/// <summary>
		/// Changes input fields to hold pixels.
		/// </summary>
		private void ChangeInputFieldsToPixels()
		{
			ChangeLocationInputFieldToPixels(_xInput, DisplayedModel.PixelsCropRect.X);
			ChangeLocationInputFieldToPixels(_yInput, DisplayedModel.PixelsCropRect.Y);
			ChangeSizeInputFieldToPixels(_widthInput, DisplayedModel.PixelsCropRect.Width);
			ChangeSizeInputFieldToPixels(_heightInput, DisplayedModel.PixelsCropRect.Height);
		}

		/// <summary>
		/// Updates the <see cref="CropType"/> based on the user's input.
		/// </summary>
		private void CropTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!_inputFieldsEnabled)
			{
				return;
			}
			DisplayedModel.CropType = _cropTypeBoxManager.SelectedValue;
			UpdateDisplayedSettings();
		}

		/// <summary>
		/// Changes the bounds of the cropped image based on the current crop type.
		/// </summary>
		/// <param name="pixelRectFunc">A function computing the bounds of the cropped image from the current bounds in pixels.</param>
		/// <param name="percentRectFunc">A function computing the bounds of the cropped image from the current bounds in percents.</param>
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

		/// <summary>
		/// Updates the X location of the cropped image based on the user's input.
		/// </summary>
		private void XInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithX((int)_xInput.Value),
				percentRect => percentRect.WithX((float)_xInput.Value)
				);
		}

		/// <summary>
		/// Updates the Y location of the cropped image based on the user's input.
		/// </summary>
		private void YInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithY((int)_yInput.Value),
				percentRect => percentRect.WithY((float)_yInput.Value)
				);
		}

		/// <summary>
		/// Updates the width of the cropped image based on the user's input.
		/// </summary>
		private void WidthInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithWidth((int)_widthInput.Value),
				percentRect => percentRect.WithWidth((float)_widthInput.Value)
				);
		}

		/// <summary>
		/// Updates the height of the cropped image based on the user's input.
		/// </summary>
		private void HeightInput_ValueChanged(object sender, EventArgs e)
		{
			ChangeCropRectDependingOnCropType(
				pixelRect => pixelRect.WithHeight((int)_heightInput.Value),
				percentRect => percentRect.WithHeight((float)_heightInput.Value)
				);
		}
	}
}
