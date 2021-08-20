using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ThrowHelpers;

namespace ImageFilters
{
	public class BatchProcessor : IDisposable
	{
		public BatchProcessor(IEnumerable<ICancellableJob> jobSource, int maxThreadCount)
		{
			ArgChecker.NotNull(jobSource, nameof(jobSource));
			ArgChecker.GreaterThan(maxThreadCount, nameof(maxThreadCount), 0);
			_jobs = jobSource;
			_maxThreadCount = maxThreadCount;
			_tokenSource = new CancellationTokenSource();
		}

		public bool IsRunning
		{
			get
			{
				return (_runningTask != null && !_runningTask.IsCompleted) || _isRunningSequentially;
			}
		}

		public void Run()
		{
			if (IsRunning)
			{
				throw new InvalidOperationException("Process is already running.");
			}
			if (_maxThreadCount > 1)
			{
				_runningTask = RunJobsAsync();
			}
			else
			{
				_isRunningSequentially = true;
				try
				{
					RunJobsInCurrentThread(_maxThreadCount);
				}
				catch (OperationCanceledException)
				{
				}
				_isRunningSequentially = false;
			}
		}

		public void Cancel()
		{
			if (!IsRunning)
			{
				return;
			}
			_tokenSource.Cancel();
		}

		public void WaitForCompletion()
		{
			if (!IsRunning || _runningTask == null)
			{
				return;
			}
			_runningTask.Wait();	// TODO: throws aggregate exception, catch it from outside
		}

		private readonly IEnumerable<ICancellableJob> _jobs;
		private readonly int _maxThreadCount;
		private readonly CancellationTokenSource _tokenSource;
		private Task _runningTask;
		private bool _isRunningSequentially;

		private Task RunJobsAsync()
		{
			return Task.Factory.StartNew(
				() =>
				{
					RunJobsInCurrentThread(_maxThreadCount - 1);
				},
				_tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default); 
		}

		private void RunJobsInCurrentThread(int maxThreadCount)
		{
			var options = new ParallelOptions
			{
				TaskScheduler = TaskScheduler.Default,
				MaxDegreeOfParallelism = maxThreadCount,
				CancellationToken = _tokenSource.Token
			};
			Parallel.ForEach(_jobs, options,
				job =>
				{
					job.ShouldCancelFunc = () => options.CancellationToken.IsCancellationRequested;
					job.CancelAction = () => _tokenSource.Cancel();
					job.Run();
				});
		}

		public void Dispose()
		{
			_tokenSource.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
