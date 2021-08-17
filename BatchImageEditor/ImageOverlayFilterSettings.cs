using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class ImageOverlayFilterSettings : FilterSettings<ImageOverlayFilterSettingsModel>
	{
		public ImageOverlayFilterSettings()
		{
			InitializeComponent();
			_imagePlacementBoxManager = new EnumComboBoxManager<ImagePlacement>(_placementComboBox, ImagePlacementToText);
			_imagePlacementBoxManager.SelectedValueChanged += ImagePlacementBox_SelectedValueChanged;
			InitializeDeltaInputField(_dXInput);
			InitializeDeltaInputField(_dYInput);
		}

		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_imagePlacementBoxManager.SelectedValue = DisplayedModel.ImagePlacement;
			_dXInput.Value = DisplayedModel.DeltaX;
			_dYInput.Value = DisplayedModel.DeltaY;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			_loadedImage?.Dispose();
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private static readonly Dictionary<ImagePlacement, string> ImagePlacementToText = new()
		{
			{ ImagePlacement.TopLeft, "Top Left" },
			{ ImagePlacement.TopRight, "Top Right" },
			{ ImagePlacement.BottomLeft, "Bottom Left" },
			{ ImagePlacement.BottomRight, "Bottom Right" },
			{ ImagePlacement.Middle, "Middle" }
		};

		private readonly EnumComboBoxManager<ImagePlacement> _imagePlacementBoxManager;

		private static void InitializeDeltaInputField(NumericUpDown inputField)
		{
			inputField.Minimum = ImageOverlayFilterSettingsModel.MinDelta;
			inputField.Maximum = ImageOverlayFilterSettingsModel.MaxDelta;
		}

		private void ImagePlacementBox_SelectedValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.ImagePlacement = _imagePlacementBoxManager.SelectedValue;
			OnDisplayedSettingsUpdated();
		}

		private void LoadImageButton_Click(object sender, EventArgs e)
		{
			using var dialog = new OpenFileDialog();
			dialog.Title = "Select images";
			dialog.Filter = SupportedImages.GetDialogFilter();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_loadedImage?.Dispose();
				_loadedImage = null;
				DisplayedModel.OverlayImage = null;
				try
				{
					_loadedImage = DirectBitmap.FromFile(dialog.FileName);
					DisplayedModel.OverlayImage = _loadedImage;
				}
				catch (IOException)
				{
					MessageBox.Show($"An image could not be loaded from {dialog.FileName}.");
				}
			}
			OnDisplayedSettingsUpdated();
		}

		private void DXInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaX = (int)_dXInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private void DYInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaY = (int)_dYInput.Value;
			OnDisplayedSettingsUpdated();
		}

		private DirectBitmap _loadedImage;
	}
}
