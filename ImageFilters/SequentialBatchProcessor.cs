using System;
using System.Collections.Generic;
using ThrowHelpers;

namespace ImageFilters
{
	public class SequentialBatchProcessor
	{
		Func<bool> ShouldCancelFunc { get; set; }

		Action CancelCallback { get; set; }

		public SequentialBatchProcessor(IEnumerable<ICancellableJob> jobSource, int updateTimeInterval, Action updateAction)
		{
			ArgChecker.NotNull(jobSource, nameof(jobSource));
			ArgChecker.GreaterThan(updateTimeInterval, nameof(updateTimeInterval), 0);
			_jobs = jobSource;
			_updateTimeInterval = updateTimeInterval;
			_updateAction = updateAction;
		}

		public void Run()
		{
			foreach (ICancellableJob job in _jobs)
			{
				job.ShouldCancelFunc = ShouldCancelFunc;
				job.CancelCallback = CancelCallback;
				job.Run();
				if (job.IsCancelled)
				{
					return;
				}
				Update();
			}
		}

		private readonly int _updateTimeInterval;
		private readonly IEnumerable<ICancellableJob> _jobs;
		private DateTime _lastUpdateTime;
		private Action _updateAction;

		private void Update()
		{
			TimeSpan elapsedTime = DateTime.Now - _lastUpdateTime;
			if (elapsedTime.TotalMilliseconds >= _updateTimeInterval)
			{
				_lastUpdateTime = _lastUpdateTime.AddMilliseconds(_updateTimeInterval);
				_updateAction?.Invoke();
			}
		}
	}
}
