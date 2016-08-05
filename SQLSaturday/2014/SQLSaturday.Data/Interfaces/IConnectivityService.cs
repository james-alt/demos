namespace SQLSaturday.Data
{
	public interface IConnectivityService
	{
		bool IsConnected { get; }
	}
}