using PropertyChanged;
using SQLSaturday.Data;

namespace SQLSaturday
{

	[ImplementPropertyChanged]
	public class TrackViewModel : BaseViewModel
	{
		public TrackViewModel ()
		{
		}

		public Track CurrentTrack { get; set; }
	}
}
