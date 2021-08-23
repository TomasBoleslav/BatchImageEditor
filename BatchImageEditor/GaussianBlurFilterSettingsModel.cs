using System.Collections.Generic;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of Gaussian blur filter settings.
	/// </summary>
	internal sealed class GaussianBlurFilterSettingsModel : IFilterSettingsModel<GaussianBlurFilterSettingsModel>
	{
		public const int MinRadius = 1;
		public const int MaxRadius = 5;
		public const int DefaultRadius = MinRadius;
		public const double MinSigma = 1.0;
		public const double MaxSigma = 10.0;
		public const double DefaultSigma = MinSigma;

		/// <summary>
		/// Creates an instance of <see cref="GaussianBlurFilterSettingsModel"/> with default settings.
		/// </summary>
		public GaussianBlurFilterSettingsModel()
		{
			Radius = DefaultRadius;
			Sigma = DefaultSigma;
		}

		/// <summary>
		/// Gets or sets the radius of the Gaussian blur.
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

		/// <summary>
		/// Gets or sets the sigma value of the Gaussian blur.
		/// </summary>
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

		/// <inheritdoc/>
		public GaussianBlurFilterSettingsModel Copy()
		{
			return new GaussianBlurFilterSettingsModel()
			{
				Radius = Radius,
				Sigma = Sigma
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new GaussianBlurFilter(Radius, Sigma);
		}

		private int _radius;
		private double _sigma;
	}
}
