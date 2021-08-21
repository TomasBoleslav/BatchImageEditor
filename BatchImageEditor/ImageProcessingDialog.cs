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
	public partial class ImageProcessingDialog : Form
	{
		public ImageProcessingDialog()
		{
			InitializeComponent();
			OutputFolder = "";
			_statusContentLabel.Text = "";
			_errorCountLabel.Text = "0";
		}

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

		private void ImageProcessingDialog_Shown(object sender, EventArgs e)
		{
			// TODO: are all controls already initialized here?
			_headingLabel.Text = $"Processing a total of {_filenames.Count} images";
			Run();
		}

		private void Run()
		{
			Action<ImageProcessingJob> successCallback;
			Action<ImageProcessingJob, string> failCallback;
			if (MaxThreadCount > 1)
			{
				successCallback = ReportSuccessInParallel;
				failCallback = ReportErrorInParallel;
			}
			else
			{
				_lastUpdateTime = DateTime.Now;
				successCallback = ReportSuccessSequentially;
				failCallback = ReportErrorSequentially;
			}
			var jobSource = new ImageProcessingJobSource(_filenames, GetOutputFilePathFromInput, _filters)
			{
				SuccessCallback = successCallback,
				FailCallback = failCallback,
			};
			_batchProcessor = new BatchProcessor(jobSource, _maxThreadCount);
			_batchProcessor.Run();
		}

		private string GetOutputFilePathFromInput(string inputFilePath)
		{
			string inputFilename = Path.GetFileName(inputFilePath);
			return Path.Join(OutputFolder, inputFilename);
		}

		private void ReportSuccess(ImageProcessingJob successfulJob)
		{
			if (_computationCanceled)
			{
				return;
			}
			IncrementProgress();
		}

		private void ReportSuccessInParallel(ImageProcessingJob successfulJob)
		{
			BeginInvokeIfRequired(() =>	ReportSuccess(successfulJob));
		}

		private void ReportSuccessSequentially(ImageProcessingJob successfulJob)
		{
			ReportSuccess(successfulJob);
			UpdateDialogAfterTimeInterval();
		}

		private void ReportError(ImageProcessingJob failedJob, string errorMessage)
		{
			if (_computationCanceled)
			{
				return;
			}
			AddNewError(failedJob.InputFilename, failedJob.OutputFilename, errorMessage);
			IncrementProgress();
		}

		private void ReportErrorInParallel(ImageProcessingJob failedJob, string errorMessage)
		{
			BeginInvokeIfRequired(() => ReportError(failedJob, errorMessage));
		}

		private void ReportErrorSequentially(ImageProcessingJob failedJob, string errorMessage)
		{
			ReportError(failedJob, errorMessage);
			UpdateDialogAfterTimeInterval();
		}

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

		private void AddNewError(string inputFilename, string outputFilename, string errorMessage)
		{
			_errorCount++;
			_errorCountLabel.Text = $"{_errorCount}";
			string[] columns = new string[_errorsListView.Columns.Count];
			columns[_inFilenameColumn.Index] = inputFilename;
			columns[_outFilenameColumn.Index] = outputFilename;
			columns[_errorMessageColumn.Index] = errorMessage;
			_errorsListView.Items.Add(new ListViewItem(columns, -1));
		}

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

		private void UpdateDialogAfterTimeInterval()
		{
			TimeSpan elapsedTime = DateTime.Now - _lastUpdateTime;
			if (elapsedTime.TotalMilliseconds >= UpdateTimeInterval)
			{
				Application.DoEvents();
			}
		}

		private void ImageProcessingDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			CancelComputation();
			_batchProcessor?.Dispose();
		}

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

		private void CancelButton_Click(object sender, EventArgs e)
		{
			CancelComputation();
			DialogResult = DialogResult.Cancel;
		}
	}
}
