using System;
using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that flips an image.
	/// </summary>
	public sealed class FlipFilter : IImageFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="FlipFilter"/> that will flip an image according to the given flip type.
		/// </summary>
		/// <param name="flipType">A type of flipping to use.</param>
		public FlipFilter(FlipType flipType)
		{
			if (!Enum.IsDefined(typeof(FlipType), flipType))
			{
				throw new ArgumentException("Invalid flip type.");
			}
			_flipType = flipType;
		}

		/// <inheritdoc/>
		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			DirectBitmap flippedImage = Flip(image);
			image.Dispose();
			image = flippedImage;
		}

		private readonly FlipType _flipType;

		/// <summary>
		/// Flips an image.
		/// </summary>
		/// <param name="inputImage">An image to flip.</param>
		/// <returns>A new flipped image.</returns>
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

		/// <summary>
		/// Computes the destination rectangle where the image should be drawn.
		/// </summary>
		/// <remarks>
		/// The destination rectangle uses negative size for the image to be flipped.
		/// </remarks>
		/// <param name="inputSize">The size of an input image.</param>
		/// <returns>The destination rectangle where the image should be drawn.</returns>
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
