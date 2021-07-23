using System;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			ShowScene(loadScene);
		}

		private void ShowScene(UserControl scene)
		{
			scene.BringToFront();
		}

		private void SceneTabs_LoadTabSelected(object sender, EventArgs e)
		{
			ShowScene(loadScene);
		}

		private void ProcessScene_Process(object sender, EventArgs e)
		{
			// TODO: do not create this method, but provide a getter for filenames to the process scene
		}
	}
}
