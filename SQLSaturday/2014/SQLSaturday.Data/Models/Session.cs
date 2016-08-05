using System.Collections.Generic;
using System;
using System.Linq;

namespace SQLSaturday.Data
{
	public class Session
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IList<Speaker> Speakers { get; set; }
		public string Track { get; set; }
		public string Room { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public string StartTimeString {
			get {
				return StartTime.ToString ("t");
			}
		}

		public string SpeakerNames {
			get {
				if (Speakers == null || !Speakers.Any ())
					return string.Empty;

				var names = Speakers.Select (p => p.Name); 
				var speakerNames = string.Join (", ", names);

				return speakerNames;
			}
		}
	}
}

