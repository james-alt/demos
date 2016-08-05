using Xamarin.Forms;

namespace sqlsaturdaydemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			switch (Device.OS) {
			case TargetPlatform.Android:
				MainPage = new DemoMasterDetailPage ();
				break;
			case TargetPlatform.iOS:
				MainPage = new DemoTabbedPage ();
				break;
			}
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
