using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Linq;
using ImageFilters;

namespace BatchImageEditor
{
	/// <summary>
	/// A control managing a list of <see cref="IImageFilter"/> instances.
	/// </summary>
	internal sealed partial class FilterList : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="FilterList"/>.
		/// </summary>
		public FilterList()
		{
			InitializeComponent();
			_settingsFactories = CreateSettingsFactories();
			_filterMenu = CreateFilterMenu();
			_filterSettingsList = new List<FilterSettingsBase>();
		}

		/// <summary>
		/// Gets or sets an image to use as input image for filtering.
		/// </summary>
		public DirectBitmap InputImage { get; set; }

		/// <summary>
		/// Occurs when the content of the list changed.
		/// </summary>
		public event EventHandler ListChanged;

		/// <summary>
		/// Creates a collection of stored filters.
		/// </summary>
		/// <returns>A collection of stored filters.</returns>
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

		private readonly ContextMenuStrip _filterMenu;
		private readonly FilterSettingsFactoryCollection _settingsFactories;
		private readonly List<FilterSettingsBase> _filterSettingsList;

		/// <summary>
		/// Creates a collection of settings factories.
		/// </summary>
		/// <returns>A collection of settings factories.</returns>
		private static FilterSettingsFactoryCollection CreateSettingsFactories()
		{
			var settingsFactories = new FilterSettingsFactoryCollection();
			settingsFactories.Add(new Instantiator<MedianFilterSettings>());
			settingsFactories.Add(new Instantiator<ResizingFilterSettings>());
			settingsFactories.Add(new Instantiator<ImageInsertFilterSettings>());
			settingsFactories.Add(new Instantiator<FlipFilterSettings>());
			settingsFactories.Add(new Instantiator<ContrastBrightnessFilterSettings>());
			settingsFactories.Add(new Instantiator<RotationFilterSettings>());
			settingsFactories.Add(new Instantiator<ColorChannelsFilterSettings>());
			settingsFactories.Add(new Instantiator<CropFilterSettings>());
			settingsFactories.Add(new Instantiator<GaussianBlurFilterSettings>());
			settingsFactories.Add(new Instantiator<EmptyFilterSettings<HighPassSharpenFilter>>());
			return settingsFactories;
		}

		/// <summary>
		/// Creates a <see cref="ContextMenuStrip"/> to let the user choose filter settings to open.
		/// </summary>
		/// <returns>A <see cref="ContextMenuStrip"/> to let the user choose filter settings to open.</returns>
		private ContextMenuStrip CreateFilterMenu()
		{
			var menu = new ContextMenuStrip();
			menu.Items.Add(CreateTransformMenuItems());
			menu.Items.Add(CreateNoiseReductionMenuItems());
			menu.Items.Add(CreateColorAdjustmentMenuItems());
			menu.Items.Add(CreateBlurMenuItems());
			menu.Items.Add(CreateSharpenMenuItems());
			menu.Items.Add(CreateSettingsMenuItem<ImageInsertFilterSettings>());
			return menu;
		}

