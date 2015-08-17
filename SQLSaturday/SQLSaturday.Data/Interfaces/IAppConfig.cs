namespace SQLSaturday.Data
{
	public interface IAppConfig
	{
		string GuidebookAddress { get; }
		string ConferenceIdentifier { get; set; }
	}
}

