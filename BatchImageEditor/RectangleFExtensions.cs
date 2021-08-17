using System.Drawing;

namespace BatchImageEditor
{
	public static class RectangleFExtensions
	{
		public static RectangleF WithX(this RectangleF rect, float x) => new(x, rect.Y, rect.Width, rect.Height);

		public static RectangleF WithY(this RectangleF rect, float y) => new(rect.X, y, rect.Width, rect.Height);

		public static RectangleF WithWidth(this RectangleF rect, float width) => new(rect.X, rect.Y, width, rect.Height);

		public static RectangleF WithHeight(this RectangleF rect, float height) => new(rect.X, rect.Y, rect.Width, height);
	}
}
