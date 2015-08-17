using Xamarin.Forms;
using SQLSaturday.Data;

namespace SQLSaturday
{

	public class SpeakerPage : ViewPage<SpeakerViewModel>
	{
		public SpeakerPage (Speaker speaker)
		{
			ViewModel.CurrentSpeaker = speaker;
			Title = speaker.Name;

			var titleLabel = new Label {
				Text = speaker.Name
			};

			var stackLayout = new StackLayout {
				Padding = 10,
				Orientation = StackOrientation.Vertical,
				Children = { titleLabel }
			};

			Content = stackLayout;
		}
	}

}
