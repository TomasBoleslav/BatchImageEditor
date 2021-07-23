using System;
using System.Drawing;

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
			throw new NotImplementedException();

			SuccessCallback?.Invoke(filename);
		}

		private string filename;
	}
}
