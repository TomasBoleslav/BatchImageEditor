using System;
using System.Drawing;
using System.Windows.Forms;

namespace BatchImageEditor
{
	/// <summary>
	/// Scene tabs control used in the editor.
	/// </summary>
	internal sealed partial class SceneTabs : UserControl
	{
		/// <summary>
		/// Occurs when the load tab was selected.
		/// </summary>
		public event EventHandler LoadTabSelected;

		/// <summary>
		/// Occurs when the edit tab was selected.
		/// </summary>
		public event EventHandler EditTabSelected;

		/// <summary>
		/// Occurs when the process tab was selected.
		/// </summary>
		public event EventHandler ProcessTabSelected;

		/// <summary>
		/// Creates an instance of <see cref="SceneTabs"/>.
		/// </summary>
		public SceneTabs()
		{
			InitializeComponent();
			_selectedTabButton = _loadTabButton;
		}

		private Button _selectedTabButton;

		/// <summary>
		/// Centers tab buttons upon control load.
		/// </summary>
		private void SceneTabs_Load(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		/// <summary>
		/// Centers tab buttons upon control resize.
		/// </summary>
		private void SceneTabs_Resize(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		/// <summary>
		/// Centers menu buttons.
		/// </summary>
		private void CenterMenuButtons()
		{
			tabsPanel.Location = new Point
			{
				X = (this.Width - tabsPanel.Width) / 2,
				Y = tabsPanel.Location.Y
			};
		}

		/// <summary>
		/// Selects the load tab button.
		/// </summary>
		private void LoadTabButton_Click(object sender, EventArgs e)
		{
			SelectTabButton(_loadTabButton, LoadTabSelected);
		}

		/// <summary>
		/// Selects the edit tab button.
		/// </summary>
		private void EditTabButton_Click(object sender, EventArgs e)
		{
			SelectTabButton(_editTabButton, EditTabSelected);
		}

		/// <summary>
		/// Selects the process tab button.
		/// </summary>
		private void ProcessTabButton_Click(object sender, EventArgs e)
		{
			SelectTabButton(_processTabButton, ProcessTabSelected);
		}

		/// <summary>
		/// Selects a tab button.
		/// </summary>
		/// <param name="button">The button to select.</param>
		/// <param name="tabSelectedEvent">The event to invoke after selection.</param>
		private void SelectTabButton(Button button, EventHandler tabSelectedEvent)
		{
			if (_selectedTabButton == button)
			{
				return;
			}
			_selectedTabButton.ForeColor = SystemColors.Window;
			_selectedTabButton.BackColor = Color.Transparent;
			_selectedTabButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			_selectedTabButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;

			button.ForeColor = SystemColors.ControlText;
			button.BackColor = SystemColors.Control;
			button.FlatAppearance.MouseDownBackColor = SystemColors.Control;
			button.FlatAppearance.MouseOverBackColor = SystemColors.Control;

			_selectedTabButton = button;
			tabSelectedEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
