using System;
using System.Threading.Tasks;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// An updater for UI components that runs only one update task at a time and has one pending
	/// task that can be overwritten.
	/// </summary>
	/// <remarks>
	/// The caller chooses if the update task shall be synchronous or asynchronous.
	/// </remarks>
	internal class UIUpdater
	{
		/// <summary>
		/// Runs the task if there is no task running, otherwise the task is stored as pending and
		/// will be executed after the running task finishes.
		/// </summary>
		/// <param name="updateTaskFunc">A function that returns an update task.</param>
		public void Update(Func<Task> updateTaskFunc)
		{
			ArgChecker.NotNull(updateTaskFunc, nameof(updateTaskFunc));
			if (UpdateTaskIsRunning())
			{
				_pendingTaskFunc = updateTaskFunc;
			}
			else
			{
				_currentUpdateTask = RunUpdate(updateTaskFunc);
			}
		}

		private Task _currentUpdateTask;
		private Func<Task> _pendingTaskFunc;

		/// <summary>
		/// Checks if an update task is running.
		/// </summary>
		/// <returns>True if an update task is running, otherwise false.</returns>
		private bool UpdateTaskIsRunning()
		{
			return _currentUpdateTask != null && !_currentUpdateTask.IsCompleted;
		}

		/// <summary>
		/// Runs an update task and returns it.
		/// </summary>
		/// <param name="updateTaskFunc">A function that returns an update task.</param>
		/// <returns>The update task that was created and run.</returns>
		private Task RunUpdate(Func<Task> updateTaskFunc)
		{
			Task updateTask = updateTaskFunc.Invoke();
			if (updateTask == null)
			{
				return null;
			}
			// Add a continuation to run in this synchronization context to execute a pending task
			return updateTask.ContinueWith(
					_ =>
					{
						if (_pendingTaskFunc != null)
						{
							Func<Task> nextUpdateTaskFunc = _pendingTaskFunc;
							_pendingTaskFunc = null;
							_currentUpdateTask = RunUpdate(nextUpdateTaskFunc);
						}
				}, TaskScheduler.FromCurrentSynchronizationContext());
		}
	}
}
