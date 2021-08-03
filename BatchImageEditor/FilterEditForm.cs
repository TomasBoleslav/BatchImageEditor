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
			_asyncImageFilter = new AsyncImageFilter();
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
		private AsyncImageFilter _asyncImageFilter;
		private Task<DirectBitmap> _currentFilterTask;

		private void OkButton_Click(object sender, EventArgs e)
		{
			_filterSettings.SaveAndHide();
			this.DialogResult = DialogResult.OK;
		}

		private void UpdatePreview()
		{
			IEnumerable<IImageFilter> filters = _filterSettings.CreateFiltersFromDisplayedSettings();
			_currentFilterTask = _asyncImageFilter.ApplyAsync(_inputImage, filters);
			_currentFilterTask.ContinueWith(task => Invoke((MethodInvoker)(() =>
				{
					if (task == _currentFilterTask)
					{
						_previewImage?.Dispose();
						_previewImage = task.Result;
						_previewControl.UpdatePreview(_previewImage.Bitmap);
					}
					else
					{
						task.Result.Dispose();
					}
				})));
			/*foreach (var filter in filters)
			{
				filter.Apply(ref _previewImage);
			}*/
			//_previewControl.UpdatePreview(_previewImage.Bitmap);
		}

		private void FilterSettings_DisplayedSettingsChanged(object sender, EventArgs e)
		{
			UpdatePreview();
		}
	}
}
