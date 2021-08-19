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
			_lastUpdateTime = DateTime.Now;
			foreach (ICancellableJob job in _jobs)
			{
				job.ShouldCancelFunc = ShouldCancelFunc;
				job.CancelAction = CancelCallback;
				job.Run();
				if (job.IsCancelled)
				{
					return;
				}
				// TODO: update action can be called in success and fail - both measure time and decide whether to call update (DoEvents) or not
				UpdateIfTimeoutExceeded();
			}
		}

		private readonly int _updateTimeInterval;
		private readonly IEnumerable<ICancellableJob> _jobs;
		private DateTime _lastUpdateTime;
		private Action _updateAction;

		private void UpdateIfTimeoutExceeded()
		{
			TimeSpan elapsedTime = DateTime.Now - _lastUpdateTime;
			if (elapsedTime.TotalMilliseconds >= _updateTimeInterval)
			{
				Update();
			}
		}

		private void Update()
		{
			_lastUpdateTime = _lastUpdateTime.AddMilliseconds(_updateTimeInterval);
			_updateAction?.Invoke();
		}
	}
}
