using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	internal partial class FilterEditForm : Form
	{
		public FilterEditForm()
		{
			InitializeComponent();
			_previewUpdater = new UIUpdater<DirectBitmap>(this);
			_formDisplayed = false;
		}

		public DirectBitmap InputImage
		{
			get
			{
				return _previewControl.OriginalImage;
			}
			set
			{
				_previewControl.OriginalImage = value;
				if (_formDisplayed)
				{
					UpdatePreview(value);
				}
			}
		}

		public DialogResult OpenModally(FilterSettingsBase filterSettings)
		{
			if (!_settingsGroup.Controls.Contains(filterSettings))
			{
				_settingsGroup.Controls.Add(filterSettings);
				filterSettings.Dock = DockStyle.Fill;
				filterSettings.DisplayedSettingsUpdated += FilterSettings_DisplayedSettingsUpdated;
			}
			_currentFilterSettings = filterSettings;
			_currentFilterSettings.DisplaySettings();
			_currentFilterSettings.Show();
			_currentFilterSettings.BringToFront();
			_formDisplayed = true;
			return this.ShowDialog();
		}

		private readonly UIUpdater<DirectBitmap> _previewUpdater;
		private FilterSettingsBase _currentFilterSettings;
		private bool _formDisplayed;

		private void OkButton_Click(object sender, EventArgs e)
		{
			_currentFilterSettings.SaveDisplayedSettings();
			_currentFilterSettings.Hide();
			this.DialogResult = DialogResult.OK;
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			_currentFilterSettings.ResetDisplayedSettings();
		}

		private void UpdatePreview(DirectBitmap inputImage)
		{
			// NOTE: will be called on DisplaySettings, no need to call it explicitly in OpenModally
			IEnumerable<IImageFilter> filters = _currentFilterSettings.CreateFiltersFromDisplayedSettings();
			_previewUpdater.UpdateAsync(
				() =>
				{
					if (inputImage == null)
					{
						return null;
					}
					return CreatePreviewImage(inputImage, filters);
				},
				image =>
				{
					_previewControl.PreviewImage?.Dispose();
					_previewControl.PreviewImage = image;
				});
		}

		private static DirectBitmap CreatePreviewImage(DirectBitmap original, IEnumerable<IImageFilter> filters)
		{
			DirectBitmap previewImage = original.Copy();
			foreach (var filter in filters)
			{
				filter.Apply(ref previewImage);
			}
			return previewImage;
		}

		private void FilterSettings_DisplayedSettingsUpdated(object sender, EventArgs e)
		{
			UpdatePreview(InputImage);
		}

		private void FilterEditForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_formDisplayed = false;
		}
	}
}
