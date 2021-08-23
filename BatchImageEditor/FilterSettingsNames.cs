using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Contains a mapping from types of <see cref="FilterSettingsBase"/> to their names to be displayed for the user.
	/// All the names are unique.
	/// </summary>
	internal static class FilterSettingsNames
	{
		/// <summary>
		/// Gets a name of the given type of settings.
		/// </summary>
		/// <param name="filterSettingsType">A type of settings.</param>
		/// <returns>A name of the given type of settings.</returns>
		/// <exception cref="ArgumentException">Thrown when the type is invalid or the settings are not named.</exception>
		public static string GetName(Type filterSettingsType)
		{
			if (settingTypesToNames.TryGetValue(filterSettingsType, out string name))
			{
				return name;
			}
			throw new ArgumentException("There is no name for the given type of settings.");
		}

		private static readonly Dictionary<Type, string> settingTypesToNames = new()
		{
			{ typeof(MedianFilterSettings), "Median" },
			{ typeof(ResizingFilterSettings), "Resize" },
			{ typeof(ImageInsertFilterSettings), "Insert Image" },
			{ typeof(FlipFilterSettings), "Flip" },
			{ typeof(ContrastBrightnessFilterSettings), "Contrast And Brightness" },
			{ typeof(RotationFilterSettings), "Rotate" },
			{ typeof(ColorChannelsFilterSettings), "Channels" },
			{ typeof(CropFilterSettings), "Crop" },
			{ typeof(GaussianBlurFilterSettings), "Gaussian Blur" },
			{ typeof(EmptyFilterSettings<HighPassFilter>), "High Pass Sharpen" },
		};
	}
}
