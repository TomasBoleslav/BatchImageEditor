using System.Drawing;

namespace ImageFilters
{
	public abstract class ColorAdjustingFilter : IImageFilter
	{
		public void Apply(ref DirectBitmap inputBitmap)
		{
			ThrowHelper.ThrowIfNull(inputBitmap, nameof(inputBitmap));
			ApplyColorAdjustment(inputBitmap);
		}

		protected abstract Color AdjustColor(Color color);

		private void ApplyColorAdjustment(DirectBitmap input)
		{
			for (int y = 0; y < input.Height; y++)
			{
				for (int x = 0; x < input.Width; x++)
				{
					Color inputColor = input.GetPixel(x, y);
					Color outputColor = AdjustColor(inputColor);
					input.SetPixel(x, y, outputColor);
				}
			}
		}
	}
}
