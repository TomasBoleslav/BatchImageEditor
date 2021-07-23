using System;
using System.Drawing;
using System.Windows.Forms;

namespace BatchImageEditor
{
	public partial class SceneTabs : UserControl
	{
		public event EventHandler LoadTabClick;
		public event EventHandler EditTabClick;
		public event EventHandler ProcessTabClick;

		public SceneTabs()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			CenterMenuButtons();
		}

		private void OnResize(object sender, EventArgs e)
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

		private void OnLoadTabClick(object sender, EventArgs e)
		{
			LoadTabClick?.Invoke(this, EventArgs.Empty);
		}

		private void OnEditTabClick(object sender, EventArgs e)
		{
			EditTabClick?.Invoke(this, EventArgs.Empty);
		}

		private void OnProcessTabClick(object sender, EventArgs e)
		{
			ProcessTabClick?.Invoke(this, EventArgs.Empty);
		}
	}
}
