using System.Collections.Generic;

namespace BatchImageEditor
{
	public interface IFactory<out T>
	{
		T CreateInstance();
	}
}
