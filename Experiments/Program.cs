using System;

namespace Experiments
{
	class Program
	{
		static Action<string> Act;

		static void Write(string message)
		{
			Console.WriteLine(message);
		}

		static void Main(string[] args)
		{
			Act = Write;
			Act?.Invoke("Hello!");
		}
	}
}
