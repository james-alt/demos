using System.Xml.Serialization;

namespace SQLSaturday.Data
{

	public class LocationDto
	{
		[XmlElement("name")]
		public string Name { get; set; }
	}
	
}
