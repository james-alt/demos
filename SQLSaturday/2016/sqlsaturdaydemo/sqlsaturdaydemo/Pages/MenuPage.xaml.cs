using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace sqlsaturdaydemo
{
	public partial class MenuPage : ContentPage
	{
		private DemoMasterDetailPage _rootPage;

		public MenuPage (DemoMasterDetailPage rootPage)
		{
			_rootPage = rootPage;
			Title = "Menu";
			InitializeComponent ();

			NavView.NavigationItemSelected += NavViewOnNavigationItemSelected;
		}

		private void NavViewOnNavigationItemSelected (object sender, sqlsaturdaydemo.NavigationItemSelectedEventArgs e)
		{
			_rootPage.IsPresented = false;
			Device.StartTimer (TimeSpan.FromMilliseconds (300), () => {
				Device.BeginInvokeOnMainThread (async () => {
					await _rootPage.NavigateAsync (e.Index);
				});
				return false;
			});
		}
	}
}
