using Xamarin.Forms;
using SQLSaturday.Data;

namespace SQLSaturday
{

	public class SessionsPage : ViewPage<SessionsViewModel>
	{
		public SessionsPage ()
		{
			var sessionsList = new ListView {
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(SessionCell)),
				ItemsSource = ViewModel.GroupedSessions,
				IsGroupingEnabled = true,
				GroupDisplayBinding = new Binding("Key"),
				SeparatorColor = Colors.DividerColor
			};

			sessionsList.ItemSelected += async (sender, e) => {
				var session = sessionsList.SelectedItem as Session;
				if(session == null)
					return;

				await Navigation.PushAsync(new SessionPage(session));
				sessionsList.SelectedItem = null;
			};

			if (Device.OS != TargetPlatform.WinPhone) {
				sessionsList.GroupHeaderTemplate = new DataTemplate (typeof(HeaderCell));
			}

			Content = sessionsList;
		}
	}

}
