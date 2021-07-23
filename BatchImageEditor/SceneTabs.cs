using System;
using System.Drawing;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class SceneTabs : UserControl
	{
		public event EventHandler LoadTabSelected;
		public event EventHandler EditTabSelected;
		public event EventHandler ProcessTabSelected;

		public SceneTabs()
		{
			InitializeComponent();
			selectedTabButton = loadTabButton;
		}

		private Button selectedTabButton;

		private void SceneTabs_Load(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		private void SceneTabs_Resize(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		private void CenterMenuButtons()
		{
			tabsPanel.Location = new Point
			{
				X = (this.Width - tabsPanel.Width) / 2,
				Y = tabsPanel.Location.Y
			};
		}

		private void LoadTabButton_Click(object sender, EventArgs e)
		{
			SelectTabButton(loadTabButton, LoadTabSelected);
		}

		private void EditTabButton_Click(object sender, EventArgs e)
		{
			SelectTabButton(editTabButton, EditTabSelected);
		}

		private void ProcessTabButton_Click(object sender, EventArgs e)
		{
			SelectTabButton(processTabButton, ProcessTabSelected);
		}

		private void SelectTabButton(Button button, EventHandler tabSelectedEvent)
		{
			if (selectedTabButton == button)
			{
				return;
			}
			selectedTabButton.ForeColor = SystemColors.Window;
			selectedTabButton.BackColor = Color.Transparent;
			selectedTabButton.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
			selectedTabButton.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;

			button.ForeColor = SystemColors.ControlText;
			button.BackColor = SystemColors.Control;
			button.FlatAppearance.MouseDownBackColor = SystemColors.Control;
			button.FlatAppearance.MouseOverBackColor = SystemColors.Control;

			selectedTabButton = button;
			tabSelectedEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
