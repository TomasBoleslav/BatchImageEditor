using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	public class AsyncImageFilter : IDisposable
	{
		public bool IsRunning
		{
			get
			{
				return _currentTask != null && !_currentTask.IsCompleted;
			}
		}

		public Task<DirectBitmap> ApplyAsync(DirectBitmap image, IEnumerable<IImageFilter> filters)
		{
			if (IsRunning)
			{
				Cancel();
			}
			_cancellationTokenSource = new CancellationTokenSource();
			CancellationToken cancellationToken = _cancellationTokenSource.Token;
			_currentTask = Task.Run(() =>
				{
					DirectBitmap imageCopy = image.Copy();
					foreach (var filter in filters)
					{
						if (cancellationToken.IsCancellationRequested)
						{
							imageCopy.Dispose();
							throw new TaskCanceledException();
						}
						filter.Apply(ref imageCopy);
					}
					return imageCopy;
				},
				cancellationToken);
			return _currentTask;
		}

		public void Cancel()
		{
			_cancellationTokenSource?.Cancel();
			_cancellationTokenSource?.Dispose(); // TODO: what if this disposes of the token? Maybe reading cancellationToken.IsCancellationRequested will be a problem
			_cancellationTokenSource = null;
		}

		public void Dispose()
		{
			Cancel();
			GC.SuppressFinalize(this);
		}

		private Task<DirectBitmap> _currentTask;
		private CancellationTokenSource _cancellationTokenSource;
	}
}
