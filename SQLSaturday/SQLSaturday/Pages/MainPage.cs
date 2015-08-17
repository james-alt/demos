using Xamarin.Forms;
using System.Threading.Tasks;

namespace SQLSaturday
{
	public class MainPage : TabbedViewPage<MainViewModel>
	{
		SessionsPage _sessionsPage;
		SpeakersPage _speakersPage;
		TracksPage _tracksPage;

		public MainPage ()
		{
			_sessionsPage = new SessionsPage { Title = "Sessions" };
			_speakersPage = new SpeakersPage { Title = "Speakers" };
			_tracksPage = new TracksPage { Title = "Tracks" };

			Children.Add (_sessionsPage);
			Children.Add (_speakersPage);
			Children.Add (_tracksPage);

			ToolbarItems.Add (new ToolbarItem {
				StyleId = "toolbar_settings",
				Text = "Settings",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(async () => await ShowConferenceSelector (ViewModel.ConferenceIdentifier))
			});					

			Task.Run(() => GetConferenceIdentifier ());
		}			

		protected override async void OnAppearing ()
		{
			base.OnAppearing ();

			if(ViewModel.IsConferenceSelected)
				await ViewModel.LoadConference();
		}

		private async Task GetConferenceIdentifier()
		{
			if (ViewModel.IsConferenceSelected)
				return;
			await ShowConferenceSelector (null);
		}

		private async Task ShowConferenceSelector(string identifier)
		{
			var modalPage = new ConferenceSelectionPage (identifier);
			modalPage.Dismissed += async conferenceIdentifier => {			
				await Navigation.PopModalAsync();	
				await ViewModel.SetConferenceIdentifier(conferenceIdentifier);
			};
			await Navigation.PushModalAsync (modalPage);
		}
	}

}

