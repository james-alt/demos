using System;
namespace sqlsaturdaydemo
{

	public static class ViewModelLocator
	{
		static SessionsViewModel _sessionsViewModel;
		public static SessionsViewModel SessionsViewModel => _sessionsViewModel 
			?? (_sessionsViewModel = new SessionsViewModel ());

		static SpeakersViewModel _speakersViewModel;
		public static SpeakersViewModel SpeakersViewModel => _speakersViewModel
			?? (_speakersViewModel = new SpeakersViewModel ());
	}
}
