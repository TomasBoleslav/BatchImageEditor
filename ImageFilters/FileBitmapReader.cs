using System;
using System.Drawing;

namespace ImageFilters
{
	public class FileBitmapReader : IReader<Bitmap>
	{
		public Action<string> SuccessCallback { get; set; }

		public Action<string, string> FailCallback { get; set; }

		public FileBitmapReader(string filename)
		{
			this.filename = filename;
			throw new NotImplementedException();
		}

		public Bitmap Read()
		{
			throw new NotImplementedException();
		}

		private string filename;
	}
}
