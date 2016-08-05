using Xamarin.Forms;
using SQLSaturday.Data;

namespace SQLSaturday
{

	public class TrackPage : ViewPage<TrackViewModel>
	{
		public TrackPage (Track track)
		{
			ViewModel.CurrentTrack = track;
			Title = track.Title;

			var titleLabel = new Label {
				Text = track.Title,
				TextColor = Colors.PrimaryColor,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var titleLayout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = 10,
				BackgroundColor = Colors.LightPrimaryColor,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { titleLabel }
			};

			var sessionsList = new ListView {
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(SessionCell)),
				ItemsSource = ViewModel.CurrentTrack.Sessions,
				SeparatorColor = Colors.DividerColor
			};

			var stackLayout = new StackLayout {
				Padding = 0,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Center,
				Children = { titleLayout, sessionsList }
			};

			Content = stackLayout;

		}
	}

}
