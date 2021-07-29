using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
	// TODO: finish when UI will be finished and the result can be tested
	// https://en.wikipedia.org/wiki/Bilateral_filter
	// make two 2D tables for Gaussian blur and all possible values I1-I2
	// - the same as in subtraction
	// TODO: similar to gaussian filter
	// - compute table for exponent |(R1, G1, B1) - (R2, G2, B2)|^2 / (2*sigma_r^2)
	// - only question: what is absolute value of color?
	// - choose L^1-norm, which is |x| = |x1| + ... + |xn|
	// - that means a table for values 0, ..., 255 * 3 (maximum diference is for (0,0,0) and (255,255,255))
	public class BilateralFilter : IImageFilter
	{
		public BilateralFilter(int radius, double sigmaSpacial, double sigmaRange)
		{
			throw new NotImplementedException();
		}

		public void Apply(ref DirectBitmap inputBitmap)
		{
			throw new NotImplementedException();
		}
	}
}
