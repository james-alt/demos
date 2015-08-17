using System.Threading.Tasks;
using System.IO;

namespace SQLSaturday.Data
{
	public interface IHttpService
	{
		Task<Stream> GetResponseAsync(string url);
	}
}