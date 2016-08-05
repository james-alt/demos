using System.Collections.Generic;

namespace SQLSaturday.Data
{
	public class Conference
	{
		public Conference ()
		{
			Sessions = new List<Session> ();
			Speakers = new List<Speaker> ();
			Tracks = new List<Track> ();
		}

		public IList<Session> Sessions { get; set; }
		public IList<Speaker> Speakers { get; set; }
		public IList<Track> Tracks { get; set; }
	}
}

