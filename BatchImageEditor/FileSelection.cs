using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class FileSelection : UserControl
	{
		public FileSelection()
		{
			InitializeComponent();
		}

		public event EventHandler SelectionChanged;

		public string SelectedFilename { get; private set; }

		public void SetFilenames(IReadOnlySet<string> newFilenames)
		{
			IEnumerable<string> currentFilenames = _selectionBox.Items.Cast<string>();
			HashSet<string> filenamesToPreserve = currentFilenames.ToHashSet();
			filenamesToPreserve.IntersectWith(newFilenames);
			for (int i = _selectionBox.Items.Count - 1; i >= 0; i--)
			{
				string filename = (string)_selectionBox.Items[i];
				if (!filenamesToPreserve.Contains(filename))
				{
					_selectionBox.Items.RemoveAt(i);
				}
			}
			foreach (var filename in newFilenames)
			{
				if (!filenamesToPreserve.Contains(filename))
				{
					_selectionBox.Items.Add(filename);
				}
			}
		}

		private void SelectionBox_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectedFilename = _selectionBox.SelectedValue as string;
			SelectionChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
