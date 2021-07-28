using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageFilters
{
    public sealed class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; }

        public byte[] Buffer { get; }

        public int Width { get { return Bitmap.Width; } }

        public int Height { get { return Bitmap.Height; } }

        public PixelFormat PixelFormat { get { return Bitmap.PixelFormat; } }

        public bool IsDisposed { get; private set; }

        public DirectBitmap(int width, int height, PixelFormat pixelFormat)
        {
			if (width <= 0 || height <= 0)
			{
                throw new ArgumentException("Width and height must be positive integers.");
			}
			if (!SupportedFormats.Contains(pixelFormat))
			{
                throw new ArgumentException("The given pixel format is not supported.");
			}
            _bytesPerPixel = ComputeBytesPerPixel(pixelFormat);
            _stride = ComputeStride(width, _bytesPerPixel);
            Buffer = new byte[height * _stride];
            _bufferHandle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
            _pixelExtractor = CreatePixelExtractor(Buffer, pixelFormat);
            Bitmap = new Bitmap(width, height, _stride, pixelFormat, _bufferHandle.AddrOfPinnedObject());
        }
        
        public static DirectBitmap FromBitmap(Bitmap bitmap)
        {
            ThrowHelper.ThrowIfNull(bitmap, nameof(bitmap));
			if (SupportedFormats.Contains(bitmap.PixelFormat))
			{
                return FromBitmapByCopyingData(bitmap);
            }
            return FromBitmapByReformatting(bitmap, DefaultPixelFormat);
        }

        // Exceptions:
        // IOException
        public static DirectBitmap FromFile(string filename)
        {
            ThrowHelper.ThrowIfNull(filename, nameof(filename));
            Bitmap loadedBitmap;
            DirectBitmap directBitmap;
            try
            {
                loadedBitmap = new Bitmap(filename);
            }
            // When file does not exist the constructor should throw a FileNotFoundException according
            // to the documentation, but in reality throws an ArgumentException instead.
            // Solution: catch any of these exceptions and wrap it in an IOException.
            catch (Exception e) when (e is FileNotFoundException || e is ArgumentException)
            {
                throw new IOException($"The file {filename} does not exist or is not a valid image.", e);
            }
            directBitmap = FromBitmap(loadedBitmap);
            loadedBitmap.Dispose();
            return directBitmap;
        }

        public DirectBitmap Copy()
        {
            var directBitmap = new DirectBitmap(Width, Height, Bitmap.PixelFormat);
            Buffer.CopyTo(directBitmap.Buffer, 0);
            return directBitmap;
        }

        // IndexOutOfRangeException - but only for some values
        public Color GetPixel(int x, int y)
        {
            int index = x * _bytesPerPixel + y * _stride;
            return _pixelExtractor.GetPixel(index);
        }

        // IndexOutOfRangeException - but only for some values
        public void SetPixel(int x, int y, Color color)
        {
            int index = x * _bytesPerPixel + y * _stride;
            _pixelExtractor.SetPixel(index, color);
        }

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            IsDisposed = true;
            Bitmap.Dispose();
            _bufferHandle.Free();
            GC.SuppressFinalize(this);
        }

        private const PixelFormat DefaultPixelFormat = PixelFormat.Format32bppArgb;
        private static readonly IReadOnlySet<PixelFormat> SupportedFormats =
            new HashSet<PixelFormat>(
                new[]
                {
                    PixelFormat.Format24bppRgb,
                    PixelFormat.Format32bppRgb,
                    PixelFormat.Format32bppArgb
                }
            );

        private readonly int _bytesPerPixel;
        private readonly int _stride;
        private readonly GCHandle _bufferHandle;
        private readonly IPixelExtractor _pixelExtractor;

        private static IPixelExtractor CreatePixelExtractor(byte[] buffer, PixelFormat pixelFormat)
		{
			return pixelFormat switch
			{
				PixelFormat.Format24bppRgb or PixelFormat.Format32bppRgb => new PixelExtractor24Rgb(buffer),
				PixelFormat.Format32bppArgb => new PixelExtractor32Argb(buffer),
				_ => throw new ArgumentException("The given format is not supported."),
			};
		}

        private static int ComputeBytesPerPixel(PixelFormat pixelFormat)
		{
            return Image.GetPixelFormatSize(pixelFormat) / 8;
        }

        private static int ComputeStride(int width, int bytesPerPixel)
		{
            int usedBytesInRow = width * bytesPerPixel;
            // Ensure that the stride is a multiple of four
            int remainder = usedBytesInRow % 4;
			if (remainder == 0)
			{
                return usedBytesInRow;
			}
            int padding = 4 - remainder;
            return usedBytesInRow + padding;
		}

        private static DirectBitmap FromBitmapByCopyingData(Bitmap bitmap)
        {
            var directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                bitmap.PixelFormat
                );
            IntPtr dataPointer = data.Scan0;
            Marshal.Copy(dataPointer, directBitmap.Buffer, 0, directBitmap.Buffer.Length);
            bitmap.UnlockBits(data);
            return directBitmap;
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
