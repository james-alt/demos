using System.Threading.Tasks;
using System;

namespace SQLSaturday.Data
{
	public interface IDataClient
	{
		Task<Conference> GetCachableConferenceAsync();
		Task<Conference> GetRemoteConferenceAsync ();
	}
}