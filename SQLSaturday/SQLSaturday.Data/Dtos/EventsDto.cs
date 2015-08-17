using System.Xml.Serialization;
using System.Collections.Generic;

namespace SQLSaturday.Data
{

	public class EventsDto 
	{
		[XmlElement("event")]
		public List<EventDto> Events { get; set; }
	}
	
}
