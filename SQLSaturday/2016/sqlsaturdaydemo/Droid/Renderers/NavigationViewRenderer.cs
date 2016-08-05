using System;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using sqlsaturdaydemo;
using sqlsaturdaydemo.Droid;
using NavigationView = Android.Support.Design.Widget.NavigationView;
using View = Android.Views.View;
using Xamarin.Forms;
using Android.Support.Design.Widget;

[assembly: ExportRenderer(typeof(sqlsaturdaydemo.DemoNavigationView), typeof(NavigationViewRenderer))]
namespace sqlsaturdaydemo.Droid
{
	public class NavigationViewRenderer : ViewRenderer<DemoNavigationView, NavigationView>
	{
		private NavigationView _navigationView;
		private IMenuItem _previousMenuItem;

		protected override void OnElementChanged (ElementChangedEventArgs<DemoNavigationView> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement != null || Element == null)
				return;

			var view = Inflate (Forms.Context, Resource.Layout.nav_view, null);
			_navigationView = view.JavaCast<NavigationView> ();
			_navigationView.NavigationItemSelected += NavigationViewOnNavigationItemSelected;

			SetNativeControl (_navigationView);

			_navigationView.SetCheckedItem (Resource.Id.nav_home);
		}

		private void NavigationViewOnNavigationItemSelected (object sender, NavigationView.NavigationItemSelectedEventArgs navigationItemSelectedEventArgs)
		{
			_previousMenuItem?.SetChecked (false);

			_navigationView.SetCheckedItem (navigationItemSelectedEventArgs.MenuItem.ItemId);
			_previousMenuItem = navigationItemSelectedEventArgs.MenuItem;

			var pageId = 0;
			switch (navigationItemSelectedEventArgs.MenuItem.ItemId) {
			case Resource.Id.nav_home:
				pageId = 0;
				break;
			}

			Element.OnNavigationItemSelected (new NavigationItemSelectedEventArgs () { Index = pageId });
		}

		public override void OnViewRemoved (View child)
		{
			base.OnViewRemoved (child);
			_navigationView.NavigationItemSelected -= NavigationViewOnNavigationItemSelected;
		}
	}
}
