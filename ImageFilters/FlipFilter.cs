using System;
using System.Drawing;

namespace ImageFilters
{
	public enum FlipType
	{
		Horizontal,
		Vertical,
		Both
	}

	public sealed class FlipFilter : IImageFilter
	{
		public FlipFilter(FlipType flipType)
		{
			if (!Enum.IsDefined(typeof(FlipType), flipType))
			{
				throw new ArgumentException("Invalid flip type.");
			}
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			Thrower.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			DirectBitmap outputBitmap = Flip(inputBitmap);
			inputBitmap.Dispose();
			inputBitmap = outputBitmap;
		}

		private readonly FlipType _flipType;

		private DirectBitmap Flip(DirectBitmap input)
		{
			Rectangle srcRect = new Rectangle(0, 0, input.Width, input.Height);
			Rectangle destRect = ComputeDestRect(input.Bitmap.Size);
			int outputWidth = Math.Abs(destRect.Width);
			int outputHeight = Math.Abs(destRect.Height);
			var output = new DirectBitmap(outputWidth, outputHeight, input.PixelFormat);
			using (var graphics = Graphics.FromImage(output.Bitmap))
			{
				graphics.DrawImage(input.Bitmap, srcRect, destRect, GraphicsUnit.Pixel);
			}
			return output;
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
