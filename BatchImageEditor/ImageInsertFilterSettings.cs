using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for inserting an image.
	/// </summary>
	internal sealed partial class ImageInsertFilterSettings : FilterSettings<ImageInsertFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="ImageInsertFilterSettings"/>.
		/// </summary>
		public ImageInsertFilterSettings()
		{
			InitializeComponent();
			_imagePlacementBoxManager = new EnumComboBoxManager<ImagePlacement>(_placementComboBox, ImagePlacementToText);
			_imagePlacementBoxManager.SelectedValueChanged += ImagePlacementBox_SelectedValueChanged;
			InitializeDeltaInputField(_dXInput);
			InitializeDeltaInputField(_dYInput);
		}

		/// <inheritdoc/>
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
		private Bitmap _loadedImage;

		/// <summary>
		/// Initializes an input field for changing the location of the inserted image.
		/// </summary>
		/// <param name="inputField">An input field for inserted image location.</param>
		private static void InitializeDeltaInputField(NumericUpDown inputField)
		{
			inputField.Minimum = ImageInsertFilterSettingsModel.MinDelta;
			inputField.Maximum = ImageInsertFilterSettingsModel.MaxDelta;
		}

		/// <summary>
		/// Updates the placement of the image according to the input.
		/// </summary>
		private void ImagePlacementBox_SelectedValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.ImagePlacement = _imagePlacementBoxManager.SelectedValue;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Loads an image to insert.
		/// </summary>
		private void LoadImageButton_Click(object sender, EventArgs e)
		{
			using var dialog = new OpenFileDialog();
			dialog.Title = "Select images";
			dialog.Filter = SupportedImages.GetDialogFilter();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_loadedImage?.Dispose();
				_loadedImage = null;
				DisplayedModel.InsertedImage = null;
				try
				{
					_loadedImage = new Bitmap(dialog.FileName);
					DisplayedModel.InsertedImage = _loadedImage;
				}
				catch (Exception ex) when (ex is ExternalException || ex is ArgumentException)
				{
					MessageBox.Show($"An image could not be loaded from {dialog.FileName}.");
				}
			}
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the X location of the inserted image according to the input.
		/// </summary>
		private void DXInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaX = (int)_dXInput.Value;
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates the Y location of the inserted image according to the input.
		/// </summary>
		private void DYInput_ValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.DeltaY = (int)_dYInput.Value;
			OnDisplayedSettingsUpdated();
		}
	}
}
