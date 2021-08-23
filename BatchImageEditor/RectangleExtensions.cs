using System.Drawing;

namespace BatchImageEditor
{
	/// <summary>
	/// Extension methods for the <see cref="Rectangle"/> struct.
	/// </summary>
	internal static class RectangleExtensions
	{
		/// <summary>
		/// Creates a <see cref="Rectangle"/> with changed X.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="x">A new X.</param>
		/// <returns>A new rectangle with changed X.</returns>
		public static Rectangle WithX(this Rectangle rect, int x) => new(x, rect.Y, rect.Width, rect.Height);

		/// <summary>
		/// Creates a <see cref="Rectangle"/> with changed Y.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="y">A new Y.</param>
		/// <returns>A new rectangle with changed Y.</returns>
		public static Rectangle WithY(this Rectangle rect, int y) => new(rect.X, y, rect.Width, rect.Height);

		/// <summary>
		/// Creates a <see cref="Rectangle"/> with changed Width.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="width">A new Width.</param>
		/// <returns>A new rectangle with changed Width.</returns>
		public static Rectangle WithWidth(this Rectangle rect, int width) => new(rect.X, rect.Y, width, rect.Height);

		/// <summary>
		/// Creates a <see cref="Rectangle"/> with changed Height.
		/// </summary>
		/// <param name="rect">A rectangle to start from.</param>
		/// <param name="height">A new Height.</param>
		/// <returns>A new rectangle with changed Height.</returns>
		public static Rectangle WithHeight(this Rectangle rect, int height) => new(rect.X, rect.Y, rect.Width, height);
	}
}
