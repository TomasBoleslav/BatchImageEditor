using ImageFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageEditor
{
	public class FilterSettingsModelManager<TModel> : IFilterSettingsModelManager
		where TModel : class, IFilterSettingsModel<TModel>, new()
	{
		public FilterSettingsModelManager()
		{

		}

		public void DisplaySettings()
		{
			throw new NotImplementedException();
		}

		public void SaveSettings()
		{
			throw new NotImplementedException();
		}

		public void ResetDisplayedSettings()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IImageFilter> CreateFiltersFromDisplayedSettings()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IImageFilter> CreateFiltersFromSavedSettings()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
