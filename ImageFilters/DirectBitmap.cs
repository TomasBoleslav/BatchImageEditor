using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ThrowHelpers;

namespace ImageFilters
{
    public sealed class DirectBitmap : IDisposable
    {
        // TODO: properties Stride, BytesInRow?

        public Bitmap Bitmap { get; }

        public byte[] Buffer { get; }

        public int Width { get { return Bitmap.Width; } }

        public int Height { get { return Bitmap.Height; } }

        public PixelFormat PixelFormat { get { return Bitmap.PixelFormat; } }

        public bool IsDisposed { get; private set; }

        public DirectBitmap(int width, int height, PixelFormat pixelFormat)
        {
            ArgChecker.Positive(width, nameof(width));
            ArgChecker.Positive(height, nameof(height));
			if (!SupportedFormats.Contains(pixelFormat))
			{
                throw new ArgumentException("The given pixel format is not supported.");
			}
            _bytesPerPixel = ComputeBytesPerPixel(pixelFormat);
            _usedBytesInRow = width * _bytesPerPixel;
            _stride = _usedBytesInRow + ComputePadding(_usedBytesInRow);
            Buffer = new byte[height * _stride];
            _bufferHandle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
            _pixelExtractor = CreatePixelExtractor(Buffer, pixelFormat);
            Bitmap = new Bitmap(width, height, _stride, pixelFormat, _bufferHandle.AddrOfPinnedObject());
        }
        
        public static DirectBitmap FromBitmap(Bitmap bitmap)
        {
            ArgChecker.NotNull(bitmap, nameof(bitmap));
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
            ArgChecker.NotNull(filename, nameof(filename));
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

        public void FlipVertically()
		{
            // Does not work !!! it will also reverse color channels
			for (int rowIndex = 0; rowIndex < Height; rowIndex++)
			{
                int rowStart = rowIndex * _stride;
                Array.Reverse(Buffer, rowStart, _usedBytesInRow);
			}
        }

        public void FlipHorizontally()
        {
            byte[] rowTemporary = new byte[_usedBytesInRow];
            int row1Index = 0;
            int row2Index = Height - 1;
			while (row1Index < row2Index)
			{
                int row1Start = row1Index * _stride;
                int row2Start = row2Index * _stride;
                System.Buffer.BlockCopy(Buffer, row1Start, rowTemporary, 0, _usedBytesInRow);       // temp <- row1
                System.Buffer.BlockCopy(Buffer, row2Start, Buffer, row1Start, _usedBytesInRow);     // row1 <- row2
                System.Buffer.BlockCopy(rowTemporary, 0, Buffer, row2Start, _usedBytesInRow);       // row2 <- temp
                row1Index++;
                row2Index--;
			}
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
        private readonly int _usedBytesInRow;
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

        private static int ComputePadding(int usedBytesInRow)
		{
            int remainder = usedBytesInRow % 4;
            if (remainder == 0)
            {
                return 0;
            }
            return 4 - remainder;
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
