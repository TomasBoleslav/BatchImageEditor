using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// An image filter that adjusts colors in the image one by one.
	/// </summary>
	public sealed class ColorAdjustingFilter : IImageFilter
	{
		/// <summary>
		/// Creates an instance of <see cref="ColorAdjustingFilter"/> with a color adjuster for computing new colors.
		/// </summary>
		/// <param name="colorAdjuster">A color adjuster for computing new colors.</param>
		public ColorAdjustingFilter(IColorAdjuster colorAdjuster)
		{
			ArgChecker.NotNull(colorAdjuster, nameof(colorAdjuster));
			_colorAdjuster = colorAdjuster;
		}

		/// <inheritdoc/>
		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			AdjustColors(image);
		}

		private readonly IColorAdjuster _colorAdjuster;

		/// <summary>
		/// Adjusts colors in an image.
		/// </summary>
		/// <param name="image">An image whose colors will be adjusted.</param>
		private void AdjustColors(DirectBitmap image)
		{
			for (int y = 0; y < image.Height; y++)
			{
				for (int x = 0; x < image.Width; x++)
				{
					Color inputColor = image.GetPixel(x, y);
					Color outputColor = _colorAdjuster.Adjust(inputColor);
					image.SetPixel(x, y, outputColor);
				}
			}
		}
	}
}
