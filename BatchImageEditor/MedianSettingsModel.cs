﻿using System.Collections.Generic;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class MedianSettingsModel : IFilterSettingsModel<MedianSettingsModel>
	{
		public const int MinRadius = 1;
		public const int MaxRadius = 5;

		public MedianSettingsModel()
		{
			Radius = DefaultRadius;
		}

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

		public MedianSettingsModel Copy()
		{
			return new MedianSettingsModel
			{
				Radius = Radius
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			var filter = new MedianFilter(Radius);
			yield return filter;
		}

		private const int DefaultRadius = 1;
		private int _radius;
	}
}