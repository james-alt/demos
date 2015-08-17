using SQLSaturday.Data;

namespace SQLSaturday
{
	public class AppConfig : IAppConfig
	{
		private ISettingsService _settingsService;

		public AppConfig (ISettingsService settingsService)
		{
			_settingsService = settingsService.ThrowIfNull ("settingsService");
		}

		public string GuidebookAddress
		{
			get {
				return "http://www.sqlsaturday.com/eventxml.aspx?sat=" + ConferenceIdentifier;
			}
		}

		public string ConferenceIdentifier
		{
			get {
				return _settingsService.ConferenceIdentifier;
			} 
			set {
				_settingsService.ConferenceIdentifier = value;
			}
		}
	}
}