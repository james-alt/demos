using System.Collections.Generic;

namespace SQLSaturday.Data
{
	public class Speaker
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Twitter { get; set; }
		public string LinkedIn { get; set; }
		public string ContactUrl { get; set; }
		public string ImageUrl { get; set; }
		public IList<Session> Sessions { get; set; }

		public string NameSort {
			get {				
				return Name.GetLastName ()[0].ToString ().ToUpper ();
			}
		}		
	}
}