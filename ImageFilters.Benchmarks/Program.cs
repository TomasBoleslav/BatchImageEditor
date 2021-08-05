using BenchmarkDotNet.Running;

namespace ImageFilters.Benchmarks
{
	class Program
	{
		static void Main(string[] args)
		{
			//var summary = BenchmarkRunner.Run<LinearVsSeparableFilterBenchmarks>();
			var summary = BenchmarkRunner.Run<DirectBitmapCopyBenchmark>();
		}
	}
}
