using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageEditor
{
	// TODO: bad name, storage indicates disk storage
	class FilterSettingsFactoryStorage
	{
		// TODO: maybe replace T with FilterSettingsBase thanks to covariance
		// public void Add(IFactory<FilterSettingsBase> factory)
		public void Add<T>(IFactory<T> factory) where T : FilterSettingsBase
		{
			string name = FilterSettingsNames.GetName(typeof(T));
			settingNamesToFactories.Add(name, factory);
		}

		public IFactory<FilterSettingsBase> GetFactory(string name)
		{
			IFactory<FilterSettingsBase> factory;
			if (settingNamesToFactories.TryGetValue(name, out factory))
			{
				return factory;
			}
			throw new ArgumentException("There is no factory with the given name.");
		}

		private readonly Dictionary<string, IFactory<FilterSettingsBase>> settingNamesToFactories = new();
	}
}
