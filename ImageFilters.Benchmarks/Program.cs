using BenchmarkDotNet.Running;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters.Benchmarks
{
	class Program
	{
		static void Main(string[] args)
		{
			//var summary = BenchmarkRunner.Run<LinearFilterVsSeparableFilter>();
			//var summary = BenchmarkRunner.Run<DirectBitmapCopyBenchmark>();
			//var summary = BenchmarkRunner.Run<DirectBitmapVsLockedBitmap>();
			//var summary = BenchmarkRunner.Run<FastDirectBitmapVsLockedBitmap>();

			Bitmap bitmap = new Bitmap(10, 10, PixelFormat.Format32bppPArgb);
			bitmap.SetPixel(0, 0, Color.FromArgb(100, 200, 0, 0));
			using (var g = Graphics.FromImage(bitmap))
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(50, 20, 0, 0)), 0, 0, 10, 10);
			}
			Color color = bitmap.GetPixel(0, 0);
			Console.WriteLine(color);

			bitmap = new Bitmap(10, 10, PixelFormat.Format32bppArgb);
			bitmap.SetPixel(0, 0, Color.FromArgb(100, 200, 0, 0));
			using (var g = Graphics.FromImage(bitmap))
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(50, 20, 0, 0)), 0, 0, 10, 10);
			}
			color = bitmap.GetPixel(0, 0);
			Console.WriteLine(color);

			DirectBitmap directBitmap = new DirectBitmap(10, 10);
			directBitmap.SetPixel(0, 0, Color.FromArgb(100, 200, 0, 0));
			Console.WriteLine(directBitmap.GetPixel(0, 0));
			Console.WriteLine(directBitmap.Bitmap.GetPixel(0, 0));
			using (var g = Graphics.FromImage(directBitmap.Bitmap))
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(50, 20, 0, 0)), 0, 0, 10, 10);
			}
			color = directBitmap.GetPixel(0, 0);
			Console.WriteLine(color);
		}
	}
}
