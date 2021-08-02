using System;
using System.Drawing;
using System.Windows.Forms;
using ImageFilters;

namespace BatchImageEditor
{
	internal partial class FilterEditForm : Form
	{
		public FilterEditForm()
		{
			InitializeComponent();
		}

		public event EventHandler Confirmed;

		public void Open(DirectBitmap inputImage, IFilterSettings filterSettings)
		{
			_inputImage = inputImage.Copy();
			_filterSettings = filterSettings;
			// TODO: problem here, cannot place settings on form, if I do not know that they are UserControl

			// do something

			this.ShowDialog();
		}

		private IFilterSettings _filterSettings;
		private DirectBitmap _inputImage;

		private void OkButton_Click(object sender, EventArgs e)
		{
			Confirmed?.Invoke(this, EventArgs.Empty);
		}
	}
}
