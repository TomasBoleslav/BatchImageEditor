using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Linq;
using ImageFilters;

namespace BatchImageEditor
{
	public partial class FilterList : UserControl
	{
		public FilterList()
		{
			InitializeComponent();
			_filterEditForm = new FilterEditForm();
			_settingsFactories = CreateSettingsFactories();
			_filterMenu = CreateFilterMenu();
			_filterSettingsList = new List<FilterSettingsBase>();
		}

		public DirectBitmap InputImage
		{
			get
			{
				return _filterEditForm.InputImage;
			}
			set
			{
				_filterEditForm.InputImage = value;
			}
		}

		public event EventHandler ListChanged;

		public IEnumerable<IImageFilter> CreateFilters()
		{
			var filters = new List<IImageFilter>();
			IEnumerable<int> checkedIndices = _filterListBox.CheckedIndices.Cast<int>();
			foreach (int index in checkedIndices)
			{
				FilterSettingsBase checkedFilterSettings = _filterSettingsList[index];
				filters.AddRange(checkedFilterSettings.CreateFiltersFromSavedSettings());
			}
			return filters;
		}

		protected virtual void OnListChanged()
		{
			ListChanged?.Invoke(this, EventArgs.Empty);
		}

		private readonly FilterEditForm _filterEditForm;
		private readonly ContextMenuStrip _filterMenu;
		private readonly FilterSettingsFactoryStorage _settingsFactories;
		private readonly List<FilterSettingsBase> _filterSettingsList;
		
		private static FilterSettingsFactoryStorage CreateSettingsFactories()
		{
			var settingsFactories = new FilterSettingsFactoryStorage();
			settingsFactories.Add(new Instantiator<MedianFilterSettings>());
			return settingsFactories;
		}

		private ContextMenuStrip CreateFilterMenu()
		{
			var menu = new ContextMenuStrip();
			menu.Items.Add(CreateNoiseReductionMenuItems());
			return menu;
		}

		private ToolStripMenuItem CreateNoiseReductionMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Noise reduction");
			rootItem.DropDownItems.Add(CreateMenuItemForSettings<MedianFilterSettings>());
			return rootItem;
		}

		private ToolStripMenuItem CreateMenuItemForSettings<T>() where T : FilterSettingsBase
		{
			string settingsName = FilterSettingsNames.GetName(typeof(T));
			var menuItem = new ToolStripMenuItem(settingsName);
			menuItem.Click += FilterMenuItem_Click;
			return menuItem;
		}

		private void FilterMenuItem_Click(object sender, EventArgs e)
		{
			string settingsName = ((ToolStripMenuItem)sender).Text;
			IFactory<FilterSettingsBase> settingsFactory = _settingsFactories.GetFactory(settingsName);
			FilterSettingsBase filterSettings = settingsFactory.CreateInstance();
			DialogResult result = _filterEditForm.OpenModally(filterSettings);
			if (result == DialogResult.OK)
			{
				_filterListBox.Items.Add(settingsName, isChecked: true);  // triggers ItemCheck event
				_filterSettingsList.Add(filterSettings);
			}
			else
			{
				filterSettings.Dispose();
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			Point filterMenuRelativeLocation = new Point
			{
				X = 0,
				Y = _addButton.Height
			};
			_filterMenu.Show(_addButton, filterMenuRelativeLocation);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = _filterListBox.SelectedIndex;
			if (selectedIndex == -1)
			{
				return;
			}
			_filterListBox.Items.RemoveAt(selectedIndex);
			_filterSettingsList.RemoveAt(selectedIndex);
			OnListChanged();
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = _filterListBox.SelectedIndex;
			if (selectedIndex == -1)
			{
				return;
			}
			FilterSettingsBase selectedSettings = _filterSettingsList[selectedIndex];
			DialogResult result = _filterEditForm.OpenModally(selectedSettings);
			if (result == DialogResult.OK)
			{
				OnListChanged();
			}
		}

		private void FilterList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			// Execute later when the check state will be changed
			this.BeginInvoke((MethodInvoker)(
				() => OnListChanged()
				));
		}

		private void UpButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = _filterListBox.SelectedIndex;
			TrySwapSettings(selectedIndex, selectedIndex - 1);
		}

		private void DownButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = _filterListBox.SelectedIndex;
			TrySwapSettings(selectedIndex, selectedIndex + 1);
		}

		private void TrySwapSettings(int index1, int index2)
		{
			int lastIndex = _filterListBox.Items.Count - 1;
			if (index1 < 0 || lastIndex < index1 ||
				index2 < 0 || lastIndex < index2)
			{
				return;
			}
			SwapListItems(_filterListBox.Items, index1, index2);
			SwapListItems(_filterSettingsList, index1, index2);
			OnListChanged();
		}

		private static void SwapListItems(IList list, int index1, int index2)
		{
			object temp = list[index1];
			list[index1] = list[index2];
			list[index2] = temp;
		}

	}
}
