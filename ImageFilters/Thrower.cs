using System;

namespace ImageFilters
{
	internal static class Thrower
	{
		public static void ThrowIfNull(object instance, string name)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		public static void ThrowIfNotPositive(int value, string name)
		{
			if (value <= 0)
			{
				throw new ArgumentException(
					$"Value of {name} must be positive.",
					name
					);
			}
		}

		public static void ThrowIfNotPositive(float value, string name)
		{
			if (value <= 0f)
			{
				throw new ArgumentException(
					$"Value of {name} must be positive.",
					name
					);
			}
		}

		public static void ThrowIfNegative(float value, string name)
		{
			if (value < 0f)
			{
				throw new ArgumentException(
					$"Value of {name} cannot be negative.",
					name
					);
			}
		}

		public static void ThrowIfLessThan<T>(IComparable<T> value, string name, T other)
		{
			if (value.LessThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be greater than or equal to {other}.",
					name
					);
			}
		}

		public static void ThrowIfNotLessThan<T>(IComparable<T> value, string name, T other)
		{
			if (!value.LessThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be less than {other}.",
					name
					);
			}
		}

		public static void ThrowIfGreaterThan<T>(IComparable<T> value, string name, T other)
		{
			if (value.GreaterThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be less than or equal to {other}.",
					name
					);
			}
		}

		public static void ThrowIfNotGreaterThan<T>(IComparable<T> value, string name, T other)
		{
			if (value.GreaterThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be greater than {other}.",
					name
					);
			}
		}

		// The same for ThrowIfLessThan, ThrowIfGreaterThan, use T.ToString()
		public static void ThrowIfNotInRange<T>(IComparable<T> value, string name, T lowerBound, T upperBound)
		{
			if (value.LessThan(lowerBound) || value.GreaterThan(upperBound))
			{
				throw new ArgumentException(
					$"Value of {name} must be in the inclusive range from {lowerBound} to {upperBound}.",
					name
					);
			}
		}
	}
}
