using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BatchImageEditor
{
	// TODO: instead of returning exact enum type, return int instead and let the caller cast it to the correct type
	public partial class EnumComboBox<TEnum> : UserControl
	{
		public EnumComboBox()
		{
			InitializeComponent();
		}

		public event EventHandler SelectedValueChanged;

		public int SelectedValue { get; set; }

		public void SetValues<T>(IEnumerable<KeyValuePair<string, T>> namesToEnumValues) where T : Enum
		{
			_comboBox.BeginUpdate();
			_comboBox.Items.Clear();
			namesToIntValues = new Dictionary<string, int>();
			var values = Enum.GetValues(typeof(T));
			foreach ((string name, T enumValue) in namesToEnumValues)
			{
				if (!namesToIntValues.ContainsKey(name))
				{
					//namesToIntValues.Add(name, (int)enumValue);
					//item.Key
				}
			}
			// TODO: how to cast it back?
			_comboBox.EndUpdate();
		}

		Dictionary<string, int> namesToIntValues;
	}
}
