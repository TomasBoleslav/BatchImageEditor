using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageFilters
{
	public unsafe sealed class LockedBitmap : IDisposable
	{
		public LockedBitmap(Bitmap bitmap, ImageLockMode lockMode)
			: this(bitmap, lockMode, new Rectangle(Point.Empty, bitmap.Size))
		{
		}

		public LockedBitmap(Bitmap bitmap, ImageLockMode lockMode, Rectangle region)
		{
			PixelFormat pixelFormat = bitmap.PixelFormat;
			data = bitmap.LockBits(region, lockMode, pixelFormat);
			startPointer = (byte*)data.Scan0.ToPointer();
			bytesPerPixel = Image.GetPixelFormatSize(pixelFormat) / 8;
			colorExtractor = ChooseExtractorByPixelFormat(pixelFormat);
		}

		public Color GetPixel(int row, int column)
		{
			byte* pixelPointer = GetPixelPointer(row, column);
			return colorExtractor.GetColor(pixelPointer);
		}

		public void SetPixel(int row, int column, Color color)
		{
			byte* pixelPointer = GetPixelPointer(row, column);
			colorExtractor.SetColor(pixelPointer, color);
		}

		public void Dispose()
		{
			bitmap.UnlockBits(data);
		}

		private byte* GetPixelPointer(int row, int column)
		{
			return startPointer + row * data.Stride + column * bytesPerPixel;
		}

		private static IPixelColorExtractor ChooseExtractorByPixelFormat(PixelFormat pixelFormat)
		{
			switch (pixelFormat)
			{
				case PixelFormat.Format24bppRgb:
					break;
				case PixelFormat.Format32bppRgb:
					break;
				case PixelFormat.Format32bppArgb:
					return new PixelColorExtractorArgb32();
				case PixelFormat.Format32bppPArgb:
					break;


				case PixelFormat.Format48bppRgb:
					break;
				case PixelFormat.Format64bppPArgb:
					break;
				case PixelFormat.Format64bppArgb:
					break;
			}
			throw new FormatException("Pixel format of the image is not supported.");
		}

		private readonly Bitmap bitmap;
		private readonly BitmapData data;
		private readonly byte* startPointer;
		private readonly int bytesPerPixel;
		private readonly IPixelColorExtractor colorExtractor;
	}
}
