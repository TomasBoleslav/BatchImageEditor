using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class FilterList : UserControl
	{
		public FilterList()
		{
			InitializeComponent();
			_filterEditForm = new FilterEditForm();
		}

		private FilterEditForm _filterEditForm;
		private ContextMenuStrip _filterMenu;
		private Dictionary<ToolStripMenuItem, IFilterSettings> _menuItemToSettings; // TODO: how can i create IFiltersettings this way? I need a FACTORY!!!
		// That factory will contain a static instance of UserControl and pass it to IFilterSettings in constructor -> IFilterSettings will be "presenter", not UserControl
		private void AddButton_Click(object sender, EventArgs e)
		{
			ContextMenuStrip = 
		}

		private ContextMenuStrip CreateFilterMenu()
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			ToolStripMenuItem item = new ToolStripMenuItem("Noise reduction");
			item.DropDownItems.Add("Median");

			_filterMenu.Items.Add(,);
		}
	}
}
