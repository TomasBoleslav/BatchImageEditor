using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class AppForm : Form
	{
		public AppForm()
		{
			InitializeComponent();
			currentScene = (menuLoadButton, loadScenePanel);
			loadedImages = new FileListViewManager(imageListView,
				nameHeader, dateHeader, sizeHeader, pathHeader);
		}

		private static readonly string[] SupportedExtensions = { ".jpg", ".jpeg", ".bmp", ".gif", ".png" };
		private readonly FileListViewManager loadedImages;
		private (Button menuButton, Panel scenePanel) currentScene;
		
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

		private void ShowScene(Button menuButton, Panel scenePanel)
		{
			Button oldButton = currentScene.menuButton;
			if (oldButton == menuButton)
			{
				return;
			}
			oldButton.ForeColor = SystemColors.Window;
			oldButton.BackColor = Color.Transparent;
			oldButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			oldButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;

			menuButton.ForeColor = SystemColors.ControlText;
			menuButton.BackColor = SystemColors.Control;
			menuButton.FlatAppearance.MouseDownBackColor = SystemColors.Control;
			menuButton.FlatAppearance.MouseOverBackColor = SystemColors.Control;

			scenePanel.BringToFront();
			currentScene = (menuButton, scenePanel);
		}

		private void menuLoadButton_Click(object sender, EventArgs e)
		{
			ShowScene(menuLoadButton, loadScenePanel);
		}

		private void menuEditButton_Click(object sender, EventArgs e)
		{
			ShowScene(menuEditButton, editScenePanel);
		}

		private void menuProcessButton_Click(object sender, EventArgs e)
		{
			ShowScene(menuProcessButton, processScenePanel);
		}

		private void loadImageButton_Click(object sender, EventArgs e)
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
					loadedImages.AddOrUpdate(filename);
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
			catch (Exception ex)
			{
				if (ex is ArgumentException ||
					ex is FileNotFoundException)
				{
					return;
				}
				throw;
			}
		}

		private void imageListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected && imageListView.SelectedItems.Count == 1)
			{
				string filename = loadedImages.GetFilename(e.Item);
				ShowLoadedImagePreview(filename);
			}
			else if (imageListView.SelectedItems.Count == 0)
			{
				loadedPreviewBox.Image?.Dispose();
				loadedPreviewBox.Image = null;
			}
		}

		private void loadFolderButton_Click(object sender, EventArgs e)
		{
			using var folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK) //&& !string.IsNullOrWhiteSpace(fbd.SelectedPath))
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
					loadedImages.AddOrUpdate(filename);
				}
			}
		}
	}
}
