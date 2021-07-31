using System;
using System.Drawing;

namespace ImageFilters
{
	public sealed class CropFilter : IImageFilter
	{
		public CropFilter(ICroppingAlgorithm croppingAlgorithm)
		{
			_croppingAlgorithm = croppingAlgorithm;
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			Ensure.NotNull(inputBitmap, nameof(inputBitmap));
			DirectBitmap output = Crop(inputBitmap);
			inputBitmap.Dispose();
			inputBitmap = output;
		}

		private readonly ICroppingAlgorithm _croppingAlgorithm;

		private DirectBitmap Crop(DirectBitmap input)
		{
			Rectangle cropArea = _croppingAlgorithm.ComputeCropArea(input.Bitmap.Size);
			cropArea.Width = Math.Max(cropArea.Width, 1);
			cropArea.Height = Math.Max(cropArea.Height, 1);
			var output = new DirectBitmap(cropArea.Width, cropArea.Height, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				var destRect = new Rectangle(0, 0, output.Width, output.Height);
				graphics.DrawImage(input.Bitmap, destRect, cropArea, GraphicsUnit.Pixel);
			}
			return output;
		}
	}
}
