using System;
using System.Collections.Generic;

namespace BatchImageEditor
{
	/// <summary>
	/// A collection of factories for creating instances of <see cref="FilterSettingsBase"/>.
	/// </summary>
	/// <remarks>
	/// All added settings factories must have a name registered in <see cref="FilterSettingsNames"/>.
	/// </remarks>
	internal class FilterSettingsFactoryCollection
	{
		/// <summary>
		/// Adds a factory to the colletion.
		/// </summary>
		/// <remarks>
		/// Only one factory per settings type can be added.
		/// </remarks>
		/// <typeparam name="T">The type of settings the factory creates.</typeparam>
		/// <param name="factory">A factory to add.</param>
		public void Add<T>(IFactory<T> factory) where T : FilterSettingsBase
		{
			string name = FilterSettingsNames.GetName(typeof(T));
			_settingNamesToFactories.Add(name, factory);
		}

		/// <summary>
		/// Gets a factory by the name of the settings it creates.
		/// </summary>
		/// <param name="name">A name of the settings.</param>
		/// <returns>A factory that creates settings with the given name.</returns>
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
