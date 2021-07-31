using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	internal interface IFilterSettings
	{
		void Reset();

		IEnumerable<IImageFilter> CreateFilters();
		
		int GetMinimumWidth();

		int GetMinimumHeight();
	}
}
