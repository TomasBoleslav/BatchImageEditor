using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security;

namespace BatchImageEditor
{
	/// <summary>
	/// A load scene in the editor.
	/// </summary>
	internal sealed partial class LoadScene : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="LoadScene"/>.
		/// </summary>
		public LoadScene()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets a set of chosen filenames.
		/// </summary>
		public IReadOnlySet<string> GetFilenames()
		{
			return _filenames;
		}

		/// <summary>
		/// Occurs when the set of filenames chaned.
		/// </summary>
		public event EventHandler FileSetChanged;

		private const string NotAvailable = "N/A";
		
		private readonly HashSet<string> _filenames = new();

		/// <summary>
		/// Invokes the <see cref="FileSetChanged"/> event.
		/// </summary>
		private void OnFileSetChanged()
		{
			FileSetChanged?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Loads new filenames of images using a dialog.
		/// </summary>
		private void LoadImageButton_Click(object sender, EventArgs e)
		{
			using var dialog = new OpenFileDialog();
			dialog.Title = "Select images";
			dialog.Filter = SupportedImages.GetDialogFilter();
			dialog.Multiselect = true;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_imageListView.BeginUpdate();
				foreach (string filename in dialog.FileNames)
				{
					AddOrUpdateFile(filename);
				}
				_imageListView.EndUpdate();
				OnFileSetChanged();
			}
		}

		/// <summary>
		/// Shows a preview of an image.
		/// </summary>
		/// <param name="filename">The name of the file containing the image.</param>
		private void ShowLoadedImagePreview(string filename)
		{
			loadedPreviewBox.Image?.Dispose();
			loadedPreviewBox.Image = null;
			try
			{
				using var loadedImage = new Bitmap(filename);
				loadedPreviewBox.Image = new Bitmap(loadedImage);
			}
			catch (Exception ex) when (ex is ArgumentException || ex is FileNotFoundException)
			{
				return;
			}
		}

		/// <summary>
		/// Shows a preview of the currently selected image.
		/// </summary>
		private void ImageListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected && _imageListView.SelectedItems.Count == 1)
			{
				string filename = GetFilenameFromItem(e.Item);
				ShowLoadedImagePreview(filename);
			}
			else if (_imageListView.SelectedItems.Count == 0)
			{
				loadedPreviewBox.Image?.Dispose();
				loadedPreviewBox.Image = null;
			}
		}

		/// <summary>
		/// Loads all image filenames in a folder using a dialog.
		/// </summary>
		private void LoadFolderButton_Click(object sender, EventArgs e)
		{
			using var folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				LoadFolder(folderDialog.SelectedPath);
				OnFileSetChanged();
			}
		}

		/// <summary>
		/// Loads all filenames in the given folder recursively.
		/// </summary>
		/// <param name="folder">The folder to load filenames from.</param>
		private void LoadFolder(string folder)
		{
			var extensions = SupportedImages.GetFileExtensions().ToHashSet();
			var filenames = Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories);
			_imageListView.BeginUpdate();
			foreach (string filename in filenames)
			{
				string extension = Path.GetExtension(filename).ToLowerInvariant();
				if (extensions.Contains(extension))
				{
					AddOrUpdateFile(filename);
				}
			}
			_imageListView.EndUpdate();
		}

		/// <summary>
		/// Removes all currently selected filenames.
		/// </summary>
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		/// <summary>
		/// Adds or updates information of a file in the list view.
		/// </summary>
		/// <param name="filename">The name of the file to add or update.</param>
		private void AddOrUpdateFile(string filename)
		{
			ListViewItem item = CreateImageListItem(filename);
			if (!_filenames.Contains(filename))
			{
				_imageListView.Items.Add(item);
				_filenames.Add(filename);
			}
			else
			{
				ListViewItem oldItem = GetItemByFilename(filename);
				_imageListView.Items[oldItem.Index] = item;
			}
		}

		/// <summary>
		/// Removes a file item from stored filenames.
		/// </summary>
		/// <param name="item">An item to remove.</param>
		private void RemoveFileItem(ListViewItem item)
		{
			string filename = GetFilenameFromItem(item);
			_filenames.Remove(filename);
			_imageListView.Items.Remove(item);
		}

		/// <summary>
		/// Gets a filename from an item in the list view.
		/// </summary>
		/// <param name="item">An item in the list view.</param>
		/// <returns>A filename in the list view.</returns>
		private string GetFilenameFromItem(ListViewItem item)
		{
			return item.SubItems[_pathHeader.Index].Text;
		}

		/// <summary>
		/// Removes all currently selected filenames.
		/// </summary>
		private void RemoveSelectedItems()
		{
			// Must be copied, because the list of selected items changes on removal
			var selectedItems = _imageListView.SelectedItems.Cast<ListViewItem>().ToList();
			if (selectedItems.Count > 0)
			{
				_imageListView.BeginUpdate();
				foreach (var item in selectedItems)
				{
					RemoveFileItem(item);
				}
				_imageListView.EndUpdate();
				OnFileSetChanged();
			}
		}

		/// <summary>
		/// Creates a list view item by inspecting information of the given file.
		/// </summary>
		/// <param name="filename">The name of the file.</param>
		/// <returns>A list view item containing information about the given file.</returns>
		private ListViewItem CreateImageListItem(string filename)
		{
			string[] columns = new string[_imageListView.Columns.Count];
			columns[_nameHeader.Index] = NotAvailable;
			columns[_dateHeader.Index] = NotAvailable;
			columns[_sizeHeader.Index] = NotAvailable;
			columns[_pathHeader.Index] = filename;
			try
			{
				var fileInfo = new FileInfo(filename);
				columns[_nameHeader.Index] = fileInfo.Name;
				columns[_dateHeader.Index] = fileInfo.CreationTime.ToString();
				columns[_sizeHeader.Index] = $"{fileInfo.Length / 1024} kB";
				return new ListViewItem(columns, -1);
			}
			catch (Exception ex) when (
				ex is IOException ||
				ex is UnauthorizedAccessException ||
				ex is SecurityException)
			{
				return new ListViewItem(columns, -1);
			}
		}

		/// <summary>
		/// Gets an item by the name of a file.
		/// </summary>
		/// <param name="filename">The name of a file.</param>
		/// <returns>The item containing the given name of a file.</returns>
		private ListViewItem GetItemByFilename(string filename)
		{
			return _imageListView.Items.Cast<ListViewItem>()
				.Where(item => GetFilenameFromItem(item) == filename)
				.First();
		}
	}
}
