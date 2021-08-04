using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class ControlUpdater<TComputedValue>
	{
		public ControlUpdater(Control control)
		{
			ArgChecker.NotNull(control, nameof(control));
			_control = control;
		}

		// TODO: better name: AppendAsyncUpdate or similar
		public void UpdateAsync(Func<TComputedValue> asyncAcquireFunc, Action<TComputedValue> syncUpdateAction)
		{
			ArgChecker.NotNull(asyncAcquireFunc, nameof(asyncAcquireFunc));
			ArgChecker.NotNull(syncUpdateAction, nameof(syncUpdateAction));
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
		private Func<TComputedValue> _pendingAsyncAcquireFunc;
		private Action<TComputedValue> _pendingSyncUpdateAction;

		private void SetPendingOrUpdateAsync(Func<TComputedValue> asyncAcquireFunc, Action<TComputedValue> syncUpdateAction)
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

		private Task RunUpdateAsync(Func<TComputedValue> asyncAcquireFunc, Action<TComputedValue> syncUpdateAction)
		{
			return Task.Run(() =>
			{
				TComputedValue acquiredInstance = asyncAcquireFunc();
				_control.BeginInvoke((MethodInvoker)(
					() =>
					{
						syncUpdateAction(acquiredInstance);
						if (ShouldExecutePendingTasks())
						{
							Func<TComputedValue> nextAsyncAcquireFunc = _pendingAsyncAcquireFunc;
							Action<TComputedValue> nextSyncUpdateAction = _pendingSyncUpdateAction;
							_pendingAsyncAcquireFunc = null;
							_pendingSyncUpdateAction = null;
							_currentUpdateTask = RunUpdateAsync(nextAsyncAcquireFunc, nextSyncUpdateAction);
						}
					}));
			});
		}
	}
}
