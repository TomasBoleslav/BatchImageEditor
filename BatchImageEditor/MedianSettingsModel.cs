using System.Collections.Generic;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of median filter settings.
	/// </summary>
	internal sealed class MedianSettingsModel : IFilterSettingsModel<MedianSettingsModel>
	{
		public const int MinRadius = 1;
		public const int MaxRadius = 5;

		/// <summary>
		/// Creates an instance of <see cref="MedianSettingsModel"/> with default settings.
		/// </summary>
		public MedianSettingsModel()
		{
			Radius = DefaultRadius;
		}

		/// <summary>
		/// Gets or sets the radius.
		/// </summary>
		public int Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinRadius, MaxRadius);
				_radius = value;
			}
		}

		/// <inheritdoc/>
		public MedianSettingsModel Copy()
		{
			return new MedianSettingsModel
			{
				Radius = Radius
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			var filter = new MedianFilter(Radius);
			yield return filter;
		}

		private const int DefaultRadius = 1;
		private int _radius;
	}
}
