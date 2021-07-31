using System;
using System.Collections.Generic;
using ImageFilters;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class MedianFilterSettings : UserControl, IFilterSettings
	{
		public MedianFilterSettings()
		{
			InitializeComponent();
			_radiusInput.Minimum = MinRadius;
			_radiusInput.Maximum = MaxRadius;
			_radiusInput.Value = DefaultRadius;
		}

		public void Reset()
		{
			_radiusInput.Value = DefaultRadius;
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			// TODO: maybe radius can be hacked by user, try it
			int radius = (int)_radiusInput.Value;
			var filter = new MedianFilter(radius);
			yield return filter;
		}

		public int GetMinimumHeight()
		{
			return MinHeight;
		}

		public int GetMinimumWidth()
		{
			return MinWidth;
		}

		public override string ToString()
		{
			return "Median";
		}

		private const int MinRadius = 1;
		private const int MaxRadius = 20;
		private const int DefaultRadius = 1;
		private const int MinWidth = 190;
		private const int MinHeight = 40;
	}
}
