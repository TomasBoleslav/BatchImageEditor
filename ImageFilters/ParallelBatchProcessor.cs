using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ThrowHelpers;

namespace ImageFilters
{
	public class ParallelBatchProcessor
	{
		public ParallelBatchProcessor(IEnumerable<ICancellableJob> jobSource, int numConcurrentJobs)
		{
			ArgChecker.NotNull(jobSource, nameof(jobSource));
			ArgChecker.GreaterThan(numConcurrentJobs, nameof(numConcurrentJobs), 1);
			_jobs = jobSource;
			_numConcurrentJobs = numConcurrentJobs;
			_tokenSource = new CancellationTokenSource();
		}

		public void RunAsync()
		{
			if (_runningTask != null)
			{
				throw new InvalidOperationException("Process has already been run.");
			}
			_runningTask = RunJobsAsync();
		}

		public void Cancel()
		{
			if (_runningTask == null)
			{
				throw new InvalidOperationException("Only a running process can be cancelled.");
			}
			_tokenSource.Cancel();
		}

		public void WaitForCompletion()
		{
			if (_runningTask == null)
			{
				throw new InvalidOperationException("Wait can be called only when the process is running.");
			}
			_runningTask.Wait();
		}

		private readonly IEnumerable<ICancellableJob> _jobs;
		private readonly int _numConcurrentJobs;
		private readonly CancellationTokenSource _tokenSource;
		private Task _runningTask;

		private Task RunJobsAsync()
		{
			CancellationToken cancellationToken = _tokenSource.Token;
			return Task.Factory.StartNew(
				() =>
				{
					var options = new ParallelOptions
					{
						TaskScheduler = TaskScheduler.Default,
						MaxDegreeOfParallelism = _numConcurrentJobs
					};
					Parallel.ForEach(_jobs, options,
						job =>
						{
							cancellationToken.ThrowIfCancellationRequested();
							job.ShouldCancelFunc = () => cancellationToken.IsCancellationRequested;
							job.CancelCallback = () => throw new OperationCanceledException();
							job.Run();
						});
				}, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default); 
		}
	}
}
