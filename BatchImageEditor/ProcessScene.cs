using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// The process scene of the editor.
	/// </summary>
	internal partial class ProcessScene : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="ProcessScene"/>
		/// </summary>
		public ProcessScene()
		{
			InitializeComponent();
			_threadCountInput.Minimum = 1;
			_threadCountInput.Maximum = MaxThreadCount;
			UpdateThreadCountInput();
		}

		/// <summary>
		/// Sets a set of input filenames.
		/// </summary>
		/// <param name="filenames">A new set of input filenames.</param>
		public void SetFilenames(IReadOnlySet<string> filenames)
		{
			_filenames = filenames;
		}

		/// <summary>
		/// Sets a colletion of filters to apply to images.
		/// </summary>
		/// <param name="filters">A colletion of filters to apply to images.</param>
		public void SetFilters(IEnumerable<IImageFilter> filters)
		{
			_filters = filters;
		}

		private static readonly int MaxThreadCount = 2 * Environment.ProcessorCount;
		private IReadOnlySet<string> _filenames;
		private IEnumerable<IImageFilter> _filters;

		/// <summary>
		/// Updates the displayed number of threads.
		/// </summary>
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

		/// <summary>
		/// Lets the user select an output folder using a dialog.
		/// </summary>
		private void SelectOutputFolderButton_Click(object sender, EventArgs e)
		{
			using var folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				_outputFolderBox.Text = folderDialog.SelectedPath;
			}
		}

		/// <summary>
		/// Updates the number of threads.
		/// </summary>
		private void CoreCountCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateThreadCountInput();
		}

		/// <summary>
		/// Opens an <see cref="ImageProcessingDialog"/> to process images.
		/// </summary>
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

		/// <summary>
		/// Shows a <see cref="MessageBox"/> to let the user choose if they wish to continue with sequential computing.
		/// </summary>
		/// <returns>The result of the dialog.</returns>
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
