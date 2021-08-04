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
			_previewUpdater = new ControlUpdater<DirectBitmap>(_previewControl);
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
				// TODO: UpdateAsync fails on BeginInvoke if the control was not yet fully created
				_previewControl.OriginalImage = value;
				if (_formDisplayed)
				{
					UpdatePreview(value);
				}
				// TODO: update preview image if the form is opened
				/*if (_previewControl.PreviewImage != null)
				{
					_previewUpdater.UpdateAsync(() => null,
						_ =>
						{
							_previewControl.PreviewImage.Dispose();
							_previewControl.PreviewImage = null;
						});
				}
				_previewUpdater.UpdateAsync(() => null,
					_ =>
					{
						_previewControl.PreviewImage.Dispose();
						_previewControl.PreviewImage = null;
					});
				if (this.isc)
				{

				}*/
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
			filterSettings.DisplaySettings();
			filterSettings.Show();
			filterSettings.BringToFront();
			_currentFilterSettings = filterSettings;
			_formDisplayed = true;
			return this.ShowDialog();
		}

		private readonly ControlUpdater<DirectBitmap> _previewUpdater;
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
			_previewUpdater.UpdateAsync(
				() =>
				{
					if (inputImage == null)
					{
						return null;
					}
					return CreatePreviewImage(inputImage);
				},
				image =>
				{
					_previewControl.PreviewImage?.Dispose();
					_previewControl.PreviewImage = image;
				});
			/*_previewControl.PreviewImage?.Dispose();
			if (InputImage != null)
			{
				_previewControl.PreviewImage = CreatePreviewImage(InputImage);
			}
			else
			{
				_previewControl.PreviewImage = null;
			}*/
		}

		private DirectBitmap CreatePreviewImage(DirectBitmap original)
		{
			IEnumerable<IImageFilter> filters = _currentFilterSettings.CreateFiltersFromDisplayedSettings();
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

		private void FilterEditForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_formDisplayed = false;
		}
	}
}
