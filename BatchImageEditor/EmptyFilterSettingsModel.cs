using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public class EmptyFilterSettingsModel<TFilter> : IFilterSettingsModel<EmptyFilterSettingsModel<TFilter>>
		where TFilter : IImageFilter, new()
	{
		public EmptyFilterSettingsModel<TFilter> Copy()
		{
			return new EmptyFilterSettingsModel<TFilter>();
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new TFilter();
		}
	}
}
