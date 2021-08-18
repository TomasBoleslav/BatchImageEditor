using System;
//using ImageFilters;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Experiments
{
	class Program
	{
		enum MyEnum
		{
			Value1 = 5,
			Value2 = 10
		}

		public static Dictionary<string, int> GetNamesToValues<T>(IEnumerable<KeyValuePair<string, T>> namesToEnumValues) where T : Enum
		{
			Dictionary<string, int> namesToIntValues = new Dictionary<string, int>();
			IEnumerable<int> values = Enum.GetValues(typeof(T)).Cast<int>();
			//int x = (int)values[0];
			var values2 = Enum.GetValues(typeof(T));
			//int x2 = (int)values[0];
			foreach (var value in values)
			{

			}
			foreach ((string name, T enumValue) in namesToEnumValues)
			{
				if (!namesToIntValues.ContainsKey(name))
				{
					//namesToIntValues.Add(name, (int)enumValue);
				}
			}
			return namesToIntValues;
		}

		abstract class A
		{
			public A() { Console.WriteLine("A"); }
		}

		class B : A
		{
			public B() { Console.WriteLine("B"); }
		}

		static void Main(string[] args)
		{
			new B();
			/*Dictionary<string, MyEnum> d = new()
			{
				{ "value1", MyEnum.Value1 }
			};
			var d2 = GetNamesToValues(d);
			foreach (var item in d2)
			{
				Console.WriteLine($"{item.Key}, {item.Value}");
			}*/
			/*
			Bitmap bitmap = new Bitmap(10, 10, PixelFormat.Format32bppPArgb);
			bitmap.SetPixel(0, 0, Color.FromArgb(100, 200, 0, 0));
			Color color = bitmap.GetPixel(0, 0);
			Console.WriteLine(color);

			bitmap = new Bitmap(10, 10, PixelFormat.Format32bppArgb);
			bitmap.SetPixel(0, 0, Color.FromArgb(100, 200, 0, 0));
			color = bitmap.GetPixel(0, 0);
			Console.WriteLine(color);*/
		}

		private static double GaussianBlurSum(int radius, double sigma)
		{
			double sum = 0;
			float[] convolutionVector = new float[2 * radius + 1];
			for (int x = -radius; x <= radius; x++)
			{
				double exponent = -(x * x) / (sigma * sigma);
				double eExpression = Math.Pow(Math.E, exponent);
				double denominator = 2 * Math.PI * sigma * sigma;
				double vectorValue = Math.Sqrt(eExpression / denominator);
				convolutionVector[x + radius] = (float)vectorValue;
				sum += vectorValue;
			}
			return sum;
		}

	}
}
