using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;

namespace ImageFilters
{
	public delegate void FileActionSuccessCallback(string filename);
	public delegate void FileActionFailCallback(string filename, string message);

	public class FileBitmapReader : IReader<Bitmap>
	{
		public FileActionSuccessCallback SuccessCallback { get; set; }

		public FileActionFailCallback FailCallback { get; set; }

		// TODO: accept Dictionary<PixelFormat, PixelFormat> - to what format to reformat (e.g. 32Pargb into 32argb)
		public FileBitmapReader(string filename, IReadOnlySet<PixelFormat> supportedFormats, PixelFormat defaultFormat)
		{
			this.filename = filename;
			this.supportedFormats = supportedFormats;
			this.defaultFormat = defaultFormat;
		}

		public Bitmap Read()
		{
			Bitmap bitmap;
			try
			{
				using var loadedBitmap = new Bitmap(filename);
				if (supportedFormats.Contains(loadedBitmap.PixelFormat))
				{
					// Make a copy so that loaded bitmap can be disposed of and file lock can be released
					bitmap = loadedBitmap.Copy();
				}
				else
				{
					bitmap = loadedBitmap.Reformat(defaultFormat);
				}
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
		private readonly IReadOnlySet<PixelFormat> supportedFormats;
		private readonly PixelFormat defaultFormat;
	}
}
