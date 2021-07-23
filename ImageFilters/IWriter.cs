
namespace ImageFilters
{
	public interface IWriter<T>
	{
		void Write(T instance);
	}
}
