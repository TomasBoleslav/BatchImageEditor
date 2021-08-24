using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// A processor that runs a batch of jobs sequentially or in parallel.
	/// </summary>
	public sealed class BatchProcessor : IDisposable
	{
		/// <summary>
		/// Creates an instance of <see cref="BatchProcessor"/> with a batch of jobs and maximum number of threads.
		/// </summary>
		/// <param name="jobBatch">A batch of jobs to run.</param>
		/// <param name="maxThreadCount">The maximum number of threads to use.</param>
		public BatchProcessor(IEnumerable<ICancelableJob> jobBatch, int maxThreadCount)
		{
			ArgChecker.NotNull(jobBatch, nameof(jobBatch));
			ArgChecker.GreaterThan(maxThreadCount, nameof(maxThreadCount), 0);
			_jobs = jobBatch;
			_maxThreadCount = maxThreadCount;
			_tokenSource = new CancellationTokenSource();
		}

		/// <summary>
		/// Gets an indicator whether the process is still running.
		/// </summary>
		public bool IsRunning
		{
			get
			{
				return (_runningTask != null && !_runningTask.IsCompleted) || _isRunningSequentially;
			}
		}

		/// <summary>
		/// Runs the process.
		/// </summary>
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

		/// <summary>
		/// Cancels the process.
		/// </summary>
		public void Cancel()
		{
			if (!IsRunning)
			{
				return;
			}
			_tokenSource.Cancel();
		}

		/// <summary>
		/// Frees resources.
		/// </summary>
		public void Dispose()
		{
			_tokenSource.Dispose();
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Waits for completion.
		/// </summary>
		/// <exception cref="AggregateException">Thrown when run in parallel and an exception was thrown in one of the threads.</exception>
		/// <exception cref="OperationCanceledException">Thrown when run sequentially and the process was canceled.</exception>
		public void WaitForCompletion()
		{
			if (!IsRunning || _runningTask == null)
			{
				return;
			}
			_runningTask.Wait();
		}

		private readonly IEnumerable<ICancelableJob> _jobs;
		private readonly int _maxThreadCount;
		private readonly CancellationTokenSource _tokenSource;
		private Task _runningTask;
		private bool _isRunningSequentially;

		/// <summary>
		/// Runs jobs asynchronously.
		/// </summary>
		/// <returns>The task that was run.</returns>
		private Task RunJobsAsync()
		{
			return Task.Factory.StartNew(
				() =>
				{
					RunJobsInCurrentThread(_maxThreadCount - 1);
				},
				_tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default); 
		}

		/// <summary>
		/// Runs jobs in the current thread.
		/// </summary>
		/// <param name="maxThreadCount">The maximum number of threads to use.</param>
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
	}
}
