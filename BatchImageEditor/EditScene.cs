using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
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

		private DirectBitmap _originalImage;
		private DirectBitmap _previewImage;

		private void FileSelectionControl_SelectionChanged(object sender, EventArgs e)
		{
			_originalImage?.Dispose();
			_originalImage = null;
			string selectedFilename = _fileSelectionControl.SelectedFilename;
			if (selectedFilename == null)
			{
				_previewControl.SetNewImage(null, null);
			}
			else
			{
				try
				{
					_originalImage = DirectBitmap.FromFile(selectedFilename);
				}
				catch (IOException)
				{
					_previewControl.SetNewImage(null, null);
					return;
				}
				UpdatePreview();
			}
		}

		private void FilterListControl_ListChanged(object sender, EventArgs e)
		{
			UpdatePreview();
		}

		private void UpdatePreview()
		{
			_previewImage?.Dispose();
			_previewImage = null;
			if (_originalImage == null)
			{
				_filterListControl.InputBitmap = null;
				return;
			}
			IEnumerable<IImageFilter> filters = _filterListControl.CreateFilters();
			filters = filters.Concat(new List<IImageFilter> { new ColorAdjustingFilter(new RgbColorAdjuster(255, 0, 0)) });// TODO: remove
			_previewImage = _originalImage.Copy();
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
