using System;
using System.Threading.Tasks;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class UIUpdater
	{
		public void Update(Func<Task> updateTaskFunc)
		{
			ArgChecker.NotNull(updateTaskFunc, nameof(updateTaskFunc));
			if (UpdateTaskIsRunning())
			{
				_pendingTaskFunc = updateTaskFunc;
			}
			else
			{
				_currentUpdateTask = RunUpdateAsync(updateTaskFunc);
			}
		}

		private Task _currentUpdateTask;
		private Func<Task> _pendingTaskFunc;

		private bool UpdateTaskIsRunning()
		{
			return _currentUpdateTask != null && !_currentUpdateTask.IsCompleted;
		}

		private Task RunUpdateAsync(Func<Task> updateTaskFunc)
		{
			Task updateTask = updateTaskFunc.Invoke();
			if (updateTask == null)
			{
				return null;
			}
			return updateTask.ContinueWith(
					_ =>
					{
						if (_pendingTaskFunc != null)
						{
							Func<Task> nextUpdateTaskFunc = _pendingTaskFunc;
							_pendingTaskFunc = null;
							_currentUpdateTask = RunUpdateAsync(nextUpdateTaskFunc);
						}
				}, TaskScheduler.FromCurrentSynchronizationContext());
		}
	}
}
