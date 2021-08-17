using ImageFilters;
using System.Collections.Generic;
using System.Drawing;
using ThrowHelpers;

namespace BatchImageEditor
{
	public class RotationFilterSettingsModel : IFilterSettingsModel<RotationFilterSettingsModel>
	{
		public const float MinAngle = -360.0f;
		public const float MaxAngle = 360.0f;
		public const float DefaultAngle = 0.0f;
		public static readonly Color DefaultBackColor = Color.White;

		public RotationFilterSettingsModel()
		{
			Angle = DefaultAngle;
			BackColor = DefaultBackColor;
		}

		public float Angle
		{
			get
			{
				return _angle;
			}
			set
			{
				ArgChecker.InRangeInclusive(value, nameof(value), MinAngle, MaxAngle);
				_angle = value;
			}
		}

		public Color BackColor { get; set; }

		public RotationFilterSettingsModel Copy()
		{
			return new RotationFilterSettingsModel()
			{
				Angle = Angle,
				BackColor = BackColor
			};
		}

		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new RotationFilter(Angle, BackColor);
		}

		private float _angle;
	}
}
