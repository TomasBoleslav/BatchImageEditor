using System;

namespace ThrowHelpers
{
	public static class ComparableExtensions
	{
		public static bool LessThan<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) < 0;
		}

		public static bool LessThanOrEqualTo<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) <= 0;
		}

		public static bool GreaterThan<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) > 0;
		}

		public static bool GreaterThanOrEqualTo<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) >= 0;
		}

		public static bool EqualTo<T>(this IComparable<T> value, T other)
		{
			return value.CompareTo(other) == 0;
		}
	}
}