		/// <summary>
		/// Creates menu items for noise reduction.
		/// </summary>
		private ToolStripMenuItem CreateNoiseReductionMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Noise reduction");
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<MedianFilterSettings>());
			return rootItem;
		}

		/// <summary>
		/// Creates menu items for image transformation.
		/// </summary>
		private ToolStripMenuItem CreateTransformMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Transform");
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<ResizingFilterSettings>());
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<FlipFilterSettings>());
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<RotationFilterSettings>());
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<CropFilterSettings>());
			return rootItem;
		}

		/// <summary>
		/// Creates menu items for color adjustment.
		/// </summary>
		private ToolStripMenuItem CreateColorAdjustmentMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Adjust Colors");
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<ContrastBrightnessFilterSettings>());
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<ColorChannelsFilterSettings>());
			return rootItem;
		}

		/// <summary>
		/// Creates menu items blurring the image.
		/// </summary>
		private ToolStripMenuItem CreateBlurMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Blur");
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<GaussianBlurFilterSettings>());
			return rootItem;
		}

		/// <summary>
		/// Creates menu items for sharpening the image.
		/// </summary>
		private ToolStripMenuItem CreateSharpenMenuItems()
		{
			var rootItem = new ToolStripMenuItem("Sharpen");
			rootItem.DropDownItems.Add(CreateSettingsMenuItem<EmptyFilterSettings<HighPassSharpenFilter>>());
			return rootItem;
		}

		/// <summary>
		/// Creates a menu item for filter settings.
		/// </summary>
		/// <typeparam name="T">The type of settings.</typeparam>
		private ToolStripMenuItem CreateSettingsMenuItem<T>() where T : FilterSettingsBase
		{
			string settingsName = FilterSettingsNames.GetName(typeof(T));
			var menuItem = new ToolStripMenuItem(settingsName);
			menuItem.Click += FilterMenuItem_Click;
			return menuItem;
		}

		/// <summary>
		/// Creates a new settings control instance and opens a <see cref="FilterSettingsEditDialog"/> to edit it.
		/// </summary>
		private void FilterMenuItem_Click(object sender, EventArgs e)
		{
			string settingsName = ((ToolStripMenuItem)sender).Text;
			IFactory<FilterSettingsBase> settingsFactory = _settingsFactories.GetFactory(settingsName);
			FilterSettingsBase filterSettings = settingsFactory.CreateInstance();
			using (var settingsEditDialog = new FilterSettingsEditDialog())
			{
				settingsEditDialog.InputImage = InputImage;
				settingsEditDialog.FilterSettings = filterSettings;
				DialogResult result = settingsEditDialog.ShowDialog();
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
		}

		/// <summary>
		/// Shows a menu with filter settings to choose from.
		/// </summary>
		private void AddButton_Click(object sender, EventArgs e)
		{
			Point filterMenuRelativeLocation = new Point
			{
				X = 0,
				Y = _addButton.Height
			};
			_filterMenu.Show(_addButton, filterMenuRelativeLocation);
		}

		/// <summary>
		/// Removes the selected filter settings from the list.
		/// </summary>
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

		/// <summary>
		/// Opens a <see cref="FilterSettingsEditDialog"/> for the selected filter settings to edit it.
		/// </summary>
		private void EditButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = _filterListBox.SelectedIndex;
			if (selectedIndex == -1)
			{
				return;
			}
			FilterSettingsBase selectedSettings = _filterSettingsList[selectedIndex];
			using (var settingsEditDialog = new FilterSettingsEditDialog())
			{
				settingsEditDialog.InputImage = InputImage;
				settingsEditDialog.FilterSettings = selectedSettings;
				DialogResult result = settingsEditDialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					OnListChanged();
				}
			}
		}

		/// <summary>
		/// Invokes the <see cref="ListChanged"/> event, but only after the check state of the item changed.
		/// </summary>
		private void FilterList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			// Execute later when the check state will be changed
			BeginInvoke((MethodInvoker)(
				() => OnListChanged()
				));
		}

		/// <summary>
		/// Moves the selected filter settings up in the list.
		/// </summary>
		private void UpButton_Click(object sender, EventArgs e)
		{
			MoveSelectedSettings(-1);
		}

		/// <summary>
		/// Moves the selected filter settings down in the list.
		/// </summary>
		private void DownButton_Click(object sender, EventArgs e)
		{
			MoveSelectedSettings(1);
		}

		/// <summary>
		/// Moves the selected filter settings in the list depending of the given direction.
		/// </summary>
		/// <param name="direction">The direction and amount in which to move the selected filter settings.</param>
		private void MoveSelectedSettings(int direction)
		{
			int selectedIndex = _filterListBox.SelectedIndex;
			if (selectedIndex == -1)
			{
				return;
			}
			int targetIndex = _filterListBox.SelectedIndex + direction;
			int lastIndex = _filterListBox.Items.Count - 1;
			if (targetIndex < 0 || lastIndex < targetIndex)
			{
				return;
			}
			SwapListItems(_filterListBox.Items, selectedIndex, targetIndex);
			SwapListItems(_filterSettingsList, selectedIndex, targetIndex);
			_filterListBox.SelectedIndex = targetIndex;
			OnListChanged();
		}

		/// <summary>
		/// Swaps two items in a <see cref="IList"/>.
		/// </summary>
		/// <param name="list">A list containing the two items.</param>
		/// <param name="index1">An index of the first item.</param>
		/// <param name="index2">An index of the second item.</param>
		private static void SwapListItems(IList list, int index1, int index2)
		{
			object temp = list[index1];
			list[index1] = list[index2];
			list[index2] = temp;
		}

		/// <summary>
		/// Invokes the <see cref="ListChanged"/> event.
		/// </summary>
		private void OnListChanged()
		{
			ListChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
