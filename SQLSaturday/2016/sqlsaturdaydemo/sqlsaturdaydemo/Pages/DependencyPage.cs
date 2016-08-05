using System;

using Xamarin.Forms;
using Plugin.TextToSpeech;

namespace sqlsaturdaydemo
{
	public class DependencyPage : ContentPage
	{
		public DependencyPage ()
		{
			var label = new Label { Text = FirstTextBlock };

			var button = new Button {
				Text = "Dependency Locator",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex ("#8BC34A")
			};
			button.Clicked += (sender, e) => {
				ITextToSpeech speaker = DependencyService.Get<ITextToSpeech> ();
				if (speaker != null) {
					speaker.Speak (FirstTextBlock);
				}
			};

			var button2 = new Button {
				Text = "From Plugin",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex ("#8BC34A")
			};

			button2.Clicked += (sender, e) => {
				label.Text = SecondTextBlock;
				CrossTextToSpeech.Current.Speak (label.Text);
			};

			Content = new StackLayout {
				Padding = new Thickness(10),
				Spacing = 10,
				Children = {
					label,
					button,
					button2
				}
			};
		}


		#region Values

		private const string FirstTextBlock = "Good morning everyone. How awesome is this dependency locator?";
		private const string SecondTextBlock = "Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats and Boots and Cats";


		#endregion
	}
}

