using PropertyChanged;
using SQLSaturday.Data;

namespace SQLSaturday
{
	[ImplementPropertyChanged]
	public class SessionViewModel : BaseViewModel
	{
		public SessionViewModel ()
		{
		}

		public Session CurrentSession { get; set; }
	}
}
