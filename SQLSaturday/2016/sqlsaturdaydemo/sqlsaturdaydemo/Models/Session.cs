using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sqlsaturdaydemo
{
	public class Session
	{
		public Session ()
		{
			Speakers = new List<Speaker> ();
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IList<Speaker> Speakers { get; set; }

		private string _speakerNames;
		public string SpeakerNames {
			get {
				if (_speakerNames != null)
					return _speakerNames;

				_speakerNames = string.Empty;

				if (Speakers == null || Speakers.Count == 0) {
					return _speakerNames;
				}

				var allSpeakers = Speakers.ToArray ();
				for (var i = 0; i < allSpeakers.Length; i++) {
					_speakerNames += allSpeakers [i].Name;
					if (i != Speakers.Count - 1)
						_speakerNames += ", ";
				}
				return _speakerNames;
			}
		}
	}
}
