using System.Xml.Serialization;

namespace SQLSaturday.Data
{

	public class SpeakerDto
	{
		[XmlElement("importID")]
		public string ImportId { get; set; }

		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("label")]
		public string Label { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }

		[XmlElement("twitter")]
		public string Twitter { get; set; }

		[XmlElement("linkedin")]
		public string LinkedIn { get; set; }

		[XmlElement("ContactURL")]
		public string ContactUrl { get; set; }

		[XmlElement("imageURL")]
		public string ImageUrl { get; set; }

		[XmlElement("imageHeight")]
		public int ImageHeight { get; set; }

		[XmlElement("imageWidth")]
		public int ImageWidth { get; set; }
	}
	
}
