using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class ControlUpdater<T>
	{
		public ControlUpdater(Control control)
		{
			ArgChecker.NotNull(control, nameof(control));
			_control = control;
		}

		public void UpdateAsync(Func<T> asyncAcquireFunc, Action<T> syncUpdateAction)
		{
			ArgChecker.NotNull(asyncAcquireFunc, nameof(asyncAcquireFunc));
			ArgChecker.NotNull(syncUpdateAction, nameof(syncUpdateAction));
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
		private Func<T> _pendingAsyncAcquireFunc;
		private Action<T> _pendingSyncUpdateAction;

		private void SetPendingOrUpdateAsync(Func<T> asyncAcquireFunc, Action<T> syncUpdateAction)
		{
			if (_pendingAsyncAcquireFunc != null)
			{
				_pendingAsyncAcquireFunc = asyncAcquireFunc;
				_pendingSyncUpdateAction = syncUpdateAction;
			}
			else
			{
				RunUpdateAsync(asyncAcquireFunc, syncUpdateAction);
			}
		}

		private void RunUpdateAsync(Func<T> asyncAcquireFunc, Action<T> syncUpdateAction)
		{
			Task.Run(() =>
			{
				T acquiredInstance = asyncAcquireFunc();
				_control.BeginInvoke((MethodInvoker)(
					() =>
					{
						syncUpdateAction(acquiredInstance);
						if (_pendingAsyncAcquireFunc != null)
						{
							Func<T> nextAsyncAcquireFunc = _pendingAsyncAcquireFunc;
							Action<T> nextSyncUpdateAction = _pendingSyncUpdateAction;
							_pendingAsyncAcquireFunc = null;
							_pendingSyncUpdateAction = null;
							RunUpdateAsync(nextAsyncAcquireFunc, nextSyncUpdateAction);
						}
					}));
			});
		}
	}
}
