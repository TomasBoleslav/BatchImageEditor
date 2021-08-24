using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// An abstract base class for filter settings controls that contain data for creating <see cref="IImageFilter"/> instances.
	/// </summary>
	/// <typeparam name="TModel">The type of a model.</typeparam>
	public abstract class FilterSettingsBase : UserControl
	{
		/// <summary>
		/// Occurs when displayed settings were updated by the user.
		/// </summary>
		public event EventHandler DisplayedSettingsUpdated;

		/// <summary>
		/// Displays settings with the data from the saved settings.
		/// </summary>
		public abstract void DisplaySettings();

		/// <summary>
		/// Resets the displayed settings.
		/// </summary>
		public abstract void ResetDisplayedSettings();

		/// <summary>
		/// Saves the displayed settings.
		/// </summary>
		public abstract void SaveDisplayedSettings();

		/// <summary>
		/// Creates filters from the saved settings.
		/// </summary>
		/// <returns>Filters created from the saved settings.</returns>
		public abstract IEnumerable<IImageFilter> CreateFiltersFromSavedSettings();

		/// <summary>
		/// Creates filters from the displayed settings.
		/// </summary>
		/// <returns>Filters created from the displayed settings.</returns>
		public abstract IEnumerable<IImageFilter> CreateFiltersFromDisplayedSettings();

		/// <summary>
		/// Invokes the <see cref="DisplayedSettingsUpdated"/> event if enabled.
		/// </summary>
		protected virtual void OnDisplayedSettingsUpdated()
		{
			if (_updateEventsEnabled)
			{
				DisplayedSettingsUpdated?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Enables the <see cref="DisplayedSettingsUpdated"/> event.
		/// </summary>
		protected void EnableUpdateEvents()
		{
			_updateEventsEnabled = true;
		}

		/// <summary>
		/// Disables the <see cref="DisplayedSettingsUpdated"/> event.
		/// </summary>
		protected void DisableUpdateEvents()
		{
			_updateEventsEnabled = false;
		}

		private bool _updateEventsEnabled = false;
	}
}
