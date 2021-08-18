using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	public static class ParallelHelper
	{
		public static Task<DirectBitmap> FilterImageAsync(DirectBitmap image, IEnumerable<IImageFilter> filters)
		{
			return Task.Run(() =>
				{
					DirectBitmap imageCopy = image.Copy();
					foreach (var filter in filters)
					{
						filter.Apply(ref imageCopy);
					}
					return imageCopy;
				});
		}

		public static Task<DirectBitmap> LoadImageAsync(string filename)
		{
			return Task.Run(() =>
				{
					DirectBitmap image = null;
					try
					{
						image = DirectBitmap.FromFile(filename);
					}
					catch (IOException)
					{
						return null;
					}
					return image;
				});
		}
	}
}
