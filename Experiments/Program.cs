using System;
using ImageFilters;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Experiments
{
	class Program
	{
		static unsafe void Main(string[] args)
		{
			/*/
			int width = 2;
			int height = 2;
			var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.FromArgb(1, 2, 3));
				graphics.FillRectangle(new SolidBrush(Color.FromArgb(1, 2, 3)), 0, 0, width, height);
			}
			Color pixelColor = bitmap.GetPixel(0, 0);
			Console.WriteLine($"Color: {pixelColor.A}(A), {pixelColor.R}(R), {pixelColor.G}(G), {pixelColor.B}(B)");
			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, 1, 1), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			Console.WriteLine($"Stride: {data.Stride}");
			byte* pixelPtr = (byte*)data.Scan0;
			Console.WriteLine($"Color from ptr: {pixelPtr[0]}, {pixelPtr[1]}, {pixelPtr[2]}, {pixelPtr[3]}");
			/**/
			int width = 100;
			int height = 100;
			using var bitmap = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);
			using (var graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.FromArgb(50, 50, 50));
			}
			bitmap.Save(@"C:\Users\boles\Plocha\sedy.png");
		}
	}
}
