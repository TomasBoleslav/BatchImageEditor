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
	public partial class LoadScene : UserControl
	{
		public LoadScene()
		{
			InitializeComponent();
		}

		public string[] GetAllFilenames()
		{
			return filenames.ToArray();
		}

		private const string NotAvailable = "N/A";
		private static readonly string[] SupportedExtensions = { ".jpg", ".jpeg", ".bmp", ".gif", ".png" };
		
		private readonly HashSet<string> filenames = new();

		private void LoadImageButton_Click(object sender, EventArgs e)
		{
			using var dialog = new OpenFileDialog();
			dialog.Title = "Select images";
			var joinedExtensions = string.Join(';', SupportedExtensions.Select(ext => $"*{ext}"));
			dialog.Filter = $"Image files ({joinedExtensions}) | {joinedExtensions}";
			dialog.Multiselect = true;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string filename in dialog.FileNames)
				{
					AddOrUpdateFile(filename);
				}
			}
		}

		private void ShowLoadedImagePreview(string filename)
		{
			loadedPreviewBox.Image?.Dispose();
			loadedPreviewBox.Image = null;
			try
			{
				loadedPreviewBox.Image = new Bitmap(filename);
			}
			catch (Exception ex) when (ex is ArgumentException || ex is FileNotFoundException)
			{
				return;
			}
		}

		private void ImageListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected && imageListView.SelectedItems.Count == 1)
			{
				string filename = GetFilenameFromItem(e.Item);
				ShowLoadedImagePreview(filename);
			}
			else if (imageListView.SelectedItems.Count == 0)
			{
				loadedPreviewBox.Image?.Dispose();
				loadedPreviewBox.Image = null;
			}
		}

		private void LoadFolderButton_Click(object sender, EventArgs e)
		{
			using var folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				LoadFolder(folderDialog.SelectedPath);
			}
		}

		private void LoadFolder(string folder)
		{
			var extensions = SupportedExtensions.ToHashSet();
			var filenames = Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories);
			foreach (string filename in filenames)
			{
				string extension = Path.GetExtension(filename).ToLowerInvariant();
				if (extensions.Contains(extension))
				{
					AddOrUpdateFile(filename);
				}
			}
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		private void AddOrUpdateFile(string filename)
		{
			ListViewItem item = CreateImageListItem(filename);
			if (!filenames.Contains(filename))
			{
				imageListView.Items.Add(item);
				filenames.Add(filename);
			}
			else
			{
				ListViewItem oldItem = GetItemByFilename(filename);
				imageListView.Items[oldItem.Index] = item;
			}
		}

		private void RemoveFileItem(ListViewItem item)
		{
			string filename = GetFilenameFromItem(item);
			filenames.Remove(filename);
			imageListView.Items.Remove(item);
		}

		private string GetFilenameFromItem(ListViewItem item)
		{
			return item.SubItems[pathHeader.Index].Text;
		}

		private void RemoveSelectedItems()
		{
			// Must be copied, because the list of selected items changes on removal
			var selectedItems = imageListView.SelectedItems.Cast<ListViewItem>().ToList();
			foreach (var item in selectedItems)
			{
				RemoveFileItem(item);
			}
		}

		private ListViewItem CreateImageListItem(string filename)
		{
			string[] columns = new string[imageListView.Columns.Count];
			columns[nameHeader.Index] = NotAvailable;
			columns[dateHeader.Index] = NotAvailable;
			columns[sizeHeader.Index] = NotAvailable;
			columns[pathHeader.Index] = filename;
			try
			{
				var fileInfo = new FileInfo(filename);
				columns[nameHeader.Index] = fileInfo.Name;
				columns[dateHeader.Index] = fileInfo.CreationTime.ToString();
				columns[sizeHeader.Index] = $"{fileInfo.Length / 1024} kB";
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

		private ListViewItem GetItemByFilename(string filename)
		{
			return imageListView.Items.Cast<ListViewItem>()
				.Where(item => GetFilenameFromItem(item) == filename)
				.First();
		}
	}
}
