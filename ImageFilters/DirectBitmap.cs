using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageFilters
{
    public sealed class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; }

        public int Height { get; }

        public int Width { get; }

        public bool IsDisposed { get; private set; }

        public DirectBitmap(int width, int height, PixelFormat pixelFormat)
        {
			if (width <= 0 || height <= 0)
			{
                throw new ArgumentException("Width and height must be greater than zero.");
			}
			if (!SupportedFormats.Contains(pixelFormat))
			{
                throw new ArgumentException("The given pixel format is not supported.");
			}
            Width = width;
            Height = height;
            bytesPerPixel = Image.GetPixelFormatSize(pixelFormat) / 8;
            byte[] buffer = new byte[width * height * bytesPerPixel];
            bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * bytesPerPixel, pixelFormat, bufferHandle.AddrOfPinnedObject());
            pixelExtractor = CreateExtractor(buffer, pixelFormat);
        }

        public Color GetPixel(int x, int y)
        {
            int index = (x + y * Width) * bytesPerPixel;
            return pixelExtractor.GetPixel(index);
        }
        
        public void SetPixel(int x, int y, Color color)
        {
            int index = (x + y * Width) * bytesPerPixel;
            pixelExtractor.SetPixel(index, color);
        }

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            IsDisposed = true;
            Bitmap.Dispose();
            bufferHandle.Free();
            GC.SuppressFinalize(this);
        }

        public static DirectBitmap FromBitmap(Bitmap bitmap)
        {
			if (SupportedFormats.Contains(bitmap.PixelFormat))
			{
                return FromBitmapByReformatting(bitmap, bitmap.PixelFormat);
            }
            return FromBitmapByReformatting(bitmap, DefaultFormat);
        }

        private const PixelFormat DefaultFormat = PixelFormat.Format32bppArgb;
        private static readonly IReadOnlySet<PixelFormat> SupportedFormats =
            new HashSet<PixelFormat>(
                new[]
                {
                    PixelFormat.Format24bppRgb,
                    PixelFormat.Format32bppRgb,
                    PixelFormat.Format32bppArgb
                }
            );

        private readonly int bytesPerPixel;
        private readonly GCHandle bufferHandle;
        private readonly IPixelExtractor pixelExtractor;

        private static IPixelExtractor CreateExtractor(byte[] buffer, PixelFormat pixelFormat)
		{
			return pixelFormat switch
			{
				PixelFormat.Format24bppRgb or PixelFormat.Format32bppRgb => new PixelExtractor24Rgb(buffer),
				PixelFormat.Format32bppArgb => new PixelExtractor32Argb(buffer),
				_ => throw new ArgumentException("The given format is not supported."),
			};
		}

        private static DirectBitmap FromBitmapByReformatting(Bitmap bitmap, PixelFormat pixelFormat)
		{
            var directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height, pixelFormat);
            using (Graphics graphics = Graphics.FromImage(directBitmap.Bitmap))
            {
                graphics.DrawImage(bitmap, Point.Empty);
            }
            return directBitmap;
        }
    }
}
