using ImageFilters;
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
		public const int MinPixelSize = 1;
		public const int MaxPixelSize = 10_000;
		public const float MaxPercentage = 100.0f;
		public const float MinPercentageLocation = 0.0f;
		public const float MaxPercentageLocation = MaxPercentage;
		public const float MinPercentageSize = 0.01f;
		public const float MaxPercentageSize = MaxPercentage;
		public const CropType DefaultImageUnits = CropType.Percents;
		public static readonly Rectangle DefaultPixelsRectangle = new Rectangle(0, 0, 1000, 1000);
		public static readonly RectangleF DefaultPercentsRectangle = new RectangleF(0f, 0f, 100f, 100f);


		public CropFilterSettingsModel()
		{
			CropType = DefaultImageUnits;
			PixelsCropRect = DefaultPixelsRectangle;
			PercentsCropRect = DefaultPercentsRectangle;
		}

		public Rectangle PixelsCropRect
		{
			get
			{
				return _pixelsCropRect;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value.X, nameof(value.X), MinPixelLocation);
				ArgChecker.GreaterThanOrEqualTo(value.Y, nameof(value.Y), MinPixelLocation);
				ArgChecker.InRangeInclusive(value.Width, nameof(value.Width), MinPixelSize, MaxPixelSize);
				ArgChecker.InRangeInclusive(value.Height, nameof(value.Height), MinPixelSize, MaxPixelSize);
				_pixelsCropRect = value;
			}
		}

		public RectangleF PercentsCropRect
		{
			get
			{
				return _percentsCropRect;
			}
			set
			{
				ArgChecker.GreaterThanOrEqualTo(value.X, nameof(value.X), MinPercentageLocation);
				ArgChecker.GreaterThanOrEqualTo(value.Y, nameof(value.Y), MinPercentageLocation);
				ArgChecker.InRangeInclusive(value.Width, nameof(value.Width), MinPercentageSize, MaxPercentageSize);
				ArgChecker.InRangeInclusive(value.Height, nameof(value.Height), MinPercentageSize, MaxPercentageSize);
				_percentsCropRect = value;
			}
		}

		public CropType CropType { get; set; }

		public CropFilterSettingsModel Copy()
		{
			return new CropFilterSettingsModel
			{
				CropType = CropType,
				PixelsCropRect = PixelsCropRect,
				PercentsCropRect = PercentsCropRect
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			ICroppingAlgorithm croppingAlgorithm = null;
			switch (CropType)
			{
				case CropType.Pixels:
					croppingAlgorithm = new FixedCropping(PixelsCropRect);
					break;
				case CropType.Percents:
					RectangleF normalizedRect = new RectangleF
					{
						X = PercentsCropRect.X / MaxPercentage,
						Y = PercentsCropRect.Y / MaxPercentage,
						Width = PercentsCropRect.Width / MaxPercentage,
						Height = PercentsCropRect.Height / MaxPercentage
					};
					croppingAlgorithm = new NormalizedCropping(normalizedRect);
					break;
			}
			yield return new CropFilter(croppingAlgorithm);
		}

		private Rectangle _pixelsCropRect;
		private RectangleF _percentsCropRect;
	}
}
