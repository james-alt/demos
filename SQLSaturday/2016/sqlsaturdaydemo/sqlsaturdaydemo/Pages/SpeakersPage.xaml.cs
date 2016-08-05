using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace sqlsaturdaydemo
{
	public partial class SpeakersPage : ContentPage
	{
		public SpeakersPage ()
		{
			InitializeComponent ();
			Title = "Speakers";
			BindingContext = new SpeakersViewModel ();
		}
	}
}
