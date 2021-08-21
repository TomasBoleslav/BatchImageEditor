using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// An abstract base class for filter settings controls that implements common functions manipulating the model.
	/// </summary>
	/// <typeparam name="TModel">The type of a model.</typeparam>
	internal abstract class FilterSettings<TModel> : FilterSettingsBase
		where TModel: class, IFilterSettingsModel<TModel>, new()
	{
		/// <summary>
		/// Creates filter settings with saved and displayed model.
		/// </summary>
		public FilterSettings()
		{
			_savedModel = new TModel();
			_displayedModel = new TModel();
		}

		/// <inheritdoc/>
		public override void DisplaySettings()
		{
			DisposeModel(ref _displayedModel);
			_displayedModel = _savedModel.Copy();
			UpdateDisplayedSettings();
		}

		/// <inheritdoc/>
		public override void ResetDisplayedSettings()
		{
			DisposeModel(ref _displayedModel);
			_displayedModel = new TModel();
			UpdateDisplayedSettings();
		}

		/// <inheritdoc/>
		public override void SaveDisplayedSettings()
		{
			DisposeModel(ref _savedModel);
			_savedModel = _displayedModel;
			_displayedModel = null;
		}

		/// <inheritdoc/>
		public override IEnumerable<IImageFilter> CreateFiltersFromSavedSettings()
		{
			return _savedModel.CreateFilters();
		}

		/// <inheritdoc/>
		public override IEnumerable<IImageFilter> CreateFiltersFromDisplayedSettings()
		{
			return _displayedModel.CreateFilters();
		}

		/// <summary>
		/// Releases resources.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			DisposeModel(ref _displayedModel);
			DisposeModel(ref _savedModel);
			base.Dispose(disposing);
		}

		protected TModel DisplayedModel => _displayedModel;

		/// <summary>
		/// Updates displayed settings according to the <see cref="DisplayedModel"/>.
		/// </summary>
		protected void UpdateDisplayedSettings()
		{
			DisableUpdateEvents();
			UpdateDisplayedSettingsWithDisabledEvents();
			EnableUpdateEvents();
			OnDisplayedSettingsUpdated();
		}

		/// <summary>
		/// Updates displayed settings according to the <see cref="DisplayedModel"/>.
		/// Is called only after update events were disabled.
		/// </summary>
		protected abstract void UpdateDisplayedSettingsWithDisabledEvents();

		private TModel _savedModel;
		private TModel _displayedModel;

		/// <summary>
		/// Disposes a model if it implements the <see cref="IDisposable"/> interface.
		/// </summary>
		/// <param name="model">A model to dispose.</param>
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
