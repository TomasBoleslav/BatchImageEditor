using System;
using ImageFilters;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Experiments
{
	class Program
	{
		static void Main(string[] args)
		{
			Bitmap bitmap = new Bitmap(100, 100, PixelFormat.1);
			bitmap.Save(@"C:\Users\boles\Plocha\image.jpg", ImageFormat.Jpeg);
			bitmap.Dispose();
		}
	}
}
