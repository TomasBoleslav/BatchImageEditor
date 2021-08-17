﻿using System;
using System.Collections.Generic;

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
		};
	}
}
