using Xamarin.Forms;
using Akavache;

namespace SQLSaturday
{
	public class App : Application
	{
		public App (AppSetup setup)
		{
			BlobCache.ApplicationName = "SqlSaturday";
			AppContainer.Container = setup.CreateContainer ();

			MainPage = new NavigationPage (new MainPage ()) {
				BarTextColor = Color.White
			};
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

