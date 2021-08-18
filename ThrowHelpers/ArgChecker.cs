using System;

namespace ThrowHelpers
{
	public static class ArgChecker
	{
		public static void NotNull(object instance, string name)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		public static void Positive(int value, string name)
		{
			if (value <= 0)
			{
				throw new ArgumentException(
					$"Value of {name} must be positive.",
					name
					);
			}
		}

		public static void Positive(float value, string name)
		{
			if (value <= 0f)
			{
				throw new ArgumentException(
					$"Value of {name} must be positive.",
					name
					);
			}
		}

		public static void Nonnegative(float value, string name)
		{
			if (value < 0f)
			{
				throw new ArgumentException(
					$"Value of {name} must be non-negative.",
					name
					);
			}
		}

		public static void Nonnegative(int value, string name)
		{
			if (value < 0)
			{
				throw new ArgumentException(
					$"Value of {name} must be non-negative.",
					name
					);
			}
		}

		public static void NotLessThan<T>(IComparable<T> value, string name, T other)
		{
			if (value.LessThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be greater than or equal to {other}.",
					name
					);
			}
		}

		public static void LessThan<T>(IComparable<T> value, string name, T other)
		{
			if (!value.LessThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be less than {other}.",
					name
					);
			}
		}

		public static void NotGreaterThan<T>(IComparable<T> value, string name, T other)
		{
			if (value.GreaterThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be less than or equal to {other}.",
					name
					);
			}
		}

		public static void GreaterThan<T>(IComparable<T> value, string name, T other)
		{
			if (!value.GreaterThan(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be greater than {other}.",
					name
					);
			}
		}

		public static void GreaterThanOrEqualTo<T>(IComparable<T> value, string name, T other)
		{
			if (!value.GreaterThanOrEqualTo(other))
			{
				throw new ArgumentException(
					$"Value of {name} must be greater than or equal to {other}.",
					name
					);
			}
		}

		// The same for ThrowIfLessThan, ThrowIfGreaterThan, use T.ToString()
		public static void InRangeInclusive<T>(IComparable<T> value, string name, T lowerBound, T upperBound)
		{
			if (value.LessThan(lowerBound) || value.GreaterThan(upperBound))
			{
				throw new ArgumentException(
					$"Value of {name} must be in the inclusive range from {lowerBound} to {upperBound}.",
					name
					);
			}
		}

		public static void InRangeExclusive<T>(IComparable<T> value, string name, T lowerBound, T upperBound)
		{
			if (value.LessThanOrEqualTo(lowerBound) || value.GreaterThanOrEqualTo(upperBound))
			{
				throw new ArgumentException(
					$"Value of {name} must be in the exclusive range from {lowerBound} to {upperBound}.",
					name
					);
			}
		}
	}
}
