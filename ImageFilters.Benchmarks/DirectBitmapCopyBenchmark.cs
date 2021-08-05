using BenchmarkDotNet.Attributes;
using System;
using System.Drawing.Imaging;

namespace ImageFilters.Benchmarks
{
	[HtmlExporter]
	public class DirectBitmapCopyBenchmark
	{
		[Params(1000, 3000)]
		public int Width { get; set; }

		[Params(1000, 3000)]
		public int Height { get; set; }

		[Params(100)]
		public int Count { get; set; }

		[Benchmark]
		public void DirectBitmapCopy()
		{
			DirectBitmap image = new DirectBitmap(Width, Height, PixelFormat.Format24bppRgb);
			DirectBitmap copy = null;
			for (int i = 0; i < Count; i++)
			{
				copy?.Dispose();
				copy = image.Copy();
			}
		}
	}
}
