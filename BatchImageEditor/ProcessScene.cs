using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class ProcessScene : UserControl
	{
		public ProcessScene()
		{
			InitializeComponent();
		}

		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_filenames = filenames;
		}

		public void SetFilters(IEnumerable<IImageFilter> filters)
		{
			_filters = filters;
		}

		private IReadOnlySet<string> _filenames;
		private IEnumerable<IImageFilter> _filters;

		private void SelectOutputFolderButton_Click(object sender, EventArgs e)
		{
			using var folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				_outputFolderBox.Text = folderDialog.SelectedPath;
			}
		}

		private void CoreCountCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_coreCountCheckBox.Checked)
			{
				_threadCountInput.Value = Environment.ProcessorCount;
				_threadCountInput.Enabled = false;
			}
			else
			{
				_threadCountInput.Enabled = true;
			}
		}

		private void ProcessButton_Click(object sender, EventArgs e)
		{
			// create UserControl as a new window with progress and log and open it modally
			// 
		}
	}
}
