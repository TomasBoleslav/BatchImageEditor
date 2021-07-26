using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImageFilters
{
	public abstract class SymmetricalLinearFilter : IImageFilter
	{
		public Bitmap Apply(Bitmap bitmap)
		{
			throw new NotImplementedException();
		}

		protected abstract double[][] GetFilterMatrix();
	}
}
