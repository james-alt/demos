using SQLSaturday.Data;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace SQLSaturday
{
	[ImplementPropertyChanged]
	public class SessionsViewModel : BaseViewModel
	{
		public SessionsViewModel ()
		{
			GroupedSessions = new ObservableCollection<Grouping<string, Session>> ();
		}

		private IList<Session> _sessions;
		public IList<Session> Sessions { 
			get {
				return _sessions;
			}
			set {
				_sessions = value;
				SortSessions ();
			}
		}

		public ObservableCollection<Grouping<string, Session>> GroupedSessions { get; set; }

		private void SortSessions()
		{
			if (Sessions == null)
				return;

			var sorted = from session in Sessions
				orderby session.StartTime
				group session by session.StartTimeString into sessionGroup
				select new Grouping<string, Session> (sessionGroup.Key, sessionGroup);

			GroupedSessions.Clear ();
			foreach (var item in sorted) {
				GroupedSessions.Add (item);
			}
		}
	}

}

