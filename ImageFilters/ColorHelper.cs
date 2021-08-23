
namespace ImageFilters
{
	/// <summary>
	/// Helper functions related to colors.
	/// </summary>
	internal static class ColorHelper
	{
		/// <summary>
		/// Clamps a color channel stored as a float.
		/// </summary>
		/// <param name="channel">A color channel.</param>
		/// <returns>The clamped color channel.</returns>
		public static byte ClampColorChannel(float channel)
		{
			if (channel <= 0.0f)
			{
				return 0;
			}
			else if (channel >= 255.0f)
			{
				return byte.MaxValue;
			}
			return (byte)channel;
		}
	}
}
