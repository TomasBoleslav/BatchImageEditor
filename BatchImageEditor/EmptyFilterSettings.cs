using ImageFilters;

namespace BatchImageEditor
{
	public sealed class EmptyFilterSettings<TFilter> : FilterSettings<EmptyFilterSettingsModel<TFilter>>
		where TFilter: IImageFilter, new()
	{
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
		}
	}
}
