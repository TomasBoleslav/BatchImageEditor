using System;
using System.Drawing;

namespace ImageFilters
{
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
			Thrower.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			DirectBitmap output = Crop(inputBitmap);
			inputBitmap.Dispose();
			inputBitmap = output;
		}

		private readonly ICroppingAlgorithm _croppingStrategy;

		private DirectBitmap Crop(DirectBitmap input)
		{
			Rectangle cropArea = _croppingStrategy.ComputeCropArea(input.Width, input.Height);
			cropArea.Width = Math.Max(cropArea.Width, 1);
			cropArea.Height = Math.Max(cropArea.Height, 1);
			var output = new DirectBitmap(cropArea.Width, cropArea.Height, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				var destinationRect = new Rectangle(0, 0, output.Width, output.Height);
				graphics.DrawImage(input.Bitmap, destinationRect, cropArea, GraphicsUnit.Pixel);
			}
			return output;
		}

		private interface ICroppingAlgorithm
		{
			Rectangle ComputeCropArea(int imageWidth, int imageHeight);
		}

		private class FixedCropping : ICroppingAlgorithm
		{
			public FixedCropping(Rectangle fixedCropArea)
			{
				Thrower.ThrowIfNotGreaterThan(fixedCropArea.Width, nameof(fixedCropArea.Width), 0);
				Thrower.ThrowIfNotGreaterThan(fixedCropArea.Height, nameof(fixedCropArea.Height), 0);
				_cropArea = fixedCropArea;
			}

			public Rectangle ComputeCropArea(int imageWidth, int imageHeight)
			{
				return _cropArea;
			}

			private readonly Rectangle _cropArea;
		}

		private class PercentageCropping : ICroppingAlgorithm
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
					throw new ArgumentException("Percentages of a crop area must belong to the inclusive range of 0 and 1.");
				}
				Thrower.ThrowIfNotGreaterThan(percentageCropArea.Width, nameof(percentageCropArea.Width), 0.0f);
				Thrower.ThrowIfNotGreaterThan(percentageCropArea.Height, nameof(percentageCropArea.Height), 0.0f);
			}

			private static bool IsPercentage(float value)
			{
				return 0.0f <= value && value <= 1.0f;
			}

			private readonly RectangleF _percentageCropArea;
		}
	}
}