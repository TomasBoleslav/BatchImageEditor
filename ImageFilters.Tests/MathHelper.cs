
namespace ImageFilters.Tests
{
	/// <summary>
	/// A helper class with functions related to math.
	/// </summary>
	internal static class MathHelper
	{
		public static float[][] CreateMatrixOfOnes(int rowCount, int columnCount)
		{
			float[][] matrix = new float[rowCount][];
			for (int i = 0; i < rowCount; i++)
			{
				matrix[i] = new float[columnCount];
				for (int j = 0; j < columnCount; j++)
				{
					matrix[i][j] = 1.0f;
				}
			}
			return matrix;
		}

		public static float[] CreateVectorOfOnes(int length)
		{
			float[] vector = new float[length];
			for (int i = 0; i < length; i++)
			{
				vector[i] = 1.0f;
			}
			return vector;
		}
	}
}
