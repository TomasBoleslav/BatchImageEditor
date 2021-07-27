using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageFilters
{
	public class FileBitmapReaderWriter : IReaderWriter<DirectBitmap>
	{
		public FileActionSuccessCallback SuccessCallback { get; set; }

		public FileActionFailCallback FailCallback { get; set; }

		public FileBitmapReaderWriter(string inputFilename, string outputFilename)
		{
			this.inputFilename = inputFilename;
			this.outputFilename = outputFilename;
		}

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

		public void Write(DirectBitmap directBitmap)
		{
			try
			{
				directBitmap.Bitmap.Save(outputFilename);
			}
			catch (ExternalException)
			{
				FailCallback?.Invoke(outputFilename,
					"The image was saved with a wrong image format or it cannot be saved to the given file.");
				return;
			}
			SuccessCallback?.Invoke(outputFilename);
		}

		private readonly string inputFilename;
		private readonly string outputFilename;
	}
}
