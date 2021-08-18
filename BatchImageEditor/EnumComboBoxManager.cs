using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThrowHelpers;

namespace BatchImageEditor
{
	internal class EnumComboBoxManager<T> where T : Enum
	{
		public EnumComboBoxManager(ComboBox comboBox, Dictionary<T, string> enumValuesToNames)
		{
			ArgChecker.NotNull(comboBox, nameof(comboBox));
			ArgChecker.NotNull(enumValuesToNames, nameof(enumValuesToNames));
			if (enumValuesToNames.Count == 0)
			{
				throw new ArgumentException("Dictionary of enum values must not be empty.");
			}
			_comboBox = comboBox;
			_comboBox.BeginUpdate();
			_comboBox.Items.Clear();
			_enumValuesToIndices = new Dictionary<T, int>();
			_indicesToEnumValues = new Dictionary<int, T>();
			foreach ((T enumValue, string name) in enumValuesToNames)
			{
				int index = _comboBox.Items.Add(name);
				_enumValuesToIndices.Add(enumValue, index);
				_indicesToEnumValues.Add(index, enumValue);
			}
			_comboBox.EndUpdate();
			_comboBox.SelectedIndex = 0;
			_comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
		}

		public T SelectedValue
		{
			get
			{
				int selectedIndex = _comboBox.SelectedIndex;
				return _indicesToEnumValues[selectedIndex];
			}
			set
			{
				if (!_enumValuesToIndices.TryGetValue(value, out int index))
				{
					throw new ArgumentException("The given enum value is not among the stored values.", nameof(value));
				}
				_comboBox.SelectedIndex = index;
			}
		}

		public event EventHandler SelectedValueChanged;

		private readonly ComboBox _comboBox;
		private readonly Dictionary<T, int> _enumValuesToIndices;
		private readonly Dictionary<int, T> _indicesToEnumValues;

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_comboBox.SelectedIndex == -1)
			{
				_comboBox.SelectedIndex = 0;// TODO: check if this function is called again because of index change, otherwise do not return
				return;
			}
			OnSelectedValueChanged();
		}

		private void OnSelectedValueChanged()
		{
			SelectedValueChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
