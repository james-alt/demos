using System.Xml.Serialization;
using System.Collections.Generic;

namespace SQLSaturday.Data
{

	public class SponsorsDto
	{
		[XmlElement("sponsor")]
		public List<SponsorDto> Sponsors { get; set; }
	}
	
}
