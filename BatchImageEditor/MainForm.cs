using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}


		/*
		private static readonly string[] SupportedExtensions = { ".jpg", ".jpeg", ".bmp", ".gif", ".png" };
		private FileListViewManager loadedImages;
		private (Button menuButton, Panel scenePanel) currentScene;

		private void Form_Load(object sender, EventArgs e)
		{
			CenterMenuButtons();
			currentScene = (menuLoadButton, loadScenePanel);
			loadedImages = new FileListViewManager(imageListView,
				nameHeader, dateHeader, sizeHeader, pathHeader);
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
		*/
	}
}
