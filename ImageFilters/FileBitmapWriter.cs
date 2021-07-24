using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageFilters
{
	// TODO: set output image format
	public class FileBitmapWriter : IWriter<Bitmap>
	{
		public Action<string> SuccessCallback { get; set; }

		public Action<string, string> FailCallback { get; set; }

		public FileBitmapWriter(string filename)
		{
			this.filename = filename;
		}

		public void Write(Bitmap bitmap)
		{
			try
			{
				bitmap.Save(filename);
			}
			catch (ExternalException)
			{
				FailCallback?.Invoke(filename, "The image was saved with a wrong image format or it cannot be saved to the given file.");
				return;
			}
			SuccessCallback?.Invoke(filename);
		}

		private readonly string filename;
	}
}
