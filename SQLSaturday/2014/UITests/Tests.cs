using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Configuration;

namespace SQLSaturday.UITests
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform, AppDataMode.Clear);
		}

		[Test]
		public void OpenRepl()
		{
			app.Repl ();
		}

		[Test]
		public void TestFirstRun()
		{
			app.WaitForElement (c => c.Marked ("button_submit"));
			app.Screenshot ("App Started");

			var results = app.Query(c => c.Marked("button_cancel"));
			Assert.IsEmpty (results);
					
			app.EnterText(c => c.Marked("text_conference"), "423.4");
			if (platform == Platform.iOS) {
				results = app.Query (c => c.Marked ("Done"));
				Assert.IsNotEmpty (results);
				app.Screenshot ("Done Button Showing");
				app.Tap (c => c.Marked ("Done"));
			}
			app.Tap (c => c.Marked ("button_submit"));
			results = app.Query(c => c.Marked("Error"));
			Assert.IsNotEmpty (results);

			app.Screenshot ("Error Text");

			app.Tap(c => c.Marked("OK"));
			app.EnterText(c => c.Marked("text_conference"), "423");
			if (platform == Platform.iOS) {
				app.Tap (c => c.Marked ("Done"));
			}
			app.Tap("button_submit");

			app.WaitForElement (c => c.Marked("Sessions"));
			app.Screenshot ("Main Page Shown");
		}

		[Test]
		public void TestSettingsButton()
		{
			app.WaitForElement (c => c.Marked ("button_submit"));
			app.Screenshot ("App Started");

			app.EnterText(c => c.Marked("text_conference"), "423");
			if (platform == Platform.iOS) {
				app.Tap (c => c.Marked ("Done"));
			}
			app.Tap(c => c.Marked("button_submit"));

			app.WaitForElement (c => c.Marked("Sessions"));
			app.Screenshot ("Main Page Shown");

			app.Tap (c => c.Marked ("Settings"));
			app.WaitForElement (c => c.Marked ("button_submit"));

			app.Screenshot ("Settings Shown");

			var results = app.Query (c => c.Marked ("button_cancel"));
			Assert.IsNotEmpty (results);

			app.Tap (c => c.Marked("button_cancel"));

			app.WaitForElement (c => c.Marked ("Sessions"));
			app.Screenshot ("Main Page Shown");
		}
	}
}

