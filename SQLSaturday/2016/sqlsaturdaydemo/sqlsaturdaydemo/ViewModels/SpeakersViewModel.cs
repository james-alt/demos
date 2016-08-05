using System;
using System.Collections.ObjectModel;
namespace sqlsaturdaydemo
{
	public class SpeakersViewModel
	{
		public ObservableCollection<Speaker> Speakers { get; set; }

		public SpeakersViewModel ()
		{
			Speakers = new ObservableCollection<Speaker> (MockSpeakerStore.Instance.GetSpeakers ());
		}
	}
	
}
