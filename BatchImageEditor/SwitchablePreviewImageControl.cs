using System;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// A control for showing an original or a preview image and allows the user to switch between them.
	/// </summary>
	internal sealed partial class SwitchablePreviewImageControl : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="SwitchablePreviewImageControl"/>.
		/// </summary>
		public SwitchablePreviewImageControl()
		{
			InitializeComponent();
			_isPreviewShown = true;
			UpdatePreviewSwitchButton(_isPreviewShown);
		}

		/// <summary>
		/// Gets or sets the preview image.
		/// </summary>
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

		/// <summary>
		/// Gets or sets the original image.
		/// </summary>
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

		private bool _isPreviewShown;
		private DirectBitmap _previewImage;
		private DirectBitmap _originalImage;

		/// <summary>
		/// Switches between the original and the preview image.
		/// </summary>
		private void PreviewSwitchButton_Click(object sender, EventArgs e)
		{
			_isPreviewShown = !_isPreviewShown;
			UpdatePreviewSwitchButton(_isPreviewShown);
			UpdateDisplayedImage(_isPreviewShown);
		}

		/// <summary>
		/// Updates the text of the button that switches between the original and the preview image.
		/// </summary>
		/// <param name="isPreviewShown">True if the preview image is shown, else false.</param>
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

		/// <summary>
		/// Displays the original of the preview image.
		/// </summary>
		/// <param name="isPreviewShown">True if the preview image is shown, else false.</param>
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
