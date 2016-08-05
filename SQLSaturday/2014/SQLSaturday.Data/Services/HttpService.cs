using System.Net.Http;
using ModernHttpClient;
using System.Threading.Tasks;
using System.IO;

namespace SQLSaturday.Data
{
	public class HttpService : IHttpService
	{
		public async Task<Stream> GetResponseAsync(string url)
		{
			using (var httpClient = CreateClient ()) {
				var response = await httpClient.GetAsync (url).ConfigureAwait (false);
				if (response.IsSuccessStatusCode) {
					var stream = await response.Content.ReadAsStreamAsync ().ConfigureAwait (false);
					return stream;
				}
				throw new HttpRequestException ();
			}
		}

		static HttpClient CreateClient()
		{
			return new HttpClient (new NativeMessageHandler ());
		}
	}
}

