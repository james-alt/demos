using System;
using System.Collections.ObjectModel;
namespace sqlsaturdaydemo
{
	public class SessionsViewModel
	{
		public ObservableCollection<Session> Sessions { get; set; }

		public SessionsViewModel ()
		{
			Sessions = new ObservableCollection<Session> (MockSessionStore.Instance.GetSessions ());
		}
	}
}
