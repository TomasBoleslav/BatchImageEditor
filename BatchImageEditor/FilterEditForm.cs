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
			_asyncImageFilter = new PreviewUpdater();
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
				_previewControl.PreviewImage?.Dispose();
				_previewControl.PreviewImage = null;
			}
		}

		public DialogResult OpenModally(FilterSettingsBase filterSettings)
		{
			if (!_settingsGroup.Controls.Contains(filterSettings))
			{
				_settingsGroup.Controls.Add(filterSettings);
				filterSettings.Dock = DockStyle.Fill;
				filterSettings.DisplayedSettingsChanged += FilterSettings_DisplayedSettingsChanged;
			}
			_filterSettings = filterSettings;
			_filterSettings.DisplaySettings();
			_filterSettings.Show();
			_filterSettings.BringToFront();
			return this.ShowDialog();
		}

		private FilterSettingsBase _filterSettings;
		private ControlUpdater _asyncImageFilter;
		private Task<DirectBitmap> _currentFilterTask;

		private void OkButton_Click(object sender, EventArgs e)
		{
			_filterSettings.SaveDisplayedSettings();
			_filterSettings.Hide();
			this.DialogResult = DialogResult.OK;
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			_filterSettings.ResetDisplayedSettings();
		}

		private void UpdatePreview()
		{
			// NOTE: will be called on DisplaySettings, no need to call it explicitly in OpenModally
			_previewControl.PreviewImage?.Dispose();
			if (InputImage != null)
			{
				_previewControl.PreviewImage = CreatePreviewImage(InputImage);
			}
			else
			{
				_previewControl.PreviewImage = null;
			}

			/*
			IEnumerable<IImageFilter> filters = _filterSettings.CreateFiltersFromDisplayedSettings();
			_currentFilterTask = _asyncImageFilter.ApplyAsync(_inputImage, filters);
			_currentFilterTask.ContinueWith(task => task.Result, TaskContinuationOptions.OnlyOnRanToCompletion);
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
				})));*/
			/*foreach (var filter in filters)
			{
				filter.Apply(ref _previewImage);
			}*/
			//_previewControl.UpdatePreview(_previewImage.Bitmap);
		}

		private DirectBitmap CreatePreviewImage(DirectBitmap original)
		{
			IEnumerable<IImageFilter> filters = _filterSettings.CreateFiltersFromDisplayedSettings();
			DirectBitmap previewImage = original.Copy();
			foreach (var filter in filters)
			{
				filter.Apply(ref previewImage);
			}
			return previewImage;
		}

		private void FilterSettings_DisplayedSettingsChanged(object sender, EventArgs e)
		{
			UpdatePreview();
		}

	}
}
