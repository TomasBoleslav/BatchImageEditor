using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class UIUpdater<TAcquiredInstance>
	{
		public UIUpdater(Control control)
		{
			ArgChecker.NotNull(control, nameof(control));
			_control = control;
		}

		// TODO: better name: AppendAsyncUpdate or similar
		public void UpdateAsync(Func<TAcquiredInstance> asyncAcquireFunc, Action<TAcquiredInstance> syncUpdateAction)
		{
			ArgChecker.NotNull(asyncAcquireFunc, nameof(asyncAcquireFunc));
			ArgChecker.NotNull(syncUpdateAction, nameof(syncUpdateAction));
			/*_control.HandleCreated
			if (!_control.IsHandleCreated)
			{
				// TODO: problem, update is ignored in this case and 
				return;
			}*/
			// Execute all synchronous actions in UI thread of the control to prevent data races
			if (_control.InvokeRequired)
			{
				_control.BeginInvoke((MethodInvoker)(
					() => SetPendingOrUpdateAsync(asyncAcquireFunc, syncUpdateAction)
					));
			}
			else
			{
				SetPendingOrUpdateAsync(asyncAcquireFunc, syncUpdateAction);
			}
		}

		private readonly Control _control;
		private Task _currentUpdateTask;
		private Func<TAcquiredInstance> _pendingAsyncAcquireFunc;
		private Action<TAcquiredInstance> _pendingSyncUpdateAction;

		private void SetPendingOrUpdateAsync(Func<TAcquiredInstance> asyncAcquireFunc, Action<TAcquiredInstance> syncUpdateAction)
		{
			if (UpdateTaskIsRunning())
			{
				_pendingAsyncAcquireFunc = asyncAcquireFunc;
				_pendingSyncUpdateAction = syncUpdateAction;
			}
			else
			{
				_currentUpdateTask = RunUpdateAsync(asyncAcquireFunc, syncUpdateAction);
			}
		}

		private bool UpdateTaskIsRunning()
		{
			return _currentUpdateTask != null && !_currentUpdateTask.IsCompleted;
		}

		private bool ShouldExecutePendingTasks()
		{
			return _pendingAsyncAcquireFunc != null;
		}

		private Task RunUpdateAsync(Func<TAcquiredInstance> asyncAcquireFunc, Action<TAcquiredInstance> syncUpdateAction)
		{
			return Task.Run(
				() =>
				{
					return asyncAcquireFunc.Invoke();
				}
				).ContinueWith(
				task =>
				{
					TAcquiredInstance acquiredInstance = task.Result;
					syncUpdateAction.Invoke(task.Result);
					if (ShouldExecutePendingTasks())
					{
						Func<TAcquiredInstance> nextAsyncAcquireFunc = _pendingAsyncAcquireFunc;
						Action<TAcquiredInstance> nextSyncUpdateAction = _pendingSyncUpdateAction;
						_pendingAsyncAcquireFunc = null;
						_pendingSyncUpdateAction = null;
						_currentUpdateTask = RunUpdateAsync(nextAsyncAcquireFunc, nextSyncUpdateAction);
					}
				}, TaskScheduler.FromCurrentSynchronizationContext());	// TODO: maybe this will have the same fault - context will disappear when form is closed
		}
	}
}
