using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
		}

		private (Button menuButton, Panel scenePanel) currentScene;
		private List<string> filenames = new List<string>();

		private void Form_Load(object sender, EventArgs e)
		{
			CenterMenuButtons();
			currentScene = (menuLoadButton, loadScenePanel);
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
			oldButton.BackColor = SystemColors.ControlDarkDark;
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

	}
}
