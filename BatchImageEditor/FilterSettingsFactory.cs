
namespace BatchImageEditor
{
	public class FilterSettingsFactory<TSettings> : IFactory<FilterSettingsBase>
		where TSettings : FilterSettingsBase, new()
	{
		public FilterSettingsBase CreateInstance()
		{
			return new TSettings();
		}
	}
}
