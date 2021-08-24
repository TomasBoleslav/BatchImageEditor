using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Model for a <see cref="FilterSettings{TModel}"/> control.
	/// </summary>
	/// <typeparam name="TModel">The type of the model.</typeparam>
	public interface IFilterSettingsModel<TModel>
	{
		/// <summary>
		/// Creates a copy of the model.
		/// </summary>
		/// <returns>A copy of the model.</returns>
		TModel Copy();

		/// <summary>
		/// Creates a collection of filters made from data stored in the model.
		/// </summary>
		/// <returns>A collection of filters made from data stored in the model.</returns>
		IEnumerable<IImageFilter> CreateFilters();
	}
}
