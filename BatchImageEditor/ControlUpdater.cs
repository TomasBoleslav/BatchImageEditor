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
		private Func<TComputedValue> _pendingAsyncAcquireFunc;
		private Action<TComputedValue> _pendingSyncUpdateAction;

		private void SetPendingOrUpdateAsync(Func<TComputedValue> asyncAcquireFunc, Action<TComputedValue> syncUpdateAction)
		{
			// These delegates are always null!!!
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

		private void RunUpdateAsync(Func<TComputedValue> asyncAcquireFunc, Action<TComputedValue> syncUpdateAction)
		{
			Task.Run(() =>
			{
				TComputedValue acquiredInstance = asyncAcquireFunc();
				_control.BeginInvoke((MethodInvoker)(
					() =>
					{
						syncUpdateAction(acquiredInstance);
						if (_pendingAsyncAcquireFunc != null)
						{
							Func<TComputedValue> nextAsyncAcquireFunc = _pendingAsyncAcquireFunc;
							Action<TComputedValue> nextSyncUpdateAction = _pendingSyncUpdateAction;
							_pendingAsyncAcquireFunc = null;
							_pendingSyncUpdateAction = null;
							RunUpdateAsync(nextAsyncAcquireFunc, nextSyncUpdateAction);
						}
					}));
			});
		}
	}
}
