using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using ImageFilters;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of image insert filter settings.
	/// </summary>
	internal sealed class ImageInsertFilterSettingsModel : IFilterSettingsModel<ImageInsertFilterSettingsModel>
	{
		public const ImagePlacement DefaultImagePlacement = ImagePlacement.TopLeft;
		public const int MaxDelta = 10_000;
		public const int MinDelta = -MaxDelta;
		public const int DefaultDelta = 0;

		/// <summary>
		/// Creates an instance of <see cref="ImageInsertFilterSettingsModel"/> with default settings.
		/// </summary>
		public ImageInsertFilterSettingsModel()
		{
			ImagePlacement = DefaultImagePlacement;
			DeltaX = DefaultDelta;
			DeltaY = DefaultDelta;
		}

		/// <summary>
		/// Gets or sets the image to insert.
		/// </summary>
		public Bitmap InsertedImage { get; set; }

		/// <summary>
		/// Gets or sets the image placement of the image to insert.
		/// </summary>
		public ImagePlacement ImagePlacement { get; set; }

		/// <summary>
		/// Gets or sets the X location of the image to insert.
		/// </summary>
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

		/// <summary>
		/// Gets or sets the Y location of the image to insert.
		/// </summary>
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

		/// <inheritdoc/>
		public ImageInsertFilterSettingsModel Copy()
		{
			return new ImageInsertFilterSettingsModel
			{
				InsertedImage = InsertedImage,
				ImagePlacement = ImagePlacement,
				DeltaX = DeltaX,
				DeltaY = DeltaY
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			if (InsertedImage == null)
			{
				return Enumerable.Empty<IImageFilter>();
			}
			return new[] { new ImageInsertFilter(InsertedImage, ImagePlacement, DeltaX, DeltaY) };
		}

		private int _deltaX;
		private int _deltaY;
	}
}
