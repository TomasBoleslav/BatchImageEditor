using System;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class PreviewImageControl : UserControl
	{
		public PreviewImageControl()
		{
			InitializeComponent();
			_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			SetSizeLabel(0, 0);
		}

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

		private void SetSizeLabel(int width, int height)
		{
			_sizeLabel.Text = $"{width} x {height} px";
		}

		private void FitButton_Click(object sender, EventArgs e)
		{
			_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
		}

		private void CenterButton_Click(object sender, EventArgs e)
		{
			_pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
		}
	}
}
