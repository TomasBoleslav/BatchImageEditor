using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ThrowHelpers;

namespace BatchImageEditor
{
	/// <summary>
	/// A manager for a combo box that sets its values to values of an enum.
	/// </summary>
	/// <typeparam name="TEnum">An enum type whose values will be shown on a combo box.</typeparam>
	internal sealed class EnumComboBoxManager<TEnum> where TEnum : Enum
	{
		/// <summary>
		/// Creates an instance of <see cref="EnumComboBoxManager{TEnum}"/> that sets values to named of enum values.
		/// </summary>
		/// <param name="comboBox">A combo box to use.</param>
		/// <param name="enumValuesToNames">A non-empty mapping from values of the enum type to their names.</param>
		public EnumComboBoxManager(ComboBox comboBox, Dictionary<TEnum, string> enumValuesToNames)
		{
			ArgChecker.NotNull(comboBox, nameof(comboBox));
			ArgChecker.NotNull(enumValuesToNames, nameof(enumValuesToNames));
			if (enumValuesToNames.Count == 0)
			{
				throw new ArgumentException("Dictionary of enum values must not be empty.");
			}
			_comboBox = comboBox;
			_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			_comboBox.BeginUpdate();
			_comboBox.Items.Clear();
			_enumValuesToIndices = new Dictionary<TEnum, int>();
			_indicesToEnumValues = new Dictionary<int, TEnum>();
			foreach ((TEnum enumValue, string name) in enumValuesToNames)
			{
				int index = _comboBox.Items.Add(name);
				_enumValuesToIndices.Add(enumValue, index);
				_indicesToEnumValues.Add(index, enumValue);
			}
			_comboBox.EndUpdate();
			_comboBox.SelectedIndex = 0;
			_comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
		}

		/// <summary>
		/// Gets or sets the currently selected value.
		/// </summary>
		public TEnum SelectedValue
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

		/// <summary>
		/// Occurs when the selected value is changed.
		/// </summary>
		public event EventHandler SelectedValueChanged;

		private readonly ComboBox _comboBox;
		private readonly Dictionary<TEnum, int> _enumValuesToIndices;
		private readonly Dictionary<int, TEnum> _indicesToEnumValues;

		/// <summary>
		/// Checks selected index and invokes the  <see cref="SelectedValueChanged"/> event.
		/// </summary>
		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_comboBox.SelectedIndex == -1)
			{
				_comboBox.SelectedIndex = 0;
				return;
			}
			OnSelectedValueChanged();
		}

		/// <summary>
		/// Invokes the <see cref="SelectedValueChanged"/> event.
		/// </summary>
		private void OnSelectedValueChanged()
		{
			SelectedValueChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
