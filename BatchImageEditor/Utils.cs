
namespace BatchImageEditor
{
	static class Utils
	{
		public static void Swap<T>(ref T first, ref T second)
		{
			T temp = first;
			first = second;
			second = temp;
		}
	}
}
