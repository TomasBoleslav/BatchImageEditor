using System;
using System.Drawing;
using System.IO;

namespace ImageFilters
{
	public delegate void FileActionSuccessCallback(string filename);
	public delegate void FileActionFailCallback(string filename, string message);

	public class FileBitmapReader : IReader<Bitmap>
	{
		public FileActionSuccessCallback SuccessCallback { get; set; }

		public FileActionFailCallback FailCallback { get; set; }

		public FileBitmapReader(string filename)
		{
			this.filename = filename;
			throw new NotImplementedException();
		}

		public Bitmap Read()
		{
			Bitmap bitmap;
			try
			{
				using var loadedBitmap = new Bitmap(filename);
				// Dispose of the loaded bitmap so that the file lock is released and return a copy instead
				bitmap = loadedBitmap.Copy();
			}
			catch (OutOfMemoryException)
			{
				FailCallback?.Invoke(filename, "The file does not have a valid image format or the pixel format is not supported.");
				return null;
			}
			catch (FileNotFoundException)
			{
				FailCallback?.Invoke(filename, "The file does not exist.");
				return null;
			}
			catch (ArgumentException)
			{
				FailCallback?.Invoke(filename, "The name of the file is not valid.");
				return null;
			}
			SuccessCallback?.Invoke(filename);
			return bitmap;
		}

		private readonly string filename;
	}
}
