using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	internal interface IFilterSettings
	{
		event EventHandler Changed; // Settings changed -> call CreateFilters and create and show new preview

		void Show();

		void Hide();

		void ResetViewed();

		void Save();

		IEnumerable<IImageFilter> CreateFilters();
	}
}
