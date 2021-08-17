using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class FlipFilter : IImageFilter
	{
		public FlipFilter(FlipType flipType)
		{
			if (!Enum.IsDefined(typeof(FlipType), flipType))
			{
				throw new ArgumentException("Invalid flip type.");
			}
			_flipType = flipType;
		}

		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			DirectBitmap flippedImage = Flip(image);
			image.Dispose();
			image = flippedImage;
		}

		private readonly FlipType _flipType;

		private DirectBitmap Flip(DirectBitmap inputImage)
		{
			Rectangle destRect = ComputeDestRect(inputImage.Bitmap.Size);
			int outputWidth = Math.Abs(destRect.Width);
			int outputHeight = Math.Abs(destRect.Height);
			var outputImage = new DirectBitmap(outputWidth, outputHeight);
			using (var graphics = Graphics.FromImage(outputImage.Bitmap))
			{
				Rectangle srcRect = new Rectangle(0, 0, inputImage.Width, inputImage.Height);
				graphics.DrawImage(inputImage.Bitmap, srcRect, destRect, GraphicsUnit.Pixel);
			}
			return outputImage;
		}

		private Rectangle ComputeDestRect(Size inputSize)
		{
			return _flipType switch
			{
				FlipType.Horizontal => new Rectangle
				{
					X = 0,
					Y = inputSize.Height,
					Width = inputSize.Width,
					Height = -inputSize.Height
				},
				FlipType.Vertical => new Rectangle
				{
					X = inputSize.Width,
					Y = 0,
					Width = -inputSize.Width,
					Height = inputSize.Height
				},
				FlipType.Both => new Rectangle
				{
					X = inputSize.Width,
					Y = inputSize.Height,
					Width = -inputSize.Width,
					Height = -inputSize.Height
				},
				_ => throw new ArgumentException("Invalid flip type.")
			};
		}
	}
}
