using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public static class FilterSettingsNames
	{
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
			{ typeof(ImageOverlayFilterSettings), "Image Overlay" },
			{ typeof(FlipFilterSettings), "Flip" },
			{ typeof(ContrastBrightnessFilterSettings), "Contrast And Brightness" },
			{ typeof(RotationFilterSettings), "Rotate" },
			{ typeof(ColorChannelsFilterSettings), "Channels" },
			{ typeof(CropFilterSettings), "Crop" },
			{ typeof(GaussianBlurFilterSettings), "Gaussian Blur" },
			{ typeof(EmptyFilterSettings<HighPassFilter>), "High Pass" },
		};
	}
}
