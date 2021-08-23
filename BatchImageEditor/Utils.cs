using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace BatchImageEditor
{
	internal static class Utils
	{
		public static void DockFill(Control control)
		{
			control.Dock = DockStyle.None;
			Control parent = control.Parent;
			control.Bounds = new Rectangle
			{
				X = parent.Padding.Left,
				Y = parent.Padding.Top,
				Width = parent.Width - parent.Padding.Left - parent.Padding.Right,
				Height = parent.Height - parent.Padding.Top - parent.Padding.Bottom
			};
			control.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		}

		//public static void DockLeft(Control) 
	}
}
