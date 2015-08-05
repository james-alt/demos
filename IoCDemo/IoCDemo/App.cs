using Xamarin.Forms;

namespace IoCDemo
{
	public class App : Application
	{
		public App (AppSetup setup)
		{
			AppContainer.Container = setup.CreateContainer ();
			MainPage = new NavigationPage (new HomePage ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

