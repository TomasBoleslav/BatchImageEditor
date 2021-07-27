
namespace ImageFilters
{
	public interface IPipe<T>
	{
		T Receive();

		void Send(T value);
	}
}
