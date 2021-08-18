using System.Collections.Generic;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class GaussianBlurFilterSettingsModel : IFilterSettingsModel<GaussianBlurFilterSettingsModel>
	{
		public const int MinRadius = 1;
		public const int MaxRadius = 5;
		public const int DefaultRadius = MinRadius;
		public const double MinSigma = 1.0;
		public const double MaxSigma = 10.0;
		public const double DefaultSigma = MinSigma;

		public GaussianBlurFilterSettingsModel()
		{
			Radius = DefaultRadius;
			Sigma = DefaultSigma;
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

		public double Sigma
		{
			get
			{
				return _sigma;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinSigma, MaxSigma);
				_sigma = value;
			}
		}

		public GaussianBlurFilterSettingsModel Copy()
		{
			return new GaussianBlurFilterSettingsModel()
			{
				Radius = Radius,
				Sigma = Sigma
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new GaussianBlurFilter(Radius, Sigma);
		}

		private int _radius;
		private double _sigma;
	}
}
