using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace SQLSaturday.UITests
{
	public class AppInitializer
	{
		public static IApp StartApp (Platform platform)
		{
			if (platform == Platform.Android) {
				return ConfigureApp.Android.StartApp ();
			}
				
			return ConfigureApp.iOS.StartApp ();
		}

		public static IApp StartApp (Platform platform, AppDataMode appDataMode)
		{
			if (platform == Platform.Android) {
				return ConfigureApp.Android.StartApp (appDataMode);
			}

			return ConfigureApp.iOS.StartApp (appDataMode);
		}
	}
}

