using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFilters;

namespace BatchImageEditor
{
	public sealed class FlipFilterSettingsModel : IFilterSettingsModel<FlipFilterSettingsModel>
	{
		public const FlipType DefaultFlipType = FlipType.Horizontal;

		public FlipFilterSettingsModel()
		{
			FlipType = DefaultFlipType;
		}

		public FlipType FlipType { get; set; }

		public FlipFilterSettingsModel Copy()
		{
			return new FlipFilterSettingsModel
			{
				FlipType = FlipType
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new FlipFilter(FlipType);
		}
	}
}
