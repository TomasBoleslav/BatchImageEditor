
namespace BatchImageEditor
{
	public interface IFactory<T>
	{
		T CreateInstance();
	}
}
