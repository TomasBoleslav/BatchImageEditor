using System;
using System.Collections;
using System.Collections.Generic;
using ThrowHelpers;

namespace ImageFilters
{
	public class ImageProcessingJobSource : IEnumerable<ImageProcessingJob>
	{
		public ImageProcessingJobSource(IReadOnlySet<string> inputFilenames, Func<string, string> outputFilenameFunc, IEnumerable<IImageFilter> filters)
		{
			ArgChecker.NotNull(inputFilenames, nameof(inputFilenames));
			ArgChecker.NotNull(outputFilenameFunc, nameof(outputFilenameFunc));
			ArgChecker.NotNull(filters, nameof(filters));
			_inputFilenames = inputFilenames;
			_outputFilenameFunc = outputFilenameFunc;
			_filters = filters;
		}

		public Action<ImageProcessingJob> SuccessCallback { get; set; }

		public Action<ImageProcessingJob, string> FailCallback { get; set; }

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

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private readonly IReadOnlySet<string> _inputFilenames;
		private readonly Func<string, string> _outputFilenameFunc;
		private readonly IEnumerable<IImageFilter> _filters;
	}
}
