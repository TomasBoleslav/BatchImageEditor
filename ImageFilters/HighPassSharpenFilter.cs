
namespace ImageFilters
{
	/// <summary>
	/// A linear image filter that performs sharpening with a convolution matrix.
	/// </summary>
	public class HighPassSharpenFilter : LinearFilter
	{
		public HighPassSharpenFilter()
		{
			SetKernel(CreateConvolutionKernel());
		}

		/// <summary>
		/// Creates a convolution kernel matrix for the high pass sharpening.
		/// </summary>
		/// <returns></returns>
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
