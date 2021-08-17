using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public abstract class FilterSettings<TModel> : FilterSettingsBase
		where TModel: class, IFilterSettingsModel<TModel>, new()
	{
		public FilterSettings()
		{
			_savedModel = new TModel();
		}

		public override void DisplaySettings()
		{
			DisposeModel(ref _displayedModel);
			_displayedModel = _savedModel.Copy();
			UpdateDisplayedSettings();
		}

		public override void ResetDisplayedSettings()
		{
			DisposeModel(ref _displayedModel);
			_displayedModel = new TModel();
			UpdateDisplayedSettings();
		}

		public override void SaveDisplayedSettings()
		{
			DisposeModel(ref _savedModel);
			_savedModel = _displayedModel;
			_displayedModel = null;
		}

		public override IEnumerable<IImageFilter> CreateFiltersFromSavedSettings()
		{
			return _savedModel.CreateFilters();
		}

		public override IEnumerable<IImageFilter> CreateFiltersFromDisplayedSettings()
		{
			return _displayedModel.CreateFilters();
		}

		protected override void Dispose(bool disposing)
		{
			DisposeModel(ref _displayedModel);
			DisposeModel(ref _savedModel);
			base.Dispose(disposing);
		}

		protected TModel DisplayedModel => _displayedModel;

		protected void UpdateDisplayedSettings()
		{
			DisableUpdateEvents();
			UpdateDisplayedSettingsWithDisabledEvents();
			EnableUpdateEvents();
			OnDisplayedSettingsUpdated();
		}

		protected abstract void UpdateDisplayedSettingsWithDisabledEvents();

		private TModel _savedModel;
		private TModel _displayedModel;

		private static void DisposeModel(ref TModel model)
		{
			IDisposable disposableModel = model as IDisposable;
			if (disposableModel != null)
			{
				disposableModel.Dispose();
			}
			model = null;
		}
	}
}
