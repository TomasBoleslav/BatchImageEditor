using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ThrowHelpers;

namespace ImageFilters
{
	/// <summary>
	/// A job that loads an image, performs image processing and saves the result to a file.
	/// </summary>
	public class ImageProcessingJob : ICancelableJob
	{
		/// <summary>
		/// Creates an instance of <see cref="ImageProcessingJob"/> that will process an image with the given filters.
		/// </summary>
		/// <param name="inputFilename">The name of a file with an image.</param>
		/// <param name="outputFilename">The name of a file to store the output.</param>
		/// <param name="filters">Image filters to use for image processing.</param>
		public ImageProcessingJob(string inputFilename, string outputFilename, IEnumerable<IImageFilter> filters)
		{
			ArgChecker.NotNull(inputFilename, nameof(inputFilename));
			ArgChecker.NotNull(outputFilename, nameof(outputFilename));
			ArgChecker.NotNull(filters, nameof(filters));
			InputFilename = inputFilename;
			OutputFilename = outputFilename;
			_filters = filters;
		}

		/// <inheritdoc/>
		public Action CancelAction { get; set; }

		/// <inheritdoc/>
		public Func<bool> ShouldCancelFunc { get; set; }

		/// <inheritdoc/>
		public bool IsCanceled { get; private set; }

		/// <summary>
		/// Gets the name of the input file.
		/// </summary>
		public string InputFilename { get; }

		/// <summary>
		/// Gets the name of the output file.
		/// </summary>
		public string OutputFilename { get; }

		/// <summary>
		/// An action to call when the job ended successfully.
		/// </summary>
		public Action<ImageProcessingJob> SuccessCallback { get; set; }

		/// <summary>
		/// An action to call when the job ended with failure.
		/// </summary>
		public Action<ImageProcessingJob, string> FailCallback { get; set; }

		/// <inheritdoc/>
		public void Run()
		{
			if (!TryReadImage(out DirectBitmap image, out string errorMessage))
			{
				FailCallback?.Invoke(this, errorMessage);
				return;
			}
			if (ShouldCancel())
			{
				image.Dispose();
				OnCancel();
				return;
			}
			FilterImage(ref image);
			if (ShouldCancel())
			{
				image.Dispose();
				OnCancel();
				return;
			}
			if (!TrySaveImage(image, out errorMessage))
			{
				FailCallback?.Invoke(this, errorMessage);
				return;
			}
			image.Dispose();
			SuccessCallback?.Invoke(this);
		}

		private readonly IEnumerable<IImageFilter> _filters;
		private PixelFormat _originalPixelFormat;

		/// <summary>
		/// Tries to read an image from the input file.
		/// </summary>
		/// <param name="image">An image that was read.</param>
		/// <param name="errorMessage">An error message if an error occurred, otherwise null.</param>
		/// <returns>True if the image was read successfully, otherwise false.</returns>
		private bool TryReadImage(out DirectBitmap image, out string errorMessage)
		{
			image = null;
			errorMessage = null;
			try
			{
				using var bitmap = new Bitmap(InputFilename);
				_originalPixelFormat = bitmap.PixelFormat;
				image = DirectBitmap.FromBitmap(bitmap);
				return true;
			}
			catch (Exception e) when (e is FileNotFoundException || e is ArgumentException)
			{
				errorMessage = $"File {InputFilename} was not found or it does not contain a valid image.";
			}
			return false;
		}

		/// <summary>
		/// Applies filters to an image.
		/// </summary>
		/// <param name="image">An image the filters will be applied to.</param>
		private void FilterImage(ref DirectBitmap image)
		{
			foreach (var filter in _filters)
			{
				if (ShouldCancel())
				{
					return;
				}
				filter.Apply(ref image);
			}
		}

		/// <summary>
		/// Creates a bitmap with a new pixel format.
		/// </summary>
		/// <param name="image">An image to copy.</param>
		/// <param name="newPixelFormat">A new pixel format.</param>
		/// <returns>A bitmap with a new pixel format.</returns>
		private static Bitmap ReformatBitmap(Bitmap image, PixelFormat newPixelFormat)
		{
			var reformattedBitmap = new Bitmap(image.Width, image.Height, newPixelFormat);
			using (var graphics = Graphics.FromImage(reformattedBitmap))
			{
				graphics.DrawImage(image, 0, 0);
			}
			return reformattedBitmap;
		}

		/// <summary>
		/// Tries to save an image to the output file.
		/// </summary>
		/// <param name="image">An image to save.</param>
		/// <param name="errorMessage">An error message if an error occurred, otherwise null.</param>
		/// <returns>True if the image was read successfully, otherwise false.</returns>
		private bool TrySaveImage(DirectBitmap image, out string errorMessage)
		{
			errorMessage = null;
			Bitmap bitmapToSave;
			bool disposeRequired;
			if (_originalPixelFormat == image.Bitmap.PixelFormat)
			{
				bitmapToSave = image.Bitmap;
				disposeRequired = false;
			}
			else
			{
				bitmapToSave = ReformatBitmap(image.Bitmap, _originalPixelFormat);
				disposeRequired = true;
			}
			try
			{
				bitmapToSave.Save(OutputFilename);
				return true;
			}
			catch (Exception e) when (e is ExternalException || e is IOException) 
			{
				errorMessage = $"Image could not be saved to {OutputFilename}.";
			}
			finally
			{
				if (disposeRequired)
				{
					bitmapToSave.Dispose();
				}
			}
			return false;
		}

		/// <summary>
		/// Checks if the job should be canceled.
		/// </summary>
		/// <returns>True if the job should be canceled, otherwise false.</returns>
		private bool ShouldCancel()
		{
			return ShouldCancelFunc != null && ShouldCancelFunc.Invoke();
		}

		/// <summary>
		/// Invokes the cancel action.
		/// </summary>
		private void OnCancel()
		{
			IsCanceled = true;
			CancelAction?.Invoke();
		}
	}
}
