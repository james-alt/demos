using Xamarin.Forms;
using SQLSaturday.Data;

namespace SQLSaturday
{

	public class TracksPage : ViewPage<TracksViewModel>
	{
		public TracksPage ()
		{
			var tracksList = new ListView {
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(TrackCell)),
				ItemsSource = ViewModel.TrackList,
				SeparatorColor = Colors.DividerColor
			};

			tracksList.ItemSelected += async (sender, e) => {
				var track = tracksList.SelectedItem as Track;
				if(track == null)
					return;

				await Navigation.PushAsync(new TrackPage(track));
				tracksList.SelectedItem = null;
			};

			Content = tracksList;
		}
	}
}
