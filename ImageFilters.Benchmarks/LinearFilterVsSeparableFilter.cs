using BenchmarkDotNet.Attributes;
using System.Drawing.Imaging;

namespace ImageFilters.Benchmarks
{
	[HtmlExporter]
	public class LinearFilterVsSeparableFilter
	{
		private const PixelFormat PixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;

		[Params(3, 5, 9)]
		public int KernelSize { get; set; }

		[Params(100, 1000)]
		public int ImageSize { get; set; }

		[Benchmark]
		public void LinearFilter()
		{
			var directBitmap = new ImageFilters.DirectBitmap(ImageSize, ImageSize);
			float[][] kernel = CreateMatrixOfOnes(KernelSize, KernelSize);
			var filter = new CustomLinearFilter(kernel);
			filter.Apply(ref directBitmap);
		}

		[Benchmark]
		public void SeparableFilter()
		{
			var directBitmap = new ImageFilters.DirectBitmap(ImageSize, ImageSize);
			float[] vector = CreateVectorOfOnes(KernelSize);
			var filter = new CustomSeparableFilter(vector, vector);
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
