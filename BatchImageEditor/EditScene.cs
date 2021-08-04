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
			_previewUpdater = new ControlUpdater<DirectBitmap>(_previewControl);
		}

		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_fileSelectionControl.SetFilenames(filenames);
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			return _filterListControl.CreateFilters();
		}

		private readonly ControlUpdater<DirectBitmap> _previewUpdater;

		private void FileSelectionControl_SelectionChanged(object sender, EventArgs e)
		{
			_previewControl.OriginalImage?.Dispose();
			_previewControl.OriginalImage = null;
			_previewUpdater.UpdateAsync(() => null,
				_ =>
				{
					_previewControl.PreviewImage?.Dispose();
					_previewControl.PreviewImage = null;
					_filterListControl.InputImage = null;
				});
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
			_previewUpdater.UpdateAsync(
				() => CreatePreviewImage(_previewControl.OriginalImage),
				image =>
				{
					_previewControl.PreviewImage = image;
					_filterListControl.InputImage = image;
				});
		}

		private void FilterListControl_ListChanged(object sender, EventArgs e)
		{
			if (_previewControl.OriginalImage != null)
			{
				_previewUpdater.UpdateAsync(
					() => CreatePreviewImage(_previewControl.OriginalImage),
					image =>
					{
						_previewControl.PreviewImage?.Dispose();
						_previewControl.PreviewImage = image;
						_filterListControl.InputImage = image;
					});
			}
		}

		private DirectBitmap CreatePreviewImage(DirectBitmap original)
		{
			IEnumerable<IImageFilter> filters = _filterListControl.CreateFilters();
			DirectBitmap previewImage = original.Copy();
			foreach (var filter in filters)
			{
				filter.Apply(ref previewImage);
			}
			return previewImage;
		}
	}
}
