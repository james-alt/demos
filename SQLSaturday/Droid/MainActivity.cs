using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Graphics.Drawables;

namespace SQLSaturday.Droid
{
	[Activity (Label = "SQLSaturday.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			#if ENABLE_TEST_CLOUD
			Xamarin.Forms.Forms.ViewInitialized += (sender, e) => {
				if (!string.IsNullOrWhiteSpace(e.View.StyleId)) {
					e.NativeView.ContentDescription = e.View.StyleId;
				}
			};
			#endif

			LoadApplication (new App (new Setup()));

			if ((int)Build.VERSION.SdkInt >= 21) 
			{ 
				ActionBar.SetIcon ( new ColorDrawable (Resources.GetColor (Android.Resource.Color.Transparent))); 
			}
		}
	}
}

