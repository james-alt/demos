using System.Xml.Serialization;

namespace SQLSaturday.Data
{

	public class SponsorDto
	{
		[XmlElement("importID")]
		public string ImportId { get; set; }

		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("label")]
		public string Label { get; set; }

		[XmlElement("url")]
		public string Url { get; set; }

		[XmlElement("imageURL")]
		public string ImageUrl { get; set; }

		[XmlElement("imageHeight")]
		public int ImageHeight { get; set; }

		[XmlElement("imageWidth")]
		public int ImageWidth { get; set; }
	}
	
}
