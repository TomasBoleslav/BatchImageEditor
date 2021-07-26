using System;

namespace ImageFilters
{
	internal static class ThrowHelper
	{
		public static void ThrowIfNull(object parameter, string name = null)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(name);
			}
		}
	}
}
