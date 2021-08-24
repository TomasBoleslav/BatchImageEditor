using ImageFilters;
using System.Collections.Generic;
using System.Drawing;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// Represents a model of rotation filter settings.
	/// </summary>
	internal sealed class RotationFilterSettingsModel : IFilterSettingsModel<RotationFilterSettingsModel>
	{
		public const float MinAngle = -360.0f;
		public const float MaxAngle = 360.0f;
		public const float DefaultAngle = 0.0f;
		public static readonly Color DefaultBackColor = Color.White;

		/// <summary>
		/// Creates an instance of <see cref="RotationFilterSettingsModel"/> with default settings.
		/// </summary>
		public RotationFilterSettingsModel()
		{
			Angle = DefaultAngle;
			BackColor = DefaultBackColor;
		}

		/// <summary>
		/// Gets or sets the rotation angle.
		/// </summary>
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

		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		public Color BackColor { get; set; }

		/// <inheritdoc/>
		public RotationFilterSettingsModel Copy()
		{
			return new RotationFilterSettingsModel()
			{
				Angle = Angle,
				BackColor = BackColor
			};
		}

		/// <inheritdoc/>
		public IEnumerable<IImageFilter> CreateFilters()
		{
			yield return new RotationFilter(Angle, BackColor);
		}

		private float _angle;
	}
}
