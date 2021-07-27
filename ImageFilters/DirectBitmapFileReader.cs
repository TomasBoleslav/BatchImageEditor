using System;

namespace ImageFilters
{
	/*
	public class DirectBitmapFileReader : IReader<DirectBitmap>
	{
		public DirectBitmap Read()
		{
			DirectBitmap directBitmap;
			try
			{
				using var loadedBitmap = new Bitmap(inputFilename);
				directBitmap = DirectBitmap.FromBitmap(loadedBitmap);
			}
			catch (OutOfMemoryException)
			{
				FailCallback?.Invoke(inputFilename, "The file does not have a valid image format or the pixel format is not supported.");
				return null;
			}
			catch (FileNotFoundException)
			{
				FailCallback?.Invoke(inputFilename, "The file does not exist.");
				return null;
			}
			catch (ArgumentException)
			{
				FailCallback?.Invoke(inputFilename, "The name of the file is not valid.");
				return null;
			}
			return directBitmap;
		}
	}*/
}
