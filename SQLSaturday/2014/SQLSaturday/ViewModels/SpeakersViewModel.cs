using SQLSaturday.Data;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace SQLSaturday
{

	[ImplementPropertyChanged]
	public class SpeakersViewModel : IViewModel
	{
		public SpeakersViewModel ()
		{
			InitializeSpeakers ();
		}

		private void InitializeSpeakers()
		{
			if (Speakers == null) {
				GroupedSpeakers = new ObservableCollection<Grouping<string, ImageSpeaker>> ();
			} else {
				GroupedSpeakers.Clear ();
			}
		}

		private IList<Speaker> _speakers;
		public IList<Speaker> Speakers { 
			get {
				return _speakers;
			}
			set {
				_speakers = value;
				SortSpeakers ();
			}
		}

		private void SortSpeakers()
		{
			if (Speakers == null)
				return;			

			var imageSpeakers = new List<ImageSpeaker> ();
			foreach (var item in Speakers) {
				imageSpeakers.Add (new ImageSpeaker(item));
			}

			var sorted = from speaker in imageSpeakers
				orderby speaker.Name.GetLastName()
				group speaker by speaker.NameSort into speakerGroup
				select new Grouping<string, ImageSpeaker> (speakerGroup.Key, speakerGroup);

			InitializeSpeakers ();
			foreach (var item in sorted) {
				GroupedSpeakers.Add (item);
			}				
		}

		public ObservableCollection<Grouping<string, ImageSpeaker>> GroupedSpeakers { get; set; }
	}
}
