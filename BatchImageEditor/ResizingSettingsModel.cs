using System;
using System.Collections.Generic;
using System.Drawing;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	internal enum ResizingType
	{
		Fixed,
		Percentage
	}

	internal class ResizingSettingsModel : IFilterSettingsModel<ResizingSettingsModel>
	{
		public const float MinPercentage = 0.01f;
		public const float MaxPercentage = 1000.0f;
		public const int MinSideLength = 1;
		public const int MaxSideLength = 5000;

		public ResizingSettingsModel()
		{
			WidthPercentage = DefaultPercentage;
			HeightPercentage = DefaultPercentage;
			FixedWidth = DefaultSideLength;
			FixedHeight = DefaultSideLength;
			ResizingType = DefaultResizingType;
		}

		public float WidthPercentage
		{
			get
			{
				return _widthPercentage;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinPercentage);
				_widthPercentage = value;
			}
		}

		public float HeightPercentage
		{
			get
			{
				return _heightPercentage;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinPercentage);
				_heightPercentage = value;
			}
		}

		public int FixedWidth
		{
			get
			{
				return _fixedWidth;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinSideLength);
				_fixedWidth = value;
			}
		}

		public int FixedHeight
		{
			get
			{
				return _fixedHeight;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value, nameof(value), MinSideLength);
				_fixedHeight = value;
			}
		}

		public ResizingType ResizingType { get; set; }

		public ResizingSettingsModel Copy()
		{
			return new ResizingSettingsModel
			{
				WidthPercentage = WidthPercentage,
				HeightPercentage = HeightPercentage,
				FixedWidth = FixedWidth,
				FixedHeight = FixedHeight
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			IResizingAlgorithm algorithm = null;
			switch (ResizingType)
			{
				case ResizingType.Fixed:
					algorithm = new FixedResizing(FixedWidth, FixedHeight);
					break;
				case ResizingType.Percentage:
					algorithm = new ResizingByFactor(WidthPercentage, HeightPercentage);
					break;
			}
			yield return new ResizingFilter(algorithm, MaxSize);
		}

		private const float DefaultPercentage = 1.0f;
		private const int DefaultSideLength = 100;
		private const ResizingType DefaultResizingType = ResizingType.Percentage;
		private static readonly Size MaxSize = new Size(MaxSideLength, MaxSideLength);
		private float _widthPercentage;
		private float _heightPercentage;
		private int _fixedWidth;
		private int _fixedHeight;
	}
}
