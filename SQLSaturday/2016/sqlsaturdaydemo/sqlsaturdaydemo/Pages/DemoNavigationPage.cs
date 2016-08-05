using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace sqlsaturdaydemo
{

	public class DemoNavigationPage : NavigationPage
	{
		public DemoNavigationPage (Page root) : base(root)
		{
			Title = root.Title;
			Icon = root.Icon;
		}
	}
}
