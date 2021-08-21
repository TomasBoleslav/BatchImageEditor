using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// An edit scene of the editor.
	/// </summary>
	internal partial class EditScene : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="EditScene"/>.
		/// </summary>
		public EditScene()
		{
			InitializeComponent();
			_previewUpdater = new UIUpdater();
		}

		/// <summary>
		/// Occurs when the list of filters is changed.
		/// </summary>
		public event EventHandler FilterListChanged;

		/// <summary>
		/// Sets input filenames.
		/// </summary>
		/// <param name="filenames"></param>
		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_fileSelectionControl.SetFilenames(filenames);
		}

		/// <summary>
		/// Creates a collection of <see cref="IImageFilter"/> to be used for filtering images.
		/// </summary>
		/// <returns>A collection of <see cref="IImageFilter"/> to be used for filtering images.</returns>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			return _filterListControl.CreateFilters();
		}

		private readonly UIUpdater _previewUpdater;

		/// <summary>
		/// Updates the preview image with a new input image and created filters.
		/// </summary>
		private void FileSelectionControl_SelectionChanged(object sender, EventArgs e)
		{
			_previewControl.OriginalImage?.Dispose();
			_previewControl.OriginalImage = null;
			_filterListControl.InputImage = null;
			_previewUpdater.Update(
				() =>
				{
					// Run this in Update to execute after a pending update
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

		/// <summary>
		/// Invokes the <see cref="FilterListChanged"/> event and updates the preview.
		/// </summary>
		private void FilterListControl_ListChanged(object sender, EventArgs e)
		{
			FilterListChanged?.Invoke(this, EventArgs.Empty);
			UpdatePreview();
		}

		/// <summary>
		/// Updates preview from current original image with created filters.
		/// </summary>
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

		/// <summary>
		/// Applies a collection of filters on an image.
		/// </summary>
		private static void ApplyFilters(ref DirectBitmap image, IEnumerable<IImageFilter> filters)
		{
			foreach (var filter in filters)
			{
				filter.Apply(ref image);
			}
		}
	}
}
