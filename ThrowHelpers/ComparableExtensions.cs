using System;

namespace ThrowHelpers
{
	/// <summary>
	/// Extension methods for the <see cref="IComparable{T}"/> instances.
	/// </summary>
	public static class ComparableExtensions
	{
		/// <summary>
		/// Checks if the given value is less than other.
		/// </summary>
		/// <typeparam name="T">The type of the value to compare against.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="other">A value used for comparison.</param>
		/// <returns>True if the value is less than other, otherwise false.</returns>
		public static bool LessThan<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) < 0;
		}

		/// <summary>
		/// Checks if the given value is less than or equal to other.
		/// </summary>
		/// <typeparam name="T">The type of the value to compare against.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="other">A value used for comparison.</param>
		/// <returns>True if the value is less than or equal to other, otherwise false.</returns>
		public static bool LessThanOrEqualTo<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) <= 0;
		}

		/// <summary>
		/// Checks if the given value is greater than other.
		/// </summary>
		/// <typeparam name="T">The type of the value to compare against.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="other">A value used for comparison.</param>
		/// <returns>True if the value is greater than other, otherwise false.</returns>
		public static bool GreaterThan<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) > 0;
		}

		/// <summary>
		/// Checks if the given value is greater than or equal to other.
		/// </summary>
		/// <typeparam name="T">The type of the value to compare against.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="other">A value used for comparison.</param>
		/// <returns>True if the value is greater than or equal to other, otherwise false.</returns>
		public static bool GreaterThanOrEqualTo<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) >= 0;
		}

		/// <summary>
		/// Checks if the given value is equal to other.
		/// </summary>
		/// <typeparam name="T">The type of the value to compare against.</typeparam>
		/// <param name="value">A value to check.</param>
		/// <param name="other">A value used for comparison.</param>
		/// <returns>True if the value is equal to other, otherwise false.</returns>
		public static bool EqualTo<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) == 0;
		}
	}
}
