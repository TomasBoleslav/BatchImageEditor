using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// Filter settings control for a <see cref="FlipFilter"/>.
	/// </summary>
	internal sealed partial class FlipFilterSettings : FilterSettings<FlipFilterSettingsModel>
	{
		/// <summary>
		/// Creates an instance of <see cref="FlipFilterSettings"/>.
		/// </summary>
		public FlipFilterSettings()
		{
			InitializeComponent();
			_flipTypeBoxManager = new EnumComboBoxManager<FlipType>(_flipTypeComboBox, FlipTypeToText);
			_flipTypeBoxManager.SelectedValueChanged += FlipTypeBox_SelectedValueChanged;
		}

		/// <inheritdoc/>
		protected override void UpdateDisplayedSettingsWithDisabledEvents()
		{
			_flipTypeBoxManager.SelectedValue = DisplayedModel.FlipType;
		}

		private static readonly Dictionary<FlipType, string> FlipTypeToText = new()
		{
			{ FlipType.Horizontal, "Horizontal" },
			{ FlipType.Vertical, "Vertical" },
			{ FlipType.Both, "Both" },
		};

		private readonly EnumComboBoxManager<FlipType> _flipTypeBoxManager;

		/// <summary>
		/// Updates flip type according to the input.
		/// </summary>
		private void FlipTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.FlipType = _flipTypeBoxManager.SelectedValue;
			OnDisplayedSettingsUpdated();
		}
	}
}
