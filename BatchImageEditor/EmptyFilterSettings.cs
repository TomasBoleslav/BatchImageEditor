using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// An empty filter settings control for generating filters without parameters.
	/// </summary>
	/// <typeparam name="TFilter">The type of filter to generate.</typeparam>
	internal sealed class EmptyFilterSettings<TFilter> : FilterSettings<EmptyFilterSettingsModel<TFilter>>
		where TFilter: IImageFilter, new()
	{
		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
		}
	}
}
