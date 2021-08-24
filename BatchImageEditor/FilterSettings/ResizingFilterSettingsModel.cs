using System.Collections.Generic;
using System.Drawing;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of resizing filter settings.
	/// </summary>
	internal sealed class ResizingFilterSettingsModel : IFilterSettingsModel<ResizingFilterSettingsModel>
	{
		public const float MinPercentage = 1.0f;
		public const float MaxPercentage = 1000.0f;
		public const int MinSideLength = 1;
		public const int MaxSideLength = 5000;

		/// <summary>
		/// Creates an instance of <see cref="ResizingFilterSettingsModel"/> with default settings.
		/// </summary>
		public ResizingFilterSettingsModel()
		{
			WidthInPercents = DefaultPercentage;
			HeightInPercents = DefaultPercentage;
			WidthInPixels = DefaultSideLength;
			HeightPixels = DefaultSideLength;
			ResizingType = DefaultResizingType;
		}

		/// <summary>
		/// Gets or sets width percents used to compute new width.
		/// </summary>
		public float WidthInPercents
		{
			get
			{
				return _widthPercents;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinPercentage);
				_widthPercents = value;
			}
		}

		/// <summary>
		/// Gets or sets height percents used to compute new height.
		/// </summary>
		public float HeightInPercents
		{
			get
			{
				return _heightPercents;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinPercentage);
				_heightPercents = value;
			}
		}

		/// <summary>
		/// Gets or sets width in pixels used to compute new width.
		/// </summary>
		public int WidthInPixels
		{
			get
			{
				return _widthPixels;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinSideLength);
				_widthPixels = value;
			}
		}

		/// <summary>
		/// Gets or sets height in pixels used to compute new height.
		/// </summary>
		public int HeightPixels
		{
			get
			{
				return _heightPixels;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinSideLength);
				_heightPixels = value;
			}
		}

		/// <summary>
		/// Gets or sets the type of resizing.
		/// </summary>
		public ResizingType ResizingType { get; set; }

		/// <inheritdoc/>
		public ResizingFilterSettingsModel Copy()
		{
			return new ResizingFilterSettingsModel
			{
				WidthInPercents = WidthInPercents,
				HeightInPercents = HeightInPercents,
				WidthInPixels = WidthInPixels,
				HeightPixels = HeightPixels
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			IResizingAlgorithm algorithm = null;
			switch (ResizingType)
			{
				case ResizingType.Pixels:
					algorithm = new FixedResizing(WidthInPixels, HeightPixels);
					break;
				case ResizingType.Percents:
					algorithm = new ResizingByFactor(WidthInPercents / 100.0f, HeightInPercents / 100.0f);
					break;
			}
			yield return new ResizingFilter(algorithm, MaxSize);
		}

		private const float DefaultPercentage = 100.0f;
		private const int DefaultSideLength = 100;
		private const ResizingType DefaultResizingType = ResizingType.Percents;
		private static readonly Size MaxSize = new Size(MaxSideLength, MaxSideLength);
		private float _widthPercents;
		private float _heightPercents;
		private int _widthPixels;
		private int _heightPixels;
	}
}
