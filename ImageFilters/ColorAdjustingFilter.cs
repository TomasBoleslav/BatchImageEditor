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

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ArgChecker.NotNull(inputBitmap, nameof(inputBitmap));
			AdjustColors(inputBitmap);
		}

		private readonly IColorAdjuster _colorAdjuster;

		private void AdjustColors(DirectBitmap input)
		{
			for (int y = 0; y < input.Height; y++)
			{
				for (int x = 0; x < input.Width; x++)
				{
					Color inputColor = input.GetPixel(x, y);
					Color outputColor = _colorAdjuster.Adjust(inputColor);
					input.SetPixel(x, y, outputColor);
				}
			}
		}
	}
}
