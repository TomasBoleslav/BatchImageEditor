using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public interface IFilterSettingsModel<TModel>
	{
		void Reset();

		TModel Copy();

		IEnumerable<IImageFilter> CreateFilters();
	}
}
