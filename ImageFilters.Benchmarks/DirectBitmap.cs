using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ThrowHelpers;

namespace ImageFilters.Benchmarks
{
    public sealed class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; }

        public int[] Buffer { get; }

        public int Width { get; }

        public int Height { get; }

        public bool IsDisposed { get; private set; }

        public DirectBitmap(int width, int height)
        {
            ArgChecker.Positive(width, nameof(width));
            ArgChecker.Positive(height, nameof(height));
            Width = width;
            Height = height;
            Buffer = new int[width * height];
            int strideInBytes = width * 4; // Does not have to be correct for other pixel formats
            _bufferHandle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, strideInBytes, DefaultPixelFormat, _bufferHandle.AddrOfPinnedObject());
        }

        public static DirectBitmap FromBitmap(Bitmap bitmap)
        {
            ArgChecker.NotNull(bitmap, nameof(bitmap));
            var directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);
            using (Graphics graphics = Graphics.FromImage(directBitmap.Bitmap))
            {
                graphics.DrawImage(bitmap, 0, 0);
            }
            return directBitmap;
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
            var directBitmap = new DirectBitmap(Width, Height);
            Buffer.CopyTo(directBitmap.Buffer, 0);
            return directBitmap;
        }

        // Document IndexOutOfRangeException - but only for some values x and y
        public Color GetPixel(int x, int y)
        {
            int index = x + y * Width;
            int colorInt = Buffer[index];
            return Color.FromArgb(colorInt);
        }

        // Document IndexOutOfRangeException - but only for some values x and y
        public void SetPixel(int x, int y, Color color)
        {
            int index = x + y * Width;
            int colorInt = color.ToArgb();
            Buffer[index] = colorInt;
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
        private readonly GCHandle _bufferHandle;
    }
}
