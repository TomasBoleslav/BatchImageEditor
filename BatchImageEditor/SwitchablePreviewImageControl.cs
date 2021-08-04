using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
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

		// TODO: remove
		public void DisposeOriginalImage()
		{
			DirectBitmap oldImage = OriginalImage;
			OriginalImage = null;
			oldImage?.Dispose();
		}

		// TODO: remove
		public void DisposePreviewImage()
		{
			DirectBitmap oldImage = PreviewImage;
			PreviewImage = null;
			oldImage?.Dispose();
		}

		// NOTE: disposing of old preview image should be done in acquireImageFunc
		public void UpdatePreviewAsync(Func<DirectBitmap> acquireImageFunc)
		{
			if (_currentUpdateTask.IsCompleted)
			{
				RunUpdatePreviewAsync(acquireImageFunc);
			}
			else
			{
				_acquireImageFunc = acquireImageFunc;
			}
		}

		private void RunUpdatePreviewAsync(Func<DirectBitmap> acquireImageFunc)
		{
			_currentUpdateTask = Task.Run(() =>
			{
				DirectBitmap previewImage = acquireImageFunc();
				BeginInvoke((MethodInvoker)(
					() =>
					{
						PreviewImage = previewImage;
						if (_acquireImageFunc != null)
						{
							Func<DirectBitmap> nextAcquireImageFunc = _acquireImageFunc;
							_acquireImageFunc = null;
							RunUpdatePreviewAsync(_acquireImageFunc);
						}
					}));
			});
		}

		private bool _isPreviewShown;
		private DirectBitmap _previewImage;
		private DirectBitmap _originalImage;
		private Task _currentUpdateTask;
		private Func<DirectBitmap> _acquireImageFunc;

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
