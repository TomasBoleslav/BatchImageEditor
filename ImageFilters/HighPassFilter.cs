
namespace ImageFilters
{
	public class HighPassFilter : LinearFilter
	{
		public HighPassFilter()
		{
			SetKernel(CreateConvolutionKernel());
		}

		private static float[][] CreateConvolutionKernel()
		{
			double[][] kernelDouble = new[]
			{
				new double[] { 0, -1, 0 },
				new double[] { -1, 5, -1 },
				new double[] { 0, -1, 0 }
			};
			return NormalizeKernel(kernelDouble);
		}
	}
}
