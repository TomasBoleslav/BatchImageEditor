using ImageFilters;
using System;
using System.Collections.Generic;
using System.Drawing;
using ThrowHelpers;

namespace BatchImageEditor
{
	public enum CropType
	{
		Pixels,
		Percents
	}

	public class CropFilterSettingsModel : IFilterSettingsModel<CropFilterSettingsModel>
	{
		public const int MinPixelLocation = 0;
		public const int MaxPixelLocation = 10_000;
		public const int MinPixelSideLength = 1;
		public const int MaxPixelSideLength = 10_000;
		public const float MinPercentageLocation = 0.0f;
		public const float MaxPercentageLocation = 100.0f;
		public const float MinPercentageSideLength = 0.01f;
		public const float MaxPercentageSideLength = 100.0f;
		public const CropType DefaultImageUnits = CropType.Percents;
		public static readonly Rectangle DefaultPixelsRectangle = new Rectangle(0, 0, 1000, 1000);
		public static readonly RectangleF DefaultPercentsRectangle = new RectangleF(0f, 0f, 100f, 100f);


		public CropFilterSettingsModel()
		{
			CropType = DefaultImageUnits;
			PixelsRectangle = DefaultPixelsRectangle;
			PercentsRectangle = DefaultPercentsRectangle;
		}

		public Rectangle PixelsRectangle
		{
			get
			{
				return _pixelsRectangle;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value.X, nameof(value.X), MinPixelLocation);
				ArgChecker.GreaterThanOrEqualTo(value.Y, nameof(value.Y), MinPixelLocation);
				ArgChecker.InRangeInclusive(value.Width, nameof(value.Width), MinPixelSideLength, MaxPixelSideLength);
				ArgChecker.InRangeInclusive(value.Height, nameof(value.Height), MinPixelSideLength, MaxPixelSideLength);
				_pixelsRectangle = value;
			}
		}

		public RectangleF PercentsRectangle
		{
			get
			{
				return _percentsRectangle;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value.X, nameof(value.X), MinPercentageLocation);
				ArgChecker.GreaterThanOrEqualTo(value.Y, nameof(value.Y), MinPercentageLocation);
				ArgChecker.InRangeInclusive(value.Width, nameof(value.Width), MinPercentageSideLength, MaxPercentageSideLength);
				ArgChecker.InRangeInclusive(value.Height, nameof(value.Height), MinPercentageSideLength, MaxPercentageSideLength);
				_percentsRectangle = value;
			}
		}

		public CropType CropType { get; set; }

		public CropFilterSettingsModel Copy()
		{
			return new CropFilterSettingsModel
			{
				CropType = CropType,
				PixelsRectangle = PixelsRectangle,
				PercentsRectangle = PercentsRectangle
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			throw new NotImplementedException();
		}

		private Rectangle _pixelsRectangle;
		private RectangleF _percentsRectangle;
	}
}
