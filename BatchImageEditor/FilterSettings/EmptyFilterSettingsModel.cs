using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model for empty filter settings.
	/// </summary>
	/// <typeparam name="TFilter">The type of filter to generate.</typeparam>
	internal sealed class EmptyFilterSettingsModel<TFilter> : IFilterSettingsModel<EmptyFilterSettingsModel<TFilter>>
		where TFilter : IImageFilter, new()
	{
		/// <inheritdoc/>
		public EmptyFilterSettingsModel<TFilter> Copy()
		{
			return new EmptyFilterSettingsModel<TFilter>();
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new TFilter();
		}
	}
}
