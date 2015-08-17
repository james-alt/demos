using Foundation;
using UIKit;

namespace SQLSaturday.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB (139, 195, 74);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.SetTitleTextAttributes (new UITextAttributes () {
				Font = IsIos82 
					? UIFont.SystemFontOfSize(20.0f, UIFontWeight.Light)
					: UIFont.FromName("HelveticaNeue-Light", 20.0f),
				TextColor = UIColor.White
			});



			#if ENABLE_TEST_CLOUD

			Xamarin.Forms.Forms.ViewInitialized += (sender, e) => {
				if (e.View.StyleId != null) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
				}
			};

			#endif

			LoadApplication (new App (new Setup()));

			UIApplication.SharedApplication.SetStatusBarStyle (UIStatusBarStyle.LightContent, false);
			UIApplication.SharedApplication.SetStatusBarHidden (false, UIStatusBarAnimation.Slide);

			return base.FinishedLaunching (app, options);
		}

		public static bool IsIos82
		{
			get {
				return UIDevice.CurrentDevice.CheckSystemVersion (8, 2);
			}
		}
	}
}

