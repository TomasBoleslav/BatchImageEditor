using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class ProcessScene : UserControl
	{
		public ProcessScene()
		{
			InitializeComponent();
			_threadCountInput.Minimum = 1;
			_threadCountInput.Maximum = MaxThreadCount;
			UpdateThreadCountInput();
		}

		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_filenames = filenames;
		}

		public void SetFilters(IEnumerable<IImageFilter> filters)
		{
			_filters = filters;
		}

		private static readonly int MaxThreadCount = 2 * Environment.ProcessorCount;
		private IReadOnlySet<string> _filenames;
		private IEnumerable<IImageFilter> _filters;

		private void UpdateThreadCountInput()
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
			UpdateThreadCountInput();
		}

		private void ProcessButton_Click(object sender, EventArgs e)
		{
			if (_filenames == null || _filenames.Count == 0)
			{
				MessageBox.Show($"No files selected, nothing to do.");
				return;
			}
			if (_filters == null || !_filters.Any())
			{
				MessageBox.Show($"No filters selected, nothing to do.");
				return;
			}
			string outputFolder = _outputFolderBox.Text;
			if (!Directory.Exists(outputFolder))
			{
				MessageBox.Show($"Folder '{outputFolder}' does not exist.");
				return;
			}
			int maxThreadCount = (int)_threadCountInput.Value;
			if (maxThreadCount == 1 && ShowContinuationForOneThreadPrompt() != DialogResult.Yes)
			{
				return;
			}
			using var processDialog = new ImageProcessingDialog()
			{
				Filenames = _filenames,
				Filters = _filters,
				MaxThreadCount = maxThreadCount,
				OutputFolder = outputFolder
			};
			processDialog.ShowDialog();
		}

		private DialogResult ShowContinuationForOneThreadPrompt()
		{
			DialogResult dialogResult = MessageBox.Show(
				"You selected 1 for the maximum number of threads. " +
				"This will slow down the response of the application significantly." + Environment.NewLine +
				"Do you wish to continue?",
				"One thread selected",
				MessageBoxButtons.YesNo);
			return dialogResult;
		}
	}
}
