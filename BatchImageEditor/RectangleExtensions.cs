using System.Drawing;

namespace BatchImageEditor
{
	public static class RectangleExtensions
	{
		public static Rectangle WithX(this Rectangle rect, int x) => new(x, rect.Y, rect.Width, rect.Height);

		public static Rectangle WithY(this Rectangle rect, int y) => new(rect.X, y, rect.Width, rect.Height);

		public static Rectangle WithWidth(this Rectangle rect, int width) => new(rect.X, rect.Y, width, rect.Height);

		public static Rectangle WithHeight(this Rectangle rect, int height) => new(rect.X, rect.Y, rect.Width, height);
	}
}
