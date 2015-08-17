using Connectivity.Plugin;

namespace SQLSaturday.Data
{
	public class ConnectivityService : IConnectivityService
	{
		public bool IsConnected
		{
			get {
				return CrossConnectivity.Current.IsConnected;
			}
		}
	}
}

