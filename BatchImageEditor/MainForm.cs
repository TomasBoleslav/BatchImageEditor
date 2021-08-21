using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// The main form of the editor.
	/// </summary>
	internal partial class MainForm : Form
	{
		/// <summary>
		/// Creates an instance of <see cref="MainForm"/>.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			ShowScene(_loadScene);
		}

		/// <summary>
		/// Shows the given user control as a new scene.
		/// </summary>
		/// <param name="scene">A scene to show.</param>
		private static void ShowScene(UserControl scene)
		{
			scene.BringToFront();
		}

		/// <summary>
		/// Shows the load scene.
		/// </summary>
		private void SceneTabs_LoadTabSelected(object sender, EventArgs e)
		{
			ShowScene(_loadScene);
		}

		/// <summary>
		/// Shows the edit scene.
		/// </summary>
		private void SceneTabs_EditTabSelected(object sender, EventArgs e)
		{
			ShowScene(_editScene);
		}

		/// <summary>
		/// Shows the process scene.
		/// </summary>
		private void SceneTabs_ProcessTabSelected(object sender, EventArgs e)
		{
			ShowScene(_processScene);
		}

		/// <summary>
		/// Updates the set of filenames in edit scene and process scene.
		/// </summary>
		private void LoadScene_FileSetChanged(object sender, EventArgs e)
		{
			IReadOnlySet<string> filenames = _loadScene.GetFilenames();
			_editScene.SetFilenames(filenames);
			_processScene.SetFilenames(filenames);
		}

		/// <summary>
		/// Updates the collection of filters in the process scene.
		/// </summary>
		private void EditScene_FilterListChanged(object sender, EventArgs e)
		{
			IEnumerable<IImageFilter> filters = _editScene.CreateFilters();
			_processScene.SetFilters(filters);
		}
	}
}
