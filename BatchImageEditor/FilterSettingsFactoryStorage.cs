using System;
using System.Collections.Generic;

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
			_settingNamesToFactories.Add(name, factory);
		}

		public IFactory<FilterSettingsBase> GetFactory(string name)
		{
			IFactory<FilterSettingsBase> factory;
			if (_settingNamesToFactories.TryGetValue(name, out factory))
			{
				return factory;
			}
			throw new ArgumentException("There is no factory with the given name.");
		}

		private readonly Dictionary<string, IFactory<FilterSettingsBase>> _settingNamesToFactories = new();
	}
}
