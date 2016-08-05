using System.Threading.Tasks;
using System;
using Akavache;
using System.Reactive.Linq;

namespace SQLSaturday.Data
{
	public class DataClient : IDataClient
	{
		private IMapperService _mapperService;
		private IConnectivityService _connectivityService;
		private ISerializerService _serializerService;
		private IHttpService _httpService;
		private IAppConfig _appConfig;

		public DataClient (IMapperService mapperService, 
			IConnectivityService connectivityService,
			ISerializerService serializerService,
			IHttpService httpService,
			IAppConfig appConfig)
		{
			_mapperService = mapperService.ThrowIfNull ("mapperService");
			_connectivityService = connectivityService.ThrowIfNull ("connectivityService");
			_serializerService = serializerService.ThrowIfNull ("serializerService");
			_httpService = httpService.ThrowIfNull ("httpService");
			_appConfig = appConfig.ThrowIfNull ("appConfig");
		}

		public async Task<Conference> GetCachableConferenceAsync()
		{
			try {
				var ret = BlobCache.LocalMachine.GetOrFetchObject (ConferenceStoreName,
					async () => {
						var conference = await GetRemoteConferenceAsync();
						return conference;
					}, DateTimeOffset.Now + TimeSpan.FromMinutes(0));

				var con = await ret.FirstOrDefaultAsync ();
				return con;
			} catch (Exception) {
				return new Conference ();
			}
		}

		public async Task<Conference> GetRemoteConferenceAsync()
		{
			var conference = new Conference ();

			if (_connectivityService.IsConnected) {
				try {
					var stream = await _httpService.GetResponseAsync (_appConfig.GuidebookAddress);
					var guidebook = await _serializerService.Deserialize<GuidebookDto> (stream);
					conference = _mapperService.MapGuidebookToConference (guidebook);
				} catch(Exception) {
					return conference;
				}
			}

			return conference;
		}

		string ConferenceStoreName { get { return "conference_" + _appConfig.ConferenceIdentifier; } }
	}
}