using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace sqlsaturdaydemo
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			Title = "Home";
		}

		private async void AlertClicked (object sender, EventArgs e)
		{
			await DisplayAlert ("This is an Alert", "YOU CLICKED IT!", "Done");
		}

		private async void GridClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new GridPage ());
		}

		private async void DependencyClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new DependencyPage ());
		}

		private void StepperValueChanged (object sender, ValueChangedEventArgs e)
		{
			Color color = Color.Lime;
			switch ((int)e.NewValue) {
			case 1:
				color = Color.Lime;
				break;
			case 2:
				color = Color.Blue;
				break;
			case 3:
				color = Color.Navy;
				break;
			case 4:
				color = Color.Purple;
				break;
			case 5:
				color = Color.Fuchsia;
				break;
			}

			boxView.BackgroundColor = color;
		}
	}
}
