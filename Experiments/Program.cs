using System;
using ImageFilters;
using System.Drawing;
using System.IO;

namespace Experiments
{
	class Program
	{
		static void Main(string[] args)
		{
			Bitmap bitmap;
			var fs = new FileStream(@"C:\Users\boles\Plocha\image.png", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			using (var loadedBitmap = new Bitmap(@"C:\Users\boles\Plocha\web-inspirace2.jpg"))
			{
				bitmap = loadedBitmap.Copy();
			}
			bitmap.Save(@"C:\Users\boles\Plocha\image.png");
			bitmap.Dispose();
		}
	}
}
