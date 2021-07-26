using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
	public class ResizingFilter : IImageFilter
	{
		public ResizingFilter(int newWidth, int newHeight)
		{
			this.newWidth = newWidth;
			this.newHeight = newHeight;
		}

		public Bitmap Apply(Bitmap bitmap)
		{
			return bitmap.Resize(newWidth, newHeight);
		}

		private readonly int newWidth;
		private readonly int newHeight;
	}
}
