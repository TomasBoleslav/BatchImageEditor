using System;
using System.Collections;
using System.Collections.Generic;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// A generator of <see cref="ImageProcessingJob"/>.
	/// </summary>
	public class ImageProcessingJobSource : IEnumerable<ImageProcessingJob>
	{
		/// <summary>
		/// Creates an instance of <see cref="ImageProcessingJobSource"/> that will create jobs processing images from the given files.
		/// </summary>
		/// <param name="inputFilenames">Names of input files.</param>
		/// <param name="outputFilenameFunc">A function that computes output filename from input filename.</param>
		/// <param name="filters">Image filter to use for processing images.</param>
		public ImageProcessingJobSource(IReadOnlySet<string> inputFilenames, Func<string, string> outputFilenameFunc, IEnumerable<IImageFilter> filters)
		{
			ArgChecker.NotNull(inputFilenames, nameof(inputFilenames));
			ArgChecker.NotNull(outputFilenameFunc, nameof(outputFilenameFunc));
			ArgChecker.NotNull(filters, nameof(filters));
			_inputFilenames = inputFilenames;
			_outputFilenameFunc = outputFilenameFunc;
			_filters = filters;
		}

		/// <summary>
		/// Gets or sets a function that will be used when a job succeeded.
		/// </summary>
		public Action<ImageProcessingJob> SuccessCallback { get; set; }

		/// <summary>
		/// Gets or sets a function that will be used when a job failed.
		/// </summary>
		public Action<ImageProcessingJob, string> FailCallback { get; set; }

		/// <summary>
		/// Returns an enumerator that lazily generates the jobs.
		/// </summary>
		public IEnumerator<ImageProcessingJob> GetEnumerator()
		{
			foreach (string inputFilename in _inputFilenames)
			{
				string outputFilename = _outputFilenameFunc.Invoke(inputFilename);
				yield return new ImageProcessingJob(inputFilename, outputFilename, _filters)
				{ 
					SuccessCallback = SuccessCallback,
					FailCallback = FailCallback
				};
			}
		}

		/// <summary>
		/// Returns the same enumerator as the generic alternative.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private readonly IReadOnlySet<string> _inputFilenames;
		private readonly Func<string, string> _outputFilenameFunc;
		private readonly IEnumerable<IImageFilter> _filters;
	}
}
