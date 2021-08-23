using BenchmarkDotNet.Attributes;
using System.Drawing.Imaging;
using System.Drawing;

namespace ImageFilters.Benchmarks
{
	/// <summary>
	/// A benchmark comparing <see cref="DirectBitmap"/> with direct access to pixels and
	/// <see cref="Bitmap"/> that uses locking and accessing data with pointers.
	/// </summary>
	[HtmlExporter]
	public class DirectBitmapVsLockedBitmap
	{
		private const PixelFormat CommonPixelFormat = PixelFormat.Format32bppPArgb;

		[Params(100, 1000, 3000)]
		public int ImageSize { get; set; }

		[GlobalSetup]
		public void GlobalSetup()
		{
			_directBitmap = new DirectBitmap(ImageSize, ImageSize);
			_bitmap = new Bitmap(ImageSize, ImageSize, CommonPixelFormat);
		}

		[GlobalCleanup]
		public void GlobalCleanup()
		{
			_directBitmap.Dispose();
			_bitmap.Dispose();
		}

		[Benchmark]
		public void DirectBitmap_GetPixel()
		{
			for (int i = 0; i < ImageSize; i++)
			{
				for (int j = 0; j < ImageSize; j++)
				{
					_color = _directBitmap.GetPixel(i, j);
				}
			}
		}

		[Benchmark]
		public unsafe void LockedBitmap_GetPixel()
		{
			BitmapData data = _bitmap.LockBits(new Rectangle(0, 0, ImageSize, ImageSize), ImageLockMode.ReadOnly, CommonPixelFormat);
			int pixelByteCount = Image.GetPixelFormatSize(CommonPixelFormat) / 8;
			byte* startPtr = (byte*)data.Scan0;
			for (int i = 0; i < ImageSize; i++)
			{
				for (int j = 0; j < ImageSize; j++)
				{
					byte* pixelPtr = startPtr + i * data.Stride + j * pixelByteCount;
					_color = Color.FromArgb(
						pixelPtr[3],
						pixelPtr[2],
						pixelPtr[1],
						pixelPtr[0]
						);
				}
			}
			_bitmap.UnlockBits(data);
		}

		[Benchmark]
		public void DirectBitmap_SetPixel()
		{
			for (int i = 0; i < ImageSize; i++)
			{
				for (int j = 0; j < ImageSize; j++)
				{
					_directBitmap.SetPixel(i, j, _color);
				}
			}
		}

		[Benchmark]
		public unsafe void LockedBitmap_SetPixel()
		{
			BitmapData data = _bitmap.LockBits(new Rectangle(0, 0, ImageSize, ImageSize), ImageLockMode.WriteOnly, CommonPixelFormat);
			int pixelByteCount = Image.GetPixelFormatSize(CommonPixelFormat) / 8;
			byte* startPtr = (byte*)data.Scan0;
			for (int i = 0; i < ImageSize; i++)
			{
				for (int j = 0; j < ImageSize; j++)
				{
					byte* pixelPtr = startPtr + i * data.Stride + j * pixelByteCount;
					pixelPtr[3] = _color.A;
					pixelPtr[2] = _color.R;
					pixelPtr[1] = _color.G;
					pixelPtr[0] = _color.B;
				}
			}
			_bitmap.UnlockBits(data);
		}

		private Color _color = Color.Red;
		private DirectBitmap _directBitmap;
		private Bitmap _bitmap;
	}
}
