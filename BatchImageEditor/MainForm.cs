using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			ShowScene(_loadScene);
		}

		private static void ShowScene(UserControl scene)
		{
			scene.BringToFront();
		}

		private void SceneTabs_LoadTabSelected(object sender, EventArgs e)
		{
			ShowScene(_loadScene);
		}

		private void SceneTabs_EditTabSelected(object sender, EventArgs e)
		{
			ShowScene(_editScene);
		}

		private void SceneTabs_ProcessTabSelected(object sender, EventArgs e)
		{
			ShowScene(_processScene);
		}

		private void LoadScene_FileSetChanged(object sender, EventArgs e)
		{
			IReadOnlySet<string> filenames = _loadScene.GetFilenames();
			_editScene.SetFilenames(filenames);
			_processScene.SetFilenames(filenames);
		}

		private void EditScene_FilterListChanged(object sender, EventArgs e)
		{
			IEnumerable<IImageFilter> filters = _editScene.CreateFilters();
			_processScene.SetFilters(filters);
		}
	}
}
