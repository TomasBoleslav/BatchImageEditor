using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace BatchImageEditor
{
	public partial class AppForm : Form
	{
		public AppForm()
		{
			InitializeComponent();
		}

		private List<string> filenames = new List<string>();

		private void Form_Load(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		private void Form_Resize(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		private void CenterMenuButtons()
		{
			menuButtonsPanel.Location = new Point
			{
				X = (Width - menuButtonsPanel.Width) / 2,
				Y = menuButtonsPanel.Location.Y
			};
		}

		private void loadImageButton_Click(object sender, EventArgs e)
		{
			try
			{
				using (var dialog = new OpenFileDialog())
				{
					dialog.Title = "Open Image";
					dialog.Filter =
						"Image files (*.bmp, *.gif, *.jpg, *.jpeg, *.png) | " +
						"*.bmp; *.gif; *.jpg; *.jpeg; *.png";
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						MessageBox.Show($"Loaded file: {dialog.FileName}");
						Bitmap bitmap = null;
						try
						{
							bitmap = new Bitmap(dialog.FileName);
						}
						catch (ArgumentException)
						{
							MessageBox.Show("File is not an image");
						}
						var fileInfo = new FileInfo(dialog.FileName);
						ListViewItem newItem = CreateImageListViewItem(fileInfo, bitmap);
						imageListView.Items.Add(newItem);
						filenames.Add(dialog.FileName);
					}
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("File could not be found");
			}
			catch (IOException)
			{
				MessageBox.Show("File could not be read");
			}
		}

		private ListViewItem CreateImageListViewItem(
			FileInfo fileInfo, Bitmap bitmap)
		{
			string[] columnItems = new string[]
			{
				fileInfo.Name,
				fileInfo.CreationTime.ToString(),
				$"{bitmap.Width} x {bitmap.Height}",
				$"{fileInfo.Length / 1024} kB"
			};
			return new ListViewItem(columnItems, -1);
		}

		private void loadFolderButton_Click(object sender, EventArgs e)
		{

		}

		private void imageListView_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if ((e.State & ListViewItemStates.Selected) != 0)
			{
				// Draw the background and focus rectangle for a selected item.
				e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
				e.DrawFocusRectangle();
			}
			else
			{
				e.Graphics.FillRectangle(Brushes.Blue, e.Bounds);
			}

			// Draw the item text for views other than the Details view.
			if (imageListView.View != View.Details)
			{
				e.DrawText();
			}
		}

		private void imageListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			TextFormatFlags flags = TextFormatFlags.Left;
			switch (e.Header.TextAlign)
			{
				case HorizontalAlignment.Center:
					flags = TextFormatFlags.HorizontalCenter;
					break;
				case HorizontalAlignment.Right:
					flags = TextFormatFlags.Right;
					break;
			}
			e.DrawText(flags);
		}

		private void imageListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			using (var stringFormat = new StringFormat())
			{
				// Store the column text alignment, letting it default
				// to Left if it has not been set to Center or Right.
				stringFormat.LineAlignment = StringAlignment.Center;
				switch (e.Header.TextAlign)
				{
					case HorizontalAlignment.Center:
						stringFormat.Alignment = StringAlignment.Center;
						break;
					case HorizontalAlignment.Right:
						stringFormat.Alignment = StringAlignment.Far;
						break;
				}

				// Draw the standard header background.
				//e.DrawBackground();
				using (var brush = new SolidBrush(Color.FromArgb(31, 31, 31)))
				{
					e.Graphics.FillRectangle(brush, e.Bounds);
				}

				e.Graphics.DrawString(
					e.Header.Text, this.Font,
					Brushes.Black, e.Bounds, stringFormat);
			}
		}

		private void imageListView_MouseUp(object sender, MouseEventArgs e)
		{

		}

		private void imageListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
		{

		}

	}
}
