using System;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// A control that shows an image.
	/// </summary>
	internal sealed partial class PreviewImageControl : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="PreviewImageControl"/>.
		/// </summary>
		public PreviewImageControl()
		{
			InitializeComponent();
			_pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
			SetSizeLabel(0, 0);
		}

		/// <summary>
		/// Gets and sets the image to show.
		/// </summary>
		public DirectBitmap Image
		{
			get
			{
				return _image;
			}
			set
			{
				if (value != null)
				{
					_pictureBox.Image = value.Bitmap;
					SetSizeLabel(value.Width, value.Height);
				}
				else
				{
					_pictureBox.Image = null;
					SetSizeLabel(0, 0);
				}
				_image = value;
			}
		}

		private DirectBitmap _image;

		/// <summary>
		/// Sets the text of the image size label.
		/// </summary>
		/// <param name="width">Image width.</param>
		/// <param name="height">Image height.</param>
		private void SetSizeLabel(int width, int height)
		{
			_sizeLabel.Text = $"{width} x {height} px";
		}

		/// <summary>
		/// Makes the image fit the picture box.
		/// </summary>
		private void FitButton_Click(object sender, EventArgs e)
		{
			_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
		}

		/// <summary>
		/// Makes the image to be shown in the center of the picture box with its original size.
		/// </summary>
		private void CenterButton_Click(object sender, EventArgs e)
		{
			_pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
		}
	}
}
