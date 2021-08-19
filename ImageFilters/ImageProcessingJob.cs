using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ThrowHelpers;

namespace ImageFilters
{
	public class ImageProcessingJob : ICancellableJob
	{
		public ImageProcessingJob(string inputFilename, string outputFilename, IEnumerable<IImageFilter> filters)
		{
			ArgChecker.NotNull(inputFilename, nameof(inputFilename));
			ArgChecker.NotNull(outputFilename, nameof(outputFilename));
			ArgChecker.NotNull(filters, nameof(filters));
			InputFilename = inputFilename;
			OutputFilename = outputFilename;
			_filters = filters;
		}

		public Action CancelAction { get; set; }

		public Func<bool> ShouldCancelFunc { get; set; }

		public bool IsCancelled { get; private set; }

		public string InputFilename { get; }

		public string OutputFilename { get; }

		public Action<ImageProcessingJob> SuccessCallback { get; set; }

		public Action<ImageProcessingJob, string> FailCallback { get; set; }

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
			catch (FileNotFoundException)
			{
				errorMessage = $"File {InputFilename} was not found.";
			}
			catch (ArgumentException)
			{
				errorMessage = $"File name {InputFilename} is not valid.";
			}
			return false;
		}

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

		private static Bitmap ReformatBitmap(Bitmap image, PixelFormat newPixelFormat)
		{
			var reformattedBitmap = new Bitmap(image.Width, image.Height, newPixelFormat);
			using (var graphics = Graphics.FromImage(reformattedBitmap))
			{
				graphics.DrawImage(image, 0, 0);
			}
			return reformattedBitmap;
		}

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

		private bool ShouldCancel()
		{
			return ShouldCancelFunc != null && ShouldCancelFunc.Invoke();
		}

		private void OnCancel()
		{
			IsCancelled = true;
			CancelAction?.Invoke();
		}
	}
}
