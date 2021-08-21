
namespace BatchImageEditor
{
	/// <summary>
	/// A factory for creating instances of type <see cref="T"/> using their default constructor.
	/// </summary>
	/// <typeparam name="T">The type of an instance to be created.</typeparam>
	public class Instantiator<T> : IFactory<T>
		where T : new()
	{
		/// <summary>
		/// Creates an instance of type <see cref="T"/> using the default constructor.
		/// </summary>
		/// <returns>An instance of type <see cref="T"/>.</returns>
		public T CreateInstance()
		{
			return new T();
		}
	}
}
