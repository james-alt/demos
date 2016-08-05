using System.Collections.Generic;

namespace SQLSaturday.Data
{
	public class Track
	{
		public string Title { get; set; }
		public IList<Session> Sessions { get; set; }	

		public string FormattedSessionCount 
		{
			get {
				return string.Format ("{0} Sessions", Sessions != null ? Sessions.Count : 0);
			}
		}
	}
}