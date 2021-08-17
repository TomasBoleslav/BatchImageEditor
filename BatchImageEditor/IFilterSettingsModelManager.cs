using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	public interface IFilterSettingsModelManager : IDisposable
	{
		//TModel DisplayedModel { get; set; } // how to avoid generics
		void DisplaySettings();
		void ResetDisplayedSettings();
		void SaveSettings();
		IEnumerable<IImageFilter> CreateFiltersFromSavedSettings();
		IEnumerable<IImageFilter> CreateFiltersFromDisplayedSettings();
	}
}
