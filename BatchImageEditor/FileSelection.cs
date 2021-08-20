using System;
using System.Collections.Generic;
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
			_selectionBox.BeginUpdate();
			_selectionBox.Items.Clear();
			foreach (string filename in newFilenames)
			{
				_selectionBox.Items.Add(filename);
			}
			_selectionBox.EndUpdate();
			if (newFilenames.Count > 0)
			{
				_selectionBox.SelectedIndex = 0;
			}
		}

		private void SelectionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string newSelectedItem = _selectionBox.SelectedItem as string;
			if (newSelectedItem != SelectedFilename)
			{
				SelectedFilename = _selectionBox.SelectedItem as string;
				OnSelectionChange();
			}
		}

		private void OnSelectionChange()
		{
			SelectionChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
