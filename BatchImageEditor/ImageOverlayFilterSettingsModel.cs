using System.Collections.Generic;
using System.Linq;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class ImageOverlayFilterSettingsModel : IFilterSettingsModel<ImageOverlayFilterSettingsModel>
	{
		public const ImagePlacement DefaultImagePlacement = ImagePlacement.TopLeft;
		public const int MaxDelta = 10_000;
		public const int MinDelta = -MaxDelta;
		public const int DefaultDelta = 0;

		public ImageOverlayFilterSettingsModel()
		{
			ImagePlacement = DefaultImagePlacement;
			DeltaX = DefaultDelta;
			DeltaY = DefaultDelta;
		}

		public DirectBitmap OverlayImage { get; set; }

		public ImagePlacement ImagePlacement { get; set; }

		public int DeltaX
		{
			get
			{
				return _deltaX;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_deltaX = value;
			}
		}

		public int DeltaY
		{
			get
			{
				return _deltaY;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinDelta, MaxDelta);
				_deltaY = value;
			}
		}

		public ImageOverlayFilterSettingsModel Copy()
		{
			return new ImageOverlayFilterSettingsModel
			{
				OverlayImage = OverlayImage,
				ImagePlacement = ImagePlacement,
				DeltaX = DeltaX,
				DeltaY = DeltaY
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			if (OverlayImage == null)
			{
				return Enumerable.Empty<IImageFilter>();
			}
			return new[] { new ImageOverlayFilter(OverlayImage, ImagePlacement, DeltaX, DeltaY) };
		}

		private int _deltaX;
		private int _deltaY;
	}
}
