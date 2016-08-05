using PropertyChanged;
using SQLSaturday.Data;

namespace SQLSaturday
{

	[ImplementPropertyChanged]
	public class SpeakerViewModel : BaseViewModel
	{
		public SpeakerViewModel ()
		{
		}

		public Speaker CurrentSpeaker { get; set; }
	}

}
