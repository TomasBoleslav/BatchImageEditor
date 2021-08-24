using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of flip filter settings.
	/// </summary>
	public sealed class FlipFilterSettingsModel : IFilterSettingsModel<FlipFilterSettingsModel>
	{
		public const FlipType DefaultFlipType = FlipType.Horizontal;

		/// <summary>
		/// Creates an instance of <see cref="FlipFilterSettingsModel"/> with default settings.
		/// </summary>
		public FlipFilterSettingsModel()
		{
			FlipType = DefaultFlipType;
		}

		/// <summary>
		/// Gets or sets the flip type.
		/// </summary>
		public FlipType FlipType { get; set; }

		/// <inheritdoc/>
		public FlipFilterSettingsModel Copy()
		{
			return new FlipFilterSettingsModel
			{
				FlipType = FlipType
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new FlipFilter(FlipType);
		}
	}
}
