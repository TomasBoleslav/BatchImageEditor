using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BatchImageEditor
{
	/// <summary>
	/// A control for selecting one item from a set of filenames.
	/// </summary>
	internal partial class FileSelection : UserControl
	{
		/// <summary>
		/// Creates an instance of <see cref="FileSelection"/>.
		/// </summary>
		public FileSelection()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Occurs when the selection has changed.
		/// </summary>
		public event EventHandler SelectionChanged;

		/// <summary>
		/// Gets the currently selected filename.
		/// </summary>
		public string SelectedFilename { get; private set; }

		/// <summary>
		/// Sets a new set of filenames.
		/// </summary>
		/// <param name="newFilenames">A new set of filenames.</param>
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

		/// <summary>
		/// Updates the currently selected filename.
		/// </summary>
		private void SelectionBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string newSelectedItem = _selectionBox.SelectedItem as string;
			if (newSelectedItem != SelectedFilename)
			{
				SelectedFilename = _selectionBox.SelectedItem as string;
				OnSelectionChange();
			}
		}

		/// <summary>
		/// Invokes the <see cref="SelectionChanged"/> event.
		/// </summary>
		private void OnSelectionChange()
		{
			SelectionChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
