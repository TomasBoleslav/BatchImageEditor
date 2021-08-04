using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public abstract class FilterSettingsBase : UserControl
	{
		public event EventHandler DisplayedSettingsUpdated;

		public abstract void DisplaySettings();

		public abstract void ResetDisplayedSettings();

		public abstract void SaveDisplayedSettings();

		public abstract IEnumerable<IImageFilter> CreateFiltersFromSavedSettings();

		public abstract IEnumerable<IImageFilter> CreateFiltersFromDisplayedSettings();

		protected virtual void OnDisplaySettingsUpdated()
		{
			DisplayedSettingsUpdated?.Invoke(this, EventArgs.Empty);
		}
	}
}
