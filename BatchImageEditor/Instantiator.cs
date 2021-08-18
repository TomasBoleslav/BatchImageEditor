
namespace BatchImageEditor
{
	public class Instantiator<T> : IFactory<T>
		where T : new()
	{
		public T CreateInstance()
		{
			return new T();
		}
	}
}
