using System.Drawing;

namespace BatchImageEditor
{
	/// <summary>
	/// Extension methods for the <see cref="RectangleF"/> struct.
	/// </summary>
	internal static class RectangleFExtensions
	{
		/// <summary>
		/// Creates a <see cref="RectangleF"/> with changed X.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="x">A new X.</param>
		/// <returns>A new rectangle with changed X.</returns>
		public static RectangleF WithX(this RectangleF rect, float x) => new(x, rect.Y, rect.Width, rect.Height);

		/// <summary>
		/// Creates a <see cref="RectangleF"/> with changed Y.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="y">A new Y.</param>
		/// <returns>A new rectangle with changed Y.</returns>
		public static RectangleF WithY(this RectangleF rect, float y) => new(rect.X, y, rect.Width, rect.Height);

		/// <summary>
		/// Creates a <see cref="RectangleF"/> with changed Width.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="width">A new Width.</param>
		/// <returns>A new rectangle with changed Width.</returns>
		public static RectangleF WithWidth(this RectangleF rect, float width) => new(rect.X, rect.Y, width, rect.Height);

		/// <summary>
		/// Creates a <see cref="RectangleF"/> with changed Height.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="height">A new Height.</param>
		/// <returns>A new rectangle with changed Height.</returns>
		public static RectangleF WithHeight(this RectangleF rect, float height) => new(rect.X, rect.Y, rect.Width, height);
	}
}
