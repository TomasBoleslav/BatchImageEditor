using BenchmarkDotNet.Attributes;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Benchmarks
{
	[HtmlExporter]
	public class LinearVsSeparableFilterBenchmarks
	{
		private static readonly PixelFormat pixelFormat = PixelFormat.Format24bppRgb;

		[Params(3, 5, 9)]
		public int KernelSize { get; set; }

		[Benchmark]
		public void LinearFilter_100x100()
		{
			ApplyLinearFilter(100, 100);
		}
		
		[Benchmark]
		public void LinearFilter_1000x1000()
		{
			ApplyLinearFilter(1000, 1000);
		}

		[Benchmark]
		public void SeparableFilter_100x100()
		{
			ApplySeparableFilter(100, 100);
		}

		[Benchmark]
		public void SeparableFilter_1000x1000()
		{
			ApplySeparableFilter(1000, 1000);
		}

		private void ApplyLinearFilter(int width, int height)
		{
			var directBitmap = new DirectBitmap(width, height, pixelFormat);
			float[][] kernel = CreateMatrixOfOnes(KernelSize, KernelSize);
			var filter = new CustomLinearFilter(kernel);
			filter.Apply(ref directBitmap);
		}

		private void ApplySeparableFilter(int width, int height)
		{
			var directBitmap = new DirectBitmap(width, height, pixelFormat);
			float[] vector = CreateVectorOfOnes(KernelSize);
			var filter = new CustomSeparableLinearFilter(vector, vector);
			filter.Apply(ref directBitmap);
		}

		private static float[] CreateVectorOfOnes(int length)
		{
			float[] vector = new float[length];
			for (int i = 0; i < length; i++)
			{
				vector[i] = 1.0f;
			}
			return vector;
		}

		private static float[][] CreateMatrixOfOnes(int rowCount, int columnCount)
		{
			float[][] matrix = new float[rowCount][];
			for (int i = 0; i < rowCount; i++)
			{
				matrix[i] = new float[columnCount];
				for (int j = 0; j < columnCount; j++)
				{
					matrix[i][j] = 1.0f;
				}
			}
			return matrix;
		}
	}
}
