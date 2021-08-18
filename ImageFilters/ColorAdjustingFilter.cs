using System.Drawing;
using ThrowHelpers;

namespace ImageFilters
{
	public sealed class ColorAdjustingFilter : IImageFilter
	{
		public ColorAdjustingFilter(IColorAdjuster colorAdjuster)
		{
			ArgChecker.NotNull(colorAdjuster, nameof(colorAdjuster));
			_colorAdjuster = colorAdjuster;
		}

		public void Apply(ref DirectBitmap image)
		{
			ArgChecker.NotNull(image, nameof(image));
			AdjustColors(image);
		}

		private readonly IColorAdjuster _colorAdjuster;

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
