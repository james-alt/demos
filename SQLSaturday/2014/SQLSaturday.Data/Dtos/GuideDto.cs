using System;
using System.Xml.Serialization;

namespace SQLSaturday.Data
{

	public class GuideDto
	{
		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("startDate")]
		public string StartDateString
		{
			get { return StartDate.ToString("MM/dd/yyyy HH:mm:ss tt"); } //8/2/2014 12:00:00 AM
			set { StartDate = DateTime.Parse(value); }
		}

		[XmlIgnore]
		public DateTime StartDate { get; set; }

		[XmlElement("timezone")]
		public string TimeZone { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }

		[XmlElement("twitterHashtag")]
		public string TwitterHashtag { get; set; }

		[XmlElement("venue")]
		public VenueDto Venue { get; set; }
	}
	
}
