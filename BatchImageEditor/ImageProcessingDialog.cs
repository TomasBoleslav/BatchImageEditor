using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// A dialog form that processes images with filters and shows progress to the user.
	/// </summary>
	internal sealed partial class ImageProcessingDialog : Form
	{
		/// <summary>
		/// Creates an instance of <see cref="ImageProcessingDialog"/>.
		/// </summary>
		public ImageProcessingDialog()
		{
			InitializeComponent();
			OutputFolder = "";
			_statusContentLabel.Text = "";
			_errorCountLabel.Text = "0";
		}

		/// <summary>
		/// Gets or sets the files that will be processed.
		/// </summary>
		public IReadOnlySet<string> Filenames
		{
			get
			{
				return _filenames;
			}
			set
			{
				ArgChecker.NotNull(value, nameof(value));
				_filenames = value;
			}
		}

		/// <summary>
		/// Gets or sets the filters that should be used.
		/// </summary>
		public IEnumerable<IImageFilter> Filters
		{
			get
			{
				return _filters;
			}
			set
			{
				ArgChecker.NotNull(value, nameof(value));
				_filters = value;
			}
		}

		/// <summary>
		/// Gets or sets the maximum number of threads that should be used for processing images.
		/// </summary>
		public int MaxThreadCount
		{
			get
			{
				return _maxThreadCount;
			}
			set
			{
				ArgChecker.GreaterThan(value, nameof(value), 0);
				_maxThreadCount = value;
			}
		}

		/// <summary>
		/// Gets or sets the output folder where the processed images will be stored.
		/// </summary>
		public string OutputFolder { get; set; }

		private IReadOnlySet<string> _filenames = new HashSet<string>();
		private IEnumerable<IImageFilter> _filters = Enumerable.Empty<IImageFilter>();
		private int _maxThreadCount = Environment.ProcessorCount;

		private BatchProcessor _batchProcessor;
		private int _errorCount;
		private int _processedImageCount;
		private bool _computationCanceled;

		// Sequential execution
		private const int UpdateTimeInterval = 3000; // ms
		private DateTime _lastUpdateTime;

		/// <summary>
		/// Runs the process when dialog is shown.
		/// </summary>
		private void ImageProcessingDialog_Shown(object sender, EventArgs e)
		{
			_headingLabel.Text = $"Processing a total of {_filenames.Count} images";
			Run();
		}

		/// <summary>
		/// Runs the process with the current settings.
		/// </summary>
		private void Run()
		{
			Action<ImageProcessingJob> successCallback;
			Action<ImageProcessingJob, string> failCallback;
			if (MaxThreadCount > 1)
			{
				successCallback = ReportSuccessInParallel;
				failCallback = ReportFailureInParallel;
			}
			else
			{
				_lastUpdateTime = DateTime.Now;
				successCallback = ReportSuccessSequentially;
				failCallback = ReportFailureSequentially;
			}
			var jobSource = new ImageProcessingJobSource(_filenames, GetOutputFilePathFromInput, _filters)
			{
				SuccessCallback = successCallback,
				FailCallback = failCallback,
			};
			_batchProcessor = new BatchProcessor(jobSource, _maxThreadCount);
			_batchProcessor.Run();
		}

		/// <summary>
		/// Computes the path of an output file based on the path of the input file and the path of output folder.
		/// </summary>
		/// <param name="inputFilePath">The path of an input file.</param>
		/// <returns>The path of the output file.</returns>
		private string GetOutputFilePathFromInput(string inputFilePath)
		{
			string inputFilename = Path.GetFileName(inputFilePath);
			return Path.Join(OutputFolder, inputFilename);
		}

		/// <summary>
		/// Reports a success of an image processing job.
		/// </summary>
		/// <param name="successfulJob">A job that finished successfully.</param>
		private void ReportSuccess(ImageProcessingJob successfulJob)
		{
			if (_computationCanceled)
			{
				return;
			}
			IncrementProgress();
		}

		/// <summary>
		/// Reports a success of an image processing job when run in parallel.
		/// </summary>
		/// <param name="successfulJob">A job that finished successfully.</param>
		private void ReportSuccessInParallel(ImageProcessingJob successfulJob)
		{
			BeginInvokeIfRequired(() =>	ReportSuccess(successfulJob));
		}

		/// <summary>
		/// Reports a success of an image processing job when run sequentially.
		/// </summary>
		/// <param name="successfulJob">A job that finished successfully.</param>
		private void ReportSuccessSequentially(ImageProcessingJob successfulJob)
		{
			ReportSuccess(successfulJob);
			UpdateDialogAfterTimeInterval();
		}

		/// <summary>
		/// Reports a failure of an image processing job.
		/// </summary>
		/// <param name="failedJob">A job that failed.</param>
		/// <param name="errorMessage">An error message.</param>
		private void ReportFailure(ImageProcessingJob failedJob, string errorMessage)
		{
			if (_computationCanceled)
			{
				return;
			}
			AddNewErrorToList(failedJob.InputFilename, failedJob.OutputFilename, errorMessage);
			IncrementProgress();
		}

		/// <summary>
		/// Reports a failure of an image processing job when run in parallel.
		/// </summary>
		/// <param name="failedJob">A job that failed.</param>
		/// <param name="errorMessage">An error message.</param>
		private void ReportFailureInParallel(ImageProcessingJob failedJob, string errorMessage)
		{
			BeginInvokeIfRequired(() => ReportFailure(failedJob, errorMessage));
		}

		/// <summary>
		/// Reports a failure of an image processing job when run sequentially.
		/// </summary>
		/// <param name="failedJob">A job that failed.</param>
		/// <param name="errorMessage">An error message.</param>
		private void ReportFailureSequentially(ImageProcessingJob failedJob, string errorMessage)
		{
			ReportFailure(failedJob, errorMessage);
			UpdateDialogAfterTimeInterval();
		}

		/// <summary>
		/// Increments the progress when an image processing job finished.
		/// </summary>
		private void IncrementProgress()
		{
			_processedImageCount++;
			float progressInPercents = _processedImageCount * 100f / _filenames.Count;
			_progressBar.Value = (int)progressInPercents;
			if (_processedImageCount == _filenames.Count)
			{
				_statusContentLabel.Text = "done";
			}
			else
			{
				_statusContentLabel.Text = progressInPercents.ToString("N2") + "%";
			}
		}

		/// <summary>
		/// Adds an error to a list that is shown to the user.
		/// </summary>
		/// <param name="inputFilename">A name of a file containing an input image.</param>
		/// <param name="outputFilename">A name of a file where the processed image should be stored.</param>
		/// <param name="errorMessage">An error message.</param>
		private void AddNewErrorToList(string inputFilename, string outputFilename, string errorMessage)
		{
			_errorCount++;
			_errorCountLabel.Text = $"{_errorCount}";
			string[] columns = new string[_errorsListView.Columns.Count];
			columns[_inFilenameColumn.Index] = inputFilename;
			columns[_outFilenameColumn.Index] = outputFilename;
			columns[_errorMessageColumn.Index] = errorMessage;
			_errorsListView.Items.Add(new ListViewItem(columns, -1));
		}

		/// <summary>
		/// If required, runs BeginInvoke with the given action, otherwise executes the action normally.
		/// </summary>
		/// <param name="action"></param>
		private void BeginInvokeIfRequired(Action action)
		{
			if (InvokeRequired)
			{
				BeginInvoke(action);
			}
			else
			{
				action.Invoke();
			}
		}

		/// <summary>
		/// Updates this dialog after time interval.
		/// This is used only for sequential computation.
		/// </summary>
		private void UpdateDialogAfterTimeInterval()
		{
			TimeSpan elapsedTime = DateTime.Now - _lastUpdateTime;
			if (elapsedTime.TotalMilliseconds >= UpdateTimeInterval)
			{
				Application.DoEvents();
			}
		}

		/// <summary>
		/// Performs a cleanup when the form is closing.
		/// </summary>
		private void ImageProcessingDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			CancelComputation();
			_batchProcessor?.Dispose();
		}

		/// <summary>
		/// Cancels the computation.
		/// </summary>
		private void CancelComputation()
		{
			if (_batchProcessor.IsRunning && !_computationCanceled)
			{
				_computationCanceled = true;
				_statusContentLabel.Text = "canceling...";
				_statusContentLabel.Refresh();
				_batchProcessor.Cancel();
				try
				{
					_batchProcessor.WaitForCompletion();
				}
				catch (AggregateException ae)
				{
					foreach (Exception e in ae.InnerExceptions)
					{
						if (!(e is OperationCanceledException))
						{
							throw e;
						}
					}
				}
				_statusContentLabel.Text = "canceled";
			}
		}

		/// <summary>
		/// Cancels the computation and closes the dialog with Cancel dialog result.
		/// </summary>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			CancelComputation();
			DialogResult = DialogResult.Cancel;
		}
	}
}
