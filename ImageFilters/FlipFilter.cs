using System;
using System.Drawing;

namespace ImageFilters
{
	// TODO: pass enum or strategy to constructor? - if using common ancestor for Resize, Flip and Rotate, then pass strategy to constructor (too many options)
	public enum FlipType
	{
		Horizontal,
		Vertical
	}

	public sealed class FlipFilter : IImageFilter
	{
		public FlipFilter(FlipType flipType)
		{
			switch (flipType)
			{
				case FlipType.Horizontal:
					_flipStrategy = new HorizontalFlipping();
					break;
				case FlipType.Vertical:
					_flipStrategy = new VerticalFlipping();
					break;
				default:
					throw new ArgumentException("Invalid flip type.");
			}
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			DirectBitmap outputBitmap = Flip(inputBitmap);
			inputBitmap.Dispose();
			inputBitmap = outputBitmap;
		}

		private readonly IFlipStrategy _flipStrategy;

		private DirectBitmap Flip(DirectBitmap input)
		{
			Size inputSize = input.Bitmap.Size;
			Rectangle srcRect = new Rectangle(0, 0, input.Width, input.Height);
			Rectangle destRect = _flipStrategy.ComputeDestRect(inputSize);
			int outputWidth = Math.Abs(destRect.Width);
			int outputHeight = Math.Abs(destRect.Height);
			var output = new DirectBitmap(outputWidth, outputHeight, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				graphics.DrawImage(input.Bitmap, srcRect, destRect, GraphicsUnit.Pixel);
			}
			return output;
		}

		private interface IFlipStrategy
		{
			Rectangle ComputeDestRect(Size inputSize);
		}

		private class VerticalFlipping : IFlipStrategy
		{
			public Rectangle ComputeDestRect(Size inputSize)
			{
				return new Rectangle
				{
					X = inputSize.Width,
					Y = 0,
					Width = -inputSize.Width,
					Height = inputSize.Height
				};
			}
		}

		private class HorizontalFlipping : IFlipStrategy
		{
			public Rectangle ComputeDestRect(Size inputSize)
			{
				return new Rectangle
				{
					X = 0,
					Y = inputSize.Height,
					Width = inputSize.Width,
					Height = -inputSize.Height
				};
			}
		}
	}
}
