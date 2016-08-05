using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sqlsaturdaydemo
{
	public class DemoMasterDetailPage : MasterDetailPage
	{
		Dictionary<int, DemoNavigationPage> _pages;

		public DemoMasterDetailPage ()
		{
			_pages = new Dictionary<int, DemoNavigationPage> ();
			Master = new MenuPage (this);

			_pages.Add (0, new DemoNavigationPage (new HomePage ()));
			Detail = _pages [0];
		}

		public async Task NavigateAsync (int menuItemId)
		{
			if (!_pages.ContainsKey (menuItemId)) {
				switch (menuItemId) {
				case 0:
					_pages.Add (menuItemId, new DemoNavigationPage (new HomePage ()));
					break;
				}
			}
			var newPage = _pages [menuItemId];
			if (newPage == null) {
				return;
			}

			if (Detail == newPage) {
				await newPage.Navigation.PopToRootAsync ();
			}

			Detail = newPage;
		}
	}
}