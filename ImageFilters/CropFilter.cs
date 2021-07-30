using System;
using System.Drawing;

namespace ImageFilters
{
	//TODO: pass strategy to cnstructor? That way custom strategies can be made + no conflict in constructors if 2 strategies have the same parameters (or same types)
	// ... OR make enum options and create strategy based on that -> user does not have to pass strategies, they will pass options
	//        !!! but this does not allow passing different types of parameters !!!
	// - passing strategy in constructor is still better
	// - e.g. hsv vs rgb can be passed without conflicts for color filter
	// - instead of using strategies, is it not better to use more filters? e.g. RgbColorAdjustingFilter, HsvColorAdjustingFilter
	//     - sometimes good, sometimes not (it can lead to many classes, if there are many options, e.g. for ImageOverFilter)
	// Confusion with LinearFilter - it could be also solved using strategy, but is not - GaussianBlur, ...
	// In these cases strategy pattern is very valid - we choose part of the algorithm at runtime (by the choice of the user)
	public sealed class CropFilter : IImageFilter
	{
		public CropFilter(Rectangle absoluteCropArea)
		{
			_croppingStrategy = new FixedCropping(absoluteCropArea);
		}

		public CropFilter(RectangleF percentageCropArea)
		{
			_croppingStrategy = new PercentageCropping(percentageCropArea);
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			Rectangle cropArea = _croppingStrategy.ComputeCropArea(inputBitmap.Width, inputBitmap.Height);
			var output = new DirectBitmap(cropArea.Width, cropArea.Height, inputBitmap.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				var destinationRect = new Rectangle(0, 0, output.Width, output.Height);
				graphics.DrawImage(inputBitmap.Bitmap, destinationRect, cropArea, GraphicsUnit.Pixel);
			}
			inputBitmap.Dispose();
			inputBitmap = output;
		}

		private readonly ICroppingStrategy _croppingStrategy;

		private interface ICroppingStrategy
		{
			Rectangle ComputeCropArea(int imageWidth, int imageHeight);
		}

		private class FixedCropping : ICroppingStrategy
		{
			public FixedCropping(Rectangle fixedCropArea)
			{
				if (fixedCropArea.Width <= 0 ||
					fixedCropArea.Height <= 0)
				{
					throw new ArgumentException("Width and height of crop area must be greater than zero.");
				}
				_cropArea = fixedCropArea;
			}

			public Rectangle ComputeCropArea(int imageWidth, int imageHeight)
			{
				return _cropArea;
			}

			private readonly Rectangle _cropArea;
		}

		private class PercentageCropping : ICroppingStrategy
		{
			public PercentageCropping(RectangleF percentageCropArea)
			{
				VerifyCropAreaCorectness(percentageCropArea);
				_percentageCropArea = percentageCropArea;
			}

			public Rectangle ComputeCropArea(int imageWidth, int imageHeight)
			{
				return new Rectangle
				{
					X = (int)(imageWidth * _percentageCropArea.X),
					Y = (int)(imageHeight * _percentageCropArea.Y),
					Width = (int)(imageWidth * _percentageCropArea.Width),
					Height = (int)(imageHeight * _percentageCropArea.Height)
				};
			}

			private static void VerifyCropAreaCorectness(RectangleF percentageCropArea)
			{
				if (!IsPercentage(percentageCropArea.X) ||
					!IsPercentage(percentageCropArea.Y) ||
					!IsPercentage(percentageCropArea.Width) ||
					!IsPercentage(percentageCropArea.Height))
				{
					throw new ArgumentException("Percentages of a crop area must be between 0 and 1.");
				}
				if (percentageCropArea.Width == 0.0f ||
					percentageCropArea.Height == 0.0f)
				{
					throw new ArgumentException("Width and height percentages of a crop area must be greater than zero.");
				}
			}

			private static bool IsPercentage(float value)
			{
				return 0.0f <= value && value <= 1.0f;
			}

			private readonly RectangleF _percentageCropArea;
		}
	}
}