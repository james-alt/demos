using Xamarin.Forms;
using SQLSaturday.Data;

namespace SQLSaturday
{

	public class SpeakersPage : ViewPage<SpeakersViewModel>
	{
		public SpeakersPage ()
		{
			var speakersList = new ListView {
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(SpeakerCell)),
				ItemsSource = ViewModel.GroupedSpeakers,
				IsGroupingEnabled = true,
				GroupDisplayBinding = new Binding("Key"),
				GroupShortNameBinding = new Binding("Key"),
				SeparatorColor = Colors.DividerColor
			};

			speakersList.ItemSelected += async (sender, e) => {
				var speaker = speakersList.SelectedItem as Speaker;
				if(speaker == null)
					return;

				await Navigation.PushAsync(new SpeakerPage(speaker));
				speakersList.SelectedItem = null;
			};

			if (Device.OS != TargetPlatform.WinPhone) {
				speakersList.GroupHeaderTemplate = new DataTemplate (typeof(HeaderCell));
			}

			Content = speakersList;
		}
	}

}
