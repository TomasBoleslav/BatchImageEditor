using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ThrowHelpers;

namespace ImageFilters
{
    /// <summary>
    /// A bitmap with a buffer that can be used to get and set pixels directly.
    /// </summary>
    /// <remarks>
    /// The pixel format of the bitmap is always <see cref="PixelFormat.Format32bppArgb"/>.
    /// Original source code: https://stackoverflow.com/a/34801225/13555057
    /// </remarks>
    public sealed class DirectBitmap : IDisposable
    {
        /// <summary>
        /// Gets the bitmap object built upon the data in the buffer.
        /// </summary>
        public Bitmap Bitmap { get; }

        /// <summary>
        /// Gets the buffer of the bitmap.
        /// </summary>
        public int[] Buffer { get; }

        /// <summary>
        /// Gets the width of the bitmap.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the bitmap.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Indicates whether the bitmap was disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Creates an instance of <see cref="DirectBitmap"/> with the given size.
        /// </summary>
        /// <param name="width">The width of the new bitmap.</param>
        /// <param name="height">The height of the new bitmap.</param>
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

        /// <summary>
        /// Creates an instance of <see cref="DirectBitmap"/> from a <see cref="System.Drawing.Bitmap"/>.
        /// The data is copied, not shared, and the pixel format is changed to the default format of <see cref="DirectBitmap"/>.
        /// </summary>
        /// <param name="bitmap">A bitmap.</param>
        /// <returns>An instance of <see cref="DirectBitmap"/> created from the given bitmap.</returns>
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

        /// <summary>
        /// Loads a <see cref="DirectBitmap"/> from a file.
        /// </summary>
        /// <remarks>
        /// The format of the image must be supported by <see cref="System.Drawing.Bitmap"/>.
        /// </remarks>
        /// <param name="filename">The name of a file with an image.</param>
        /// <returns></returns>
        /// <exception cref="IOException">Thrown when the image could not be loaded from the file.</exception>
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

        /// <summary>
        /// Creates an instance of <see cref="DirectBitmap"/> that is a deep copy of this instance.
        /// </summary>
        /// <returns></returns>
        public DirectBitmap Copy()
        {
            var directBitmap = new DirectBitmap(Width, Height);
            Buffer.CopyTo(directBitmap.Buffer, 0);
            return directBitmap;
        }

        /// <summary>
        /// Gets a pixel at the given location.
        /// </summary>
        /// <param name="x">The x coordinate of the pixel.</param>
        /// <param name="y">The y coordinate of the pixel.</param>
        /// <returns>A color of a pixel at the given location.</returns>
        public Color GetPixel(int x, int y)
        {
            int index = x + y * Width;
            int colorInt = Buffer[index];
            return Color.FromArgb(colorInt);
        }

        /// <summary>
        /// Sets a pixel at the given location.
        /// </summary>
        /// <param name="x">The x coordinate of the pixel.</param>
        /// <param name="y">The y coordinate of the pixel.</param>
        /// <param name="color">A new color of the pixel.</param>
        public void SetPixel(int x, int y, Color color)
        {
            int index = x + y * Width;
            int colorInt = color.ToArgb();
            Buffer[index] = colorInt;
        }

        /// <summary>
        /// Frees resources.
        /// </summary>
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
