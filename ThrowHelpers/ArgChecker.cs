using System;

namespace ThrowHelpers
{
	/// <summary>
	/// A helper class for checking arguments.
	/// </summary>
	public static class ArgChecker
	{
		/// <summary>
		/// Verifies that a reference is not null.
		/// </summary>
		/// <param name="instance">An object reference to check.</param>
		/// <param name="name">The name of an argument.</param>
		public static void NotNull(object instance, string name)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		/// <summary>
		/// Verifies that a value is positive.
		/// </summary>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
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

		/// <summary>
		/// Verifies that a value is positive.
		/// </summary>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
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

		/// <summary>
		/// Verifies that a value is positive.
		/// </summary>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
		public static void Positive(double value, string name)
		{
			if (value <= 0.0)
			{
				throw new ArgumentException(
					$"Value of {name} must be positive.",
					name
					);
			}
		}

		/// <summary>
		/// Verifies that a value is non-negative.
		/// </summary>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
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

		/// <summary>
		/// Verifies that a value is less than other.
		/// </summary>
		/// <typeparam name="T">The type of the compared value.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
		/// <param name="other">A value used for comparison.</param>
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

		/// <summary>
		/// Verifies that a value is greater than other.
		/// </summary>
		/// <typeparam name="T">The type of the compared value.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
		/// <param name="other">A value used for comparison.</param>
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

		/// <summary>
		/// Verifies that a value is greater than or equal to other.
		/// </summary>
		/// <typeparam name="T">The type of the compared value.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
		/// <param name="other">A value used for comparison.</param>
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

		/// <summary>
		/// Verifies that a value belongs to the inclusive range from the given lower bound to the given upper bound.
		/// </summary>
		/// <typeparam name="T">The type of the bounds.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="name">The name of an argument.</param>
		/// <param name="lowerBound">The lower bound of the range.</param>
		/// <param name="upperBound">The upper bound of the range.</param>
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
	}
}
