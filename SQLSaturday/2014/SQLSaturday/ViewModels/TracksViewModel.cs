using SQLSaturday.Data;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace SQLSaturday
{
	[ImplementPropertyChanged]
	public class TracksViewModel : BaseViewModel
	{
		public TracksViewModel ()
		{
			TrackList = new ObservableCollection<Track> ();
		}

		public ObservableCollection<Track> TrackList { get; set; }

		private IList<Track> _tracks;
		public IList<Track> Tracks {
			get { 
				return _tracks;
			}
			set { 
				_tracks = value;
				SortTracks ();
			}
		}

		private void SortTracks()
		{
			if (Tracks == null)
				return;

			var sorted = Tracks.OrderBy (p => p.Title);
			TrackList.Clear ();
			foreach (var item in sorted)
				TrackList.Add (item);
		}
	}
	
}
