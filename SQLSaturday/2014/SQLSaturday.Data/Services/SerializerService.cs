using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SQLSaturday.Data
{
	public class SerializerService : ISerializerService
	{
		public async Task<T> Deserialize<T> (Stream data)
		{
			data.ThrowIfNull ("data");

			return await Task.Run (() => {
				var serializer = new XmlSerializer(typeof(T));
				var obj = (T)serializer.Deserialize(new StreamReader(data));

				return obj;
			});
		}
	}
}