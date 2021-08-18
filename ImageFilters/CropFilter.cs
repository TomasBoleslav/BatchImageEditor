using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class CropFilter : IImageFilter
	{
		public CropFilter(ICroppingAlgorithm croppingAlgorithm)
		{
			_croppingAlgorithm = croppingAlgorithm;
		}

		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			DirectBitmap croppedImage = Crop(image);
			image.Dispose();
			image = croppedImage;
		}

		private readonly ICroppingAlgorithm _croppingAlgorithm;

		private DirectBitmap Crop(DirectBitmap inputImage)
		{
			Rectangle cropArea = _croppingAlgorithm.ComputeCropArea(inputImage.Bitmap.Size);
			cropArea.Width = Math.Max(cropArea.Width, 1);
			cropArea.Height = Math.Max(cropArea.Height, 1);
			var outputImage = new DirectBitmap(cropArea.Width, cropArea.Height);
			using (var graphics = Graphics.FromImage(outputImage.Bitmap))
			{
				var destRect = new Rectangle(0, 0, outputImage.Width, outputImage.Height);
				graphics.DrawImage(inputImage.Bitmap, destRect, cropArea, GraphicsUnit.Pixel);
			}
			return outputImage;
		}
	}
}
