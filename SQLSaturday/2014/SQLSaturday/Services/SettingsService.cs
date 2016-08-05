using SQLSaturday.Data;
using SQLSaturday.Helpers;

namespace SQLSaturday
{
	public class SettingsService : ISettingsService
	{
		public SettingsService ()
		{
		}
				
		public string ConferenceIdentifier {
			get {
				return Settings.ConferenceIdentifier;
			} 
			set {
				Settings.ConferenceIdentifier = value;
			}
		}
	}
}

