using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public interface IFilterSettingsModel<TModel>
	{
		TModel Copy();

		IEnumerable<IImageFilter> CreateFilters();
	}
}
