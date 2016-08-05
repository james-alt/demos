using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sqlsaturdaydemo
{
	public class DemoTabbedPage : TabbedPage
	{
		public DemoTabbedPage ()
		{
			// The pages will have their own navigation, so hide the one on the tabbed page
			NavigationPage.SetHasNavigationBar (this, false);
			Children.Add (new DemoNavigationPage (new HomePage ()));
			Children.Add (new DemoNavigationPage (new SessionsPage ()));
			Children.Add (new DemoNavigationPage (new SpeakersPage ()));
		}
	}
}