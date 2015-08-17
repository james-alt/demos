using System.Xml.Serialization;

namespace SQLSaturday.Data
{

	public class VenueDto
	{
		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("street")]
		public string Street { get; set; }

		[XmlElement("city")]
		public string City { get; set; }

		[XmlElement("state")]
		public string State { get; set; }

		[XmlElement("zipcode")]
		public string ZipCode { get; set; }
	}
	
}
