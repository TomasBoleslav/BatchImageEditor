using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace ImageFilters.Benchmarks
{
	[HtmlExporter]
	public class SortVsCountingSortForColors
	{
		public class Parameters
		{
			public Parameters(int numArrays, int arrayLength)
			{
				ArrayLength = arrayLength;
				NumArrays = numArrays;
				Arrays = CreateColorChannelArrays(numArrays, arrayLength, new Random(10));
			}

			public int ArrayLength { get; }		// number of pixels in one window
			public int NumArrays { get; }		// image size in pixels
			public byte[][] Arrays { get; }

			private static byte[][] CreateColorChannelArrays(int numArrays, int arrayLength, Random random)
			{
				byte[][] arrays = new byte[numArrays][];
				for (int i = 0; i < numArrays; i++)
				{
					arrays[i] = new byte[arrayLength];
					random.NextBytes(arrays[i]);
				}
				return arrays;
			}

			public override string ToString() => $"Array length: {ArrayLength}, Count: {NumArrays}";
		}

		public IEnumerable<object[]> GetParameters()
		{
			int[] arrayCounts = new int[] { 100 * 100, 1000 * 1000 };
			int[] lengths = new int[] { 3 * 3, 5 * 5, 9 * 9, 20 * 20 };
			for (int i = 0; i < arrayCounts.Length; i++)
			{
				for (int j = 0; j < lengths.Length; j++)
				{
					yield return new object[] { new Parameters(arrayCounts[i], lengths[j]) };
				}
			}
		}

		[Benchmark]
		[ArgumentsSource(nameof(GetParameters))]
		public void CountingSort(Parameters parameters)
		{
			for (int i = 0; i < parameters.NumArrays; i++)
			{
				byte[] array = parameters.Arrays[i];
				CountingSortByteArray(array);
			}
		}

		[Benchmark]
		[ArgumentsSource(nameof(GetParameters))]
		public void ArraySort(Parameters parameters)
		{
			for (int i = 0; i < parameters.NumArrays; i++)
			{
				byte[] array = parameters.Arrays[i];
				Array.Sort(array);
			}
		}

		private static void CountingSortByteArray(byte[] array)
		{
			int n = array.Length;
			byte[] counts = new byte[byte.MaxValue];
			
		}
	}
}
