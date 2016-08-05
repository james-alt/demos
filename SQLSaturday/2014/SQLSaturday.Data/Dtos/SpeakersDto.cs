using System.Xml.Serialization;
using System.Collections.Generic;

namespace SQLSaturday.Data
{

	public class SpeakersDto
	{
		[XmlElement("speaker")]
		public List<SpeakerDto> Speakers { get; set; }
	}
	
}
