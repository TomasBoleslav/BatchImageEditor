using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	internal partial class FilterSettingsEditDialog : Form
	{
		public FilterSettingsEditDialog()
		{
			InitializeComponent();
			_previewUpdater = new UIUpdater();
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
			}
		}

		public FilterSettingsBase FilterSettings
		{
			get
			{
				return _filterSettings;
			}
			set
			{
				DetachFilterSettings();
				_filterSettings = value;
				if (_filterSettings != null)
				{
					AttachFilterSettings();
				}
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			DetachFilterSettings();
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private readonly UIUpdater _previewUpdater;
		private FilterSettingsBase _filterSettings;

		private void AttachFilterSettings()
		{
			_settingsGroup.Controls.Add(_filterSettings);
			_filterSettings.Dock = DockStyle.Fill;
			_filterSettings.DisplayedSettingsUpdated += FilterSettings_DisplayedSettingsUpdated;
			_filterSettings.Show();
			_filterSettings.BringToFront();
			_filterSettings.DisplaySettings(); // Invokes DisplayedSettingsUpdated event
		}

		private void DetachFilterSettings()
		{
			foreach (FilterSettingsBase filterSettings in _settingsGroup.Controls)
			{
				filterSettings.Hide();
				filterSettings.DisplayedSettingsUpdated -= FilterSettings_DisplayedSettingsUpdated;
			}
			_settingsGroup.Controls.Clear();
		}

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
			_previewUpdater.Update(() =>
			{
				if (_filterSettings == null || InputImage == null)
				{
					return Task.CompletedTask;
				}
				// Do not create filters and bitmap outside of Update
				//     - if the task finishes too late and other task overwrites it, it will be for naught
				// Create filters and copy bitmap synchronously
				//     - potential data race if moved to asynchronous task, because data are accessible from outside
				IEnumerable<IImageFilter> filters = _filterSettings.CreateFiltersFromDisplayedSettings();
				DirectBitmap inputImageCopy = InputImage.Copy();
				return Task.Run(
					() =>
					{
						ApplyFilters(ref inputImageCopy, filters);
						return inputImageCopy;
					}).ContinueWith(
					task =>
					{
						DirectBitmap previewImage = task.Result;
						if (this.IsDisposed)
						{
							previewImage?.Dispose();
							return;
						}
						_previewControl.PreviewImage?.Dispose();
						_previewControl.PreviewImage = previewImage;
					}, TaskScheduler.FromCurrentSynchronizationContext());
			});
		}

		private static void ApplyFilters(ref DirectBitmap image, IEnumerable<IImageFilter> filters)
		{
			foreach (var filter in filters)
			{
				filter.Apply(ref image);
			}
		}

		private void FilterSettings_DisplayedSettingsUpdated(object sender, EventArgs e)
		{
			UpdatePreview();
		}
	}
}
