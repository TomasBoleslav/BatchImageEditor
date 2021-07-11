using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security;

namespace BatchImageEditor
{
	class FileListViewManager
	{
		public FileListViewManager(ListView listView,
			ColumnHeader nameHeader, ColumnHeader dateHeader,
			ColumnHeader sizeHeader, ColumnHeader pathHeader)
		{
			this.listView = listView;
			nameIndex = nameHeader.Index;
			dateIndex = dateHeader.Index;
			sizeIndex = sizeHeader.Index;
			pathIndex = pathHeader.Index;
		}

		public void AddOrUpdate(string filename)
		{
			ListViewItem item = CreateImageListItem(filename);
			if (!filenames.Contains(filename))
			{
				listView.Items.Add(item);
				filenames.Add(filename);
			}
			else
			{
				ListViewItem oldItem = GetItemByFilename(filename);
				listView.Items[oldItem.Index] = item;
			}
		}

		public void Remove(ListViewItem item)
		{
			string filename = GetFilename(item);
			filenames.Remove(filename);
			listView.Items.Remove(item);
		}

		public string[] GetFilenames()
		{
			return filenames.ToArray();
		}

		public string GetFilename(ListViewItem item)
		{
			return item.SubItems[pathIndex].Text;
		}

		public void RemoveSelected()
		{
			// Must be copied, because the list of selected items changes on removal
			var selectedItems = listView.SelectedItems.Cast<ListViewItem>().ToList();
			foreach (var item in selectedItems)
			{
				Remove(item);
			}
		}

		private const int ColumnCount = 4;
		private const string NotAvailable = "N/A";

		private readonly ListView listView;
		private readonly HashSet<string> filenames = new HashSet<string>();
		
		private readonly int nameIndex;
		private readonly int dateIndex;
		private readonly int sizeIndex;
		private readonly int pathIndex;

		private ListViewItem CreateImageListItem(string filename)
		{
			string[] columns = new string[ColumnCount];
			columns[nameIndex] = NotAvailable;
			columns[dateIndex] = NotAvailable;
			columns[sizeIndex] = NotAvailable;
			columns[pathIndex] = filename;
			try
			{
				var fileInfo = new FileInfo(filename);
				columns[nameIndex] = fileInfo.Name;
				columns[dateIndex] = fileInfo.CreationTime.ToString();
				columns[sizeIndex] = $"{fileInfo.Length / 1024} kB";
			}
			catch (Exception ex)
			{
				if (
					!(ex is IOException ||
					ex is UnauthorizedAccessException ||
					ex is SecurityException))
				{
					throw;
				}
			}
			return new ListViewItem(columns, -1);
		}

		private ListViewItem GetItemByFilename(string filename)
		{
			return listView.Items.Cast<ListViewItem>()
				.Where(item => GetFilename(item) == filename)
				.First();
		}
	}
}
