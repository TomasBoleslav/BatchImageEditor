using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BatchImageEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			ShowScene(_loadScene);
		}

		private void ShowScene(UserControl scene)
		{
			scene.BringToFront();
		}

		private void SceneTabs_LoadTabSelected(object sender, EventArgs e)
		{
			ShowScene(_loadScene);
		}

		private void ProcessScene_Process(object sender, EventArgs e)
		{
			// TODO: do not create this method, but provide a getter for filenames to the process scene
		}

		private void LoadScene_FileSetChanged(object sender, EventArgs e)
		{
			IReadOnlySet<string> filenames = _loadScene.GetFilenames();
			_editScene.SetFilenames(filenames);
		}

		private void SceneTabs_EditTabSelected(object sender, EventArgs e)
		{
			ShowScene(_editScene);
		}
	}
}
