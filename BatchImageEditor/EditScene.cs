using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class EditScene : UserControl
	{
		public EditScene()
		{
			InitializeComponent();
			_previewUpdater = new UIUpdater();
		}

		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_fileSelectionControl.SetFilenames(filenames);
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			return _filterListControl.CreateFilters();
		}

		private readonly UIUpdater _previewUpdater;

		private void FileSelectionControl_SelectionChanged(object sender, EventArgs e)
		{
			_previewControl.OriginalImage?.Dispose();
			_previewControl.OriginalImage = null;
			_filterListControl.InputImage = null;
			_previewUpdater.Update(
				() =>
				{
					// Run this in Update, there can be old updates still pending
					_previewControl.PreviewImage?.Dispose();
					_previewControl.PreviewImage = null;
					return Task.CompletedTask;
				});
			string selectedFilename = _fileSelectionControl.SelectedFilename;
			if (selectedFilename == null)
			{
				return;
			}
			try
			{
				DirectBitmap loadedImage = DirectBitmap.FromFile(selectedFilename);
				_previewControl.OriginalImage = loadedImage;
				_filterListControl.InputImage = loadedImage;
			}
			catch (IOException)
			{
				return;
			}
			UpdatePreview();
		}

		private void FilterListControl_ListChanged(object sender, EventArgs e)
		{
			UpdatePreview();
		}

		private void UpdatePreview()
		{
			_previewUpdater.Update(() =>
			{
				if (_previewControl.OriginalImage == null)
				{
					return Task.CompletedTask;
				}
				// Create filters and copy bitmap synchronously - they are accessible from outside, potential race condition
				IEnumerable<IImageFilter> filters = _filterListControl.CreateFilters();
				DirectBitmap inputImageCopy = _previewControl.OriginalImage.Copy();
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
	}
}
