using PropertyChanged;
using SQLSaturday.Data;
using System.Threading.Tasks;
using Autofac;

namespace SQLSaturday
{
	[ImplementPropertyChanged]
	public class MainViewModel : BaseViewModel
	{
		private IDataClient _dataClient;
		private IAppConfig _appConfig;

		private readonly SessionsViewModel _sessionsViewModel;
		private readonly SpeakersViewModel _speakersViewModel;
		private readonly TracksViewModel _tracksVieModel;

		public MainViewModel (IDataClient dataClient, IAppConfig appConfig)
		{
			_dataClient = dataClient.ThrowIfNull ("dataClient");
			_appConfig = appConfig.ThrowIfNull ("appConfig");

			using (var scope = AppContainer.Container.BeginLifetimeScope ()) {
				_sessionsViewModel = AppContainer.Container.Resolve<SessionsViewModel> ();
				_speakersViewModel = AppContainer.Container.Resolve<SpeakersViewModel> ();
				_tracksVieModel = AppContainer.Container.Resolve<TracksViewModel> ();
			}
		}

		public async Task LoadConference()
		{
			Conference = await _dataClient.GetCachableConferenceAsync ();
			_sessionsViewModel.Sessions = Conference.Sessions;
			_speakersViewModel.Speakers = Conference.Speakers;
			_tracksVieModel.Tracks = Conference.Tracks;
		}

		public Conference Conference { get; set; }

		public bool IsConferenceSelected {
			get { return !string.IsNullOrEmpty (_appConfig.ConferenceIdentifier); }
		}

		public string ConferenceIdentifier { get { return _appConfig.ConferenceIdentifier; } }

		public async Task SetConferenceIdentifier(string conferenceIdentifier) 
		{
			if (conferenceIdentifier.Equals (ConferenceIdentifier))
				return;
			IsBusy = true;
			_appConfig.ConferenceIdentifier = conferenceIdentifier;
			await LoadConference ();
			IsBusy = false;
		}
	}

}