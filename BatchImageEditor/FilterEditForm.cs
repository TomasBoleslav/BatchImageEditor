using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	internal partial class FilterEditForm : Form
	{
		public FilterEditForm()
		{
			InitializeComponent();
		}

		public DialogResult OpenModally(DirectBitmap inputImage, FilterSettingsBase filterSettings)
		{
			_inputImage?.Dispose();		// TODO: better dispose on close
			_previewImage?.Dispose();
			if (inputImage != null)
			{
				_inputImage = inputImage.Copy();
				_previewControl.SetNewImage(_inputImage.Bitmap, null);
			}
			else
			{
				_previewControl.SetNewImage(null, null);
			}
			if (!_settingsPanel.Controls.Contains(filterSettings))
			{
				_settingsPanel.Controls.Add(filterSettings);
				filterSettings.Dock = DockStyle.Fill;
				filterSettings.DisplayedSettingsChanged += FilterSettings_DisplayedSettingsChanged;
			}
			_filterSettings = filterSettings;
			_filterSettings.DisplaySettings();
			return this.ShowDialog();
		}

		private FilterSettingsBase _filterSettings;
		private DirectBitmap _inputImage;
		private DirectBitmap _previewImage;

		private void OkButton_Click(object sender, EventArgs e)
		{
			_filterSettings.SaveAndHide();
			this.DialogResult = DialogResult.OK;
		}

		private void UpdatePreview()
		{
			IEnumerable<IImageFilter> filters = _filterSettings.CreateFiltersFromDisplayedSettings();
			_previewImage?.Dispose();
			_previewImage = _inputImage.Copy();
			foreach (var filter in filters)
			{
				filter.Apply(ref _previewImage);
			}
			_previewControl.UpdatePreview(_previewImage.Bitmap);
		}

		private void FilterSettings_DisplayedSettingsChanged(object sender, EventArgs e)
		{
			UpdatePreview();
		}
	}
}
