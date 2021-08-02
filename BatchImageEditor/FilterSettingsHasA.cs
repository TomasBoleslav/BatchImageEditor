using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageEditor
{
	/*
	internal abstract class FilterSettingsHasA<TModel, TView> : IFilterSettings
		where TModel: IFilterSettingsModel<TModel>, new() //: IDisposable, new()
		where TView: FilterSettingsView<TModel>//IFilterSettings, IDisposable	// TODO: make IFilterSettings disposable, not this
	{
		public event EventHandler Changed;

		public FilterSettingsHasA(MedianFilterSettings settingsUserControl)
		{
			// TODO: throw if null
			_view = settingsUserControl;
			_view.Changed += // TODO: maybe only pass Model to view, view will make changes automatically
		}

		// TODO: This and other functions will be same for all filter settings, how to make it common for all?
		// this will not be same, it can dispose older settings
		public void Show()
		{
			// IView - SetModel(), Show(), Hide()
			// IModel - Reset(), Copy()

			if (_savedModel == null)
			{
				// cannot be done by base class (only if generic and T: new())
				_viewedModel = new TModel();
			}
			else
			{
				_viewedModel = _savedModel.Copy();
			}
			// Cannot be done in base class - it does not have particular type, only interface
			_view.SetModel(_viewedModel); // UserControl will take model and set its values
			_view.Show();
		}

		public void Hide()
		{
			// can be done in base class, but there must be access to _control and _view as interfaces, not particular classes

			// _viewedModel?.Dispose();
			_view.Hide();
		}

		public void Save()
		{
			// _savedModel?.Dispose();
			_savedModel = _viewedModel;
		}

		public void Reset()
		{
			_viewedModel.Reset();
			_view.SetModel(_viewedModel);
		}

		public void Dispose()
		{
			_savedModel?.Dispose();
			_viewedModel?.Dispose();
		}

		protected TView _view;
		protected TModel _savedModel;
		protected TModel _viewedModel;

		private class MedianFilterSettingsModel
		{
			public const int MinRadius = 1;
			public const int MaxRadius = 20;

			public int Radius { get; set; }

			public MedianFilterSettingsModel()
			{
				Reset();
			}

			public void Reset()
			{
				Radius = DefaultRadius;
			}

			private const int DefaultRadius = 1;
		}
	}*/
}
