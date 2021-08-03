using System;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class SwitchablePreviewImageControl : UserControl
	{
		public SwitchablePreviewImageControl()
		{
			InitializeComponent();
			_isPreviewShown = true;
			UpdatePreviewSwitchButton(_isPreviewShown);
		}

		public DirectBitmap PreviewImage
		{
			get
			{
				return _previewImage;
			}
			set
			{
				if (_isPreviewShown)
				{
					_previewImageControl.Image = value;
				}
				_previewImage = value;
			}
		}

		public DirectBitmap OriginalImage
		{
			get
			{
				return _originalImage;
			}
			set
			{
				if (!_isPreviewShown)
				{
					_previewImageControl.Image = value;
				}
				_originalImage = value;
			}
		}

		public void DisposeOriginalImage()
		{
			DirectBitmap oldImage = OriginalImage;
			OriginalImage = null;
			oldImage?.Dispose();
		}

		public void DisposePreviewImage()
		{
			DirectBitmap oldImage = PreviewImage;
			PreviewImage = null;
			oldImage?.Dispose();
		}

		private bool _isPreviewShown;
		private DirectBitmap _previewImage;
		private DirectBitmap _originalImage;

		private void PreviewSwitchButton_Click(object sender, EventArgs e)
		{
			_isPreviewShown = !_isPreviewShown;
			UpdatePreviewSwitchButton(_isPreviewShown);
			UpdateDisplayedImage(_isPreviewShown);
		}

		private void UpdatePreviewSwitchButton(bool isPreviewShown)
		{
			if (isPreviewShown)
			{
				_previewSwitchButton.Text = "Show original";
			}
			else
			{
				_previewSwitchButton.Text = "Show preview";
			}
		}

		private void UpdateDisplayedImage(bool isPreviewShown)
		{
			if (isPreviewShown)
			{
				_previewImageControl.Image = PreviewImage;
			}
			else
			{
				_previewImageControl.Image = OriginalImage;
			}
		}
	}
}
