using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace BatchImageEditor
{
	public partial class ImagePreview : UserControl
	{
		public ImagePreview()
		{
			InitializeComponent();
			ResetZoomLevel();
			CenterControlHorizontally(_zoomPanel);
		}
		
		public void SetNewImage(Bitmap original, Bitmap preview)
		{
			OriginalImage = original;
			_originalImageZoomed?.Dispose();
			_originalImageZoomed = null;
			PreviewImage = preview;
			_previewImageZoomed?.Dispose();
			_previewImageZoomed = null;
			ResetZoomLevel();
			UpdateDisplayedImage(zoomChanged: false);
		}

		public void UpdatePreview(Bitmap preview)
		{
			PreviewImage = preview;
			_previewImageZoomed?.Dispose();
			_previewImageZoomed = null;
			UpdateDisplayedImage(zoomChanged: false);
		}

		// TODO: maybe DirectBitmap?
		public Bitmap PreviewImage { get; private set; }

		public Bitmap OriginalImage { get; private set; }

		private static readonly int[] ZoomLevels = new int[] { 10, 25, 50, 75, 100, 125, 150, 175, 200, 300, 400, 500 };
		private int _currentZoomIndex;
		private bool _previewShown = false;
		private Bitmap _previewImageZoomed;
		private Bitmap _originalImageZoomed;

		private void PreviewSwitchButton_Click(object sender, EventArgs e)
		{
			if (_previewShown)
			{
				_previewSwitchButton.Text = "Show preview";
				_previewShown = false;
			}
			else
			{
				_previewSwitchButton.Text = "Show original";
				_previewShown = true;
			}
			UpdateDisplayedImage(zoomChanged: false);
		}

		private void ResetZoomLevel()
		{
			_currentZoomIndex = Array.FindIndex(ZoomLevels, level => level == 100);
			Debug.Assert(_currentZoomIndex >= 0, "There must be the value 100 among zoom levels.");
			UpdateZoomLabel(ZoomLevels[_currentZoomIndex]);
		}

		private void UpdateZoomLabel(int zoomValue)
		{
			_zoomLabel.Text = $"{zoomValue}%";
			CenterControlHorizontally(_zoomLabel);
		}

		private void UpdateDisplayedImage(bool zoomChanged)
		{
			if (_previewShown)
			{
				DisplayImage(PreviewImage, zoomChanged, ref _previewImageZoomed);
			}
			else
			{
				DisplayImage(OriginalImage, zoomChanged, ref _originalImageZoomed);
			}
		}

		private void DisplayImage(Bitmap image, bool zoomChanged, ref Bitmap zoomedImage)
		{
			if (image == null)
			{
				_imageBox.Image = null;
				return;
			}
			if (zoomChanged || zoomedImage == null)
			{
				zoomedImage = ZoomImage(image);
			}
			_imageBox.Image = zoomedImage;
			_sizeLabel.Text = $"{image.Width} x {image.Height} px";
		}

		private static void CenterControlHorizontally(Control control)
		{
			control.Location = new Point
			{
				X = (control.Parent.Width - control.Width) / 2,
				Y = control.Location.Y
			};
		}

		private Bitmap ZoomImage(Bitmap bitmap)
		{
			float factor = ZoomLevels[_currentZoomIndex] / 100.0f;
			return bitmap.Resize(factor);
		}

		private void ZoomInButton_Click(object sender, EventArgs e)
		{
			ChangeZoomIndex(1);
		}

		private void ZoomOutButton_Click(object sender, EventArgs e)
		{
			ChangeZoomIndex(-1);
		}

		private void ChangeZoomIndex(int indexChange)
		{
			int newIndex = _currentZoomIndex + indexChange;
			newIndex = Math.Clamp(newIndex, 0, ZoomLevels.Length - 1);
			if (newIndex == _currentZoomIndex)
			{
				return;
			}
			_currentZoomIndex = newIndex;
			UpdateZoomLabel(ZoomLevels[newIndex]);
			UpdateDisplayedImage(zoomChanged: true);
		}

		private void ImagePreview_Resize(object sender, EventArgs e)
		{
			CenterControlHorizontally(_zoomPanel);
		}
	}
}
