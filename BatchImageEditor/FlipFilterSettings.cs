using System;
using System.Collections.Generic;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class FlipFilterSettings : FilterSettings<FlipFilterSettingsModel>
	{
		public FlipFilterSettings()
		{
			InitializeComponent();
			_flipTypeBoxManager = new EnumComboBoxManager<FlipType>(_flipTypeComboBox, FlipTypeToText);
			_flipTypeBoxManager.SelectedValueChanged += FlipTypeBox_SelectedValueChanged;
		}

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

		private void FlipTypeBox_SelectedValueChanged(object sender, EventArgs e)
		{
			DisplayedModel.FlipType = _flipTypeBoxManager.SelectedValue;
			OnDisplayedSettingsUpdated();
		}
	}
}
