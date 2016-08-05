using System.IO;
using System.Threading.Tasks;

namespace SQLSaturday.Data
{
	public interface ISerializerService
	{
		Task<T> Deserialize<T>(Stream data);
	}
}

