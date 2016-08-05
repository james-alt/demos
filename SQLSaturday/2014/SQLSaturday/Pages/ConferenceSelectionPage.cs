using Xamarin.Forms;
using System;

namespace SQLSaturday
{
	public class ConferenceSelectionPage : ViewPage<ConferenceSelectionViewModel>
	{
		public event Action<string> Dismissed;
		private string _conferenceIdentifier;

		public ConferenceSelectionPage (string identifier)
		{
			Title = "Conference";
			ViewModel.ConferenceIdentifier = identifier;
			_conferenceIdentifier = ViewModel.ConferenceIdentifier;

			var label = new Label {
				StyleId = "label_instructions",
				Style = StyleKit.DarkLabelStyles.Action,
				Text = "Please enter the number for the SQL Saturday you will be attending.",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				XAlign = TextAlignment.Center,
			};

			var conferenceEntry = new DoneEntry {
				StyleId = "text_conference",
				Placeholder = "Conference #",
				Keyboard = Keyboard.Numeric,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				TextColor = Device.OnPlatform(Colors.SecondaryTextColor, Colors.TextColor, Colors.TextColor)
			};
			conferenceEntry.SetBinding (Entry.TextProperty, "ConferenceIdentifier");

			var buttonStack = CreateButtonStack (!string.IsNullOrEmpty (_conferenceIdentifier));

			var innerStackLayout = new StackLayout {
				Padding = new Thickness(20, 45, 20, 5),
				Spacing = 30,
				Orientation = StackOrientation.Vertical,
				Children = { label, conferenceEntry, buttonStack }
			};

			var stackLayout = new StackLayout {
				BackgroundColor = Colors.DarkPrimaryColor,
				Children = { innerStackLayout }
			};

			Content = stackLayout;
		}

		async void SubmitButtonClicked (object sender, EventArgs e)
		{			
			if (ViewModel.IsIdentifierValid) {
				if (Dismissed != null) {
					Dismissed (ViewModel.ConferenceIdentifier);
				}
			} else {
				await DisplayAlert (
					"Error", 
					"The value for the SQL Saturday must be a numeric value with no decimal places.", 
					"OK");
				ViewModel.ConferenceIdentifier = string.Empty;
			}
		}

		void CancelButtonClicked(object sender, EventArgs e) 
		{
			if (Dismissed != null) {
				Dismissed (_conferenceIdentifier);
			}
		}			

		#region UI Helpers

		private StackLayout CreateButtonStack(bool showCancelButton)
		{
			var button = new Button {
				StyleId = "button_submit",
				Text = "Submit",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Colors.AccentColor,
				TextColor = Color.White
			};
			button.Clicked += SubmitButtonClicked;

			var stackLayout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Children = { button }
			};
			if (showCancelButton) {
				var cancelButton = new Button {
					StyleId = "button_cancel",
					Text = "Cancel",
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Colors.CancelColor,
					TextColor = Color.White
				};
				cancelButton.Clicked += CancelButtonClicked;
				stackLayout.Children.Add (cancelButton);
			}
			return stackLayout;
		}

		#endregion
	}
}

