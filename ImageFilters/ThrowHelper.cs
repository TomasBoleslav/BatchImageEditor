using System;

namespace ImageFilters
{
	internal static class ThrowHelper
	{
		public static void ThrowIfNull(object parameter, string parameterName)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}

		public static void ThrowIfNotPositive(int value, string parameterName)
		{
			if (value <= 0)
			{
				throw new ArgumentException(
					$"Parameter {parameterName} must be a positive integer.",
					parameterName
					);
			}
		}

		public static void ThrowIfNotPositive(float value, string parameterName)
		{
			if (value <= 0f)
			{
				throw new ArgumentException(
					$"Parameter {parameterName} must be a positive floating point number.",
					parameterName
					);
			}
		}
	}
}
