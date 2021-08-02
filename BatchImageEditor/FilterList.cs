﻿using System;
using System.Drawing;
using System.Collections.Generic;
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
			_menuItemsToSettingsFactories = new Dictionary<ToolStripItem, IFactory<FilterSettingsBase>>();
			_filterMenu = CreateFilterMenu();
		}

		public DirectBitmap InputBitmap { get; set; }

		public event EventHandler ListChanged;

		public IEnumerable<IImageFilter> CreateFilters()
		{
			var checkedSettings = _filterList.CheckedItems.Cast<FilterSettingsBase>();
			foreach (var settings in checkedSettings)
			{
				foreach (IImageFilter filter in settings.CreateFiltersFromSavedSettings())
				{
					yield return filter;
				}
			}
		}

		protected virtual void OnListChanged()
		{
			ListChanged?.Invoke(this, EventArgs.Empty);
		}

		private readonly FilterEditForm _filterEditForm;
		private readonly ContextMenuStrip _filterMenu;
		private readonly Dictionary<ToolStripItem, IFactory<FilterSettingsBase>> _menuItemsToSettingsFactories;

		private ContextMenuStrip CreateFilterMenu()
		{
			var menu = new ContextMenuStrip();
			menu.Items.Add(CreateNoiseReductionMenuItems());
			return menu;
		}

		private ToolStripMenuItem CreateNoiseReductionMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Noise reduction");
			var medianItem = new ToolStripMenuItem("Median");
			medianItem.Click += FilterMenuItem_Click;
			var medianFilterFactory = new FilterSettingsFactory<MedianFilterSettings>();
			_menuItemsToSettingsFactories.Add(medianItem, medianFilterFactory);
			return rootItem;
		}

		private void FilterMenuItem_Click(object sender, EventArgs e)
		{
			var menuItem = (ToolStripItem)sender;
			IFactory<FilterSettingsBase> factory;
			_menuItemsToSettingsFactories.TryGetValue(menuItem, out factory);
			FilterSettingsBase filterSettings = factory.CreateInstance();
			DialogResult result = _filterEditForm.OpenModally(InputBitmap, filterSettings);
			if (result == DialogResult.OK)
			{
				_filterList.Items.Add(filterSettings, isChecked: true);
				OnListChanged();
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
			if (_filterList.SelectedIndex == -1)
			{
				return;
			}
			List<int> selectedIndices = _filterList.SelectedIndices.Cast<int>().ToList();
			selectedIndices.Reverse();
			selectedIndices.ForEach(index => _filterList.Items.RemoveAt(index));
			OnListChanged();
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			if (_filterList.SelectedItem == null)
			{
				return;
			}
			var filterSettings = (FilterSettingsBase)_filterList.SelectedItem;
			DialogResult result = _filterEditForm.OpenModally(InputBitmap, filterSettings);
			if (result == DialogResult.OK)
			{
				OnListChanged();
			}
		}

		private void FilterList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)(
				() => OnListChanged()
				));
		}
	}
}
