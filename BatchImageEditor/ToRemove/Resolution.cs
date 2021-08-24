using System.Drawing;
using System.Windows.Forms;

namespace BatchImageEditor
{
    // TODO: remove
	internal static class Resolution
	{
        public static void ScaleForm(Form form, int designedWidth, int designedHeight)
        {
            float widthFactor = Screen.PrimaryScreen.Bounds.Size.Width / (float)designedWidth;
            float heightFactor = Screen.PrimaryScreen.Bounds.Size.Height / (float)designedHeight;
            ScaleControlSize(form, widthFactor, heightFactor);
            foreach (Control child in form.Controls)
            {
                ScaleControlRecursively(child, widthFactor, heightFactor);
            }
        }

        public static void ScaleControlRecursively(Control control, float widthFactor, float heightFactor)
        {
            ScaleControlSize(control, widthFactor, heightFactor);
            ScaleControlLocation(control, widthFactor, heightFactor);
            foreach (Control child in control.Controls)
            {
                ScaleControlRecursively(child, widthFactor, heightFactor);
            }
        }

        private static void ScaleControlSize(Control control, float widthFactor, float heightFactor)
		{
            control.Size = new Size
            {
                Width = (int)(control.Width * widthFactor),
                Height = (int)(control.Height * heightFactor)
            };
            control.MinimumSize = new Size
            {
                Width = (int)(control.MinimumSize.Width * widthFactor),
                Height = (int)(control.MinimumSize.Height * heightFactor),
            };
            control.MaximumSize = new Size
            {
                Width = (int)(control.MaximumSize.Width * widthFactor),
                Height = (int)(control.MaximumSize.Height * heightFactor),
            };
            control.Font = new Font(control.Font.FontFamily, control.Font.Size * widthFactor);
        }

        private static void ScaleControlLocation(Control control, float widthFactor, float heightFactor)
        {
            control.Location = new Point
            {
                X = (int)(control.Left * widthFactor),
                Y = (int)(control.Top * heightFactor)
            };
        }
    }
}
