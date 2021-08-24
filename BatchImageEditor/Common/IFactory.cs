
namespace BatchImageEditor
{
	/// <summary>
	/// A factory for creating an instance of type <see cref="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of an instance to be created.</typeparam>
	public interface IFactory<out T>
	{
		/// <summary>
		/// Creates an instance of type <see cref="T"/>.
		/// </summary>
		/// <returns>An instance of type <see cref="T"/>.</returns>
		T CreateInstance();
	}
}
