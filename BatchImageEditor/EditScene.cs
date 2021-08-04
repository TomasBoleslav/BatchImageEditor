using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class EditScene : UserControl
	{
		public EditScene()
		{
			InitializeComponent();
		}

		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_fileSelectionControl.SetFilenames(filenames);
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			return _filterListControl.CreateFilters();
		}

		private void FileSelectionControl_SelectionChanged(object sender, EventArgs e)
		{
			_previewControl.OriginalImage?.Dispose();
			_previewControl.OriginalImage = null;
			_previewControl.UpdatePreviewAsync(() =>
				{
					_previewControl.PreviewImage?.Dispose();// TODO: problem, this will be run in parallel -> access from another thread + exception after disposing
					return null;
				});
			//_previewControl.PreviewImage?.Dispose();
			//_previewControl.PreviewImage = null;
			string selectedFilename = _fileSelectionControl.SelectedFilename;
			if (selectedFilename == null)
			{
				return;
			}
			try
			{
				_previewControl.OriginalImage = DirectBitmap.FromFile(selectedFilename);
			}
			catch (IOException)
			{
				return;
			}
			_previewControl.UpdatePreviewAsync(() =>
			{
				DirectBitmap newPreviewImage = CreatePreviewImage(_previewControl.OriginalImage);
				_filterListControl.InputImage = newPreviewImage;
				return newPreviewImage;
			});
			_previewControl.PreviewImage = CreatePreviewImage(_previewControl.OriginalImage);
		}

		private void FilterListControl_ListChanged(object sender, EventArgs e)
		{
			if (_previewControl.OriginalImage != null)
			{
				_previewControl.UpdatePreviewAsync(() =>
				{
					DirectBitmap newPreviewImage = CreatePreviewImage(_previewControl.OriginalImage);
					_filterListControl.InputImage = newPreviewImage;	// TODO: this is asynchronous, must be run in BeginInvoke
					return newPreviewImage;
				});
				_previewControl.PreviewImage?.Dispose(); // TODO: long pause between Dispose and CreatePreview - this cannot be done in async version
				_previewControl.PreviewImage = CreatePreviewImage(_previewControl.OriginalImage);
				_filterListControl.InputImage = _previewControl.PreviewImage;
			}
		}

		private DirectBitmap CreatePreviewImage(DirectBitmap original)
		{
			IEnumerable<IImageFilter> filters = _filterListControl.CreateFilters();
			//filters = filters.Concat(new List<IImageFilter> { new ColorAdjustingFilter(new RgbColorAdjuster(255, 0, 0)) });// TODO: remove
			DirectBitmap previewImage = original.Copy();
			foreach (var filter in filters)
			{
				filter.Apply(ref previewImage);
			}
			return previewImage;
			/*ParallelHelper.FilterImageAsync(_previewImage, filters,
				() => BeginInvoke((MethodInvoker)(() =>
				{
					_previewControl.SetNewImage(_originalImage.Bitmap, _previewImage.Bitmap);
					_filterListControl.InputBitmap = _previewImage;
				})));*/
			//_previewControl.SetNewImage(_originalImage.Bitmap, _previewImage.Bitmap);
			//_filterListControl.InputBitmap = _previewImage;
		}
	}
}
