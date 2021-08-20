using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using ImageFilters;

namespace Experiments
{
	class Program
	{
		static void Main(string[] args)
		{
			var guyImage = DirectBitmap.FromFile(@"C:\Users\boles\Plocha\experiment\guy.jpg");
			using (var graphics = Graphics.FromImage(guyImage.Bitmap))
			{
				var foodImage = DirectBitmap.FromFile(@"C:\Users\boles\Plocha\experiment\food.png");
				foodImage.Bitmap.SetResolution(graphics.DpiX, graphics.DpiY);
				graphics.DrawImage(foodImage.Bitmap, 0, 0);
				//var foodImage = new Bitmap(@"C:\Users\boles\Plocha\experiment\food.png");
				//foodImage.SetResolution(graphics.DpiX, graphics.DpiY);
				//graphics.DrawImage(foodImage, 0, 0);
			}
			guyImage.Bitmap.Save(@"C:\Users\boles\Plocha\experiment\out3.png");

			var foodBitmap = new Bitmap(@"C:\Users\boles\Plocha\experiment\food.png");
			var guyBitmap = new Bitmap(@"C:\Users\boles\Plocha\experiment\guy.jpg");
			using (var graphics = Graphics.FromImage(guyBitmap))
			{
				foodBitmap.SetResolution(graphics.DpiX, graphics.DpiY);
				graphics.DrawImage(foodBitmap, 0, 0);
			}
			guyBitmap.Save(@"C:\Users\boles\Plocha\experiment\out2.png");
		}
	}
}
