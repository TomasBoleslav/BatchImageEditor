using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	internal interface IFilterSettings
	{
		event EventHandler Changed;

		void Reset();

		IEnumerable<IImageFilter> CreateFilters();
		
		int GetMinimumWidth();

		int GetMinimumHeight();
	}
}
