using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
	// TODO: contrast, brightness, hsv, rgb
	public class ColorAdjustingFilterWithStrategy : IImageFilter
	{
		public ColorAdjustingFilterWithStrategy(IColorAdjustment colorAdjustment)
		{
			ThrowHelper.ThrowIfNull(colorAdjustment, nameof(colorAdjustment));
			_colorAdjustment = colorAdjustment;
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			ApplyColorAdjustment(inputBitmap);
		}

		private readonly IColorAdjustment _colorAdjustment;

		private void ApplyColorAdjustment(DirectBitmap input)
		{
			for (int y = 0; y < input.Height; y++)
			{
				for (int x = 0; x < input.Width; x++)
				{
					Color inputColor = input.GetPixel(x, y);
					Color outputColor = _colorAdjustment.Apply(inputColor);
					input.SetPixel(x, y, outputColor);
				}
			}
		}
	}
}
