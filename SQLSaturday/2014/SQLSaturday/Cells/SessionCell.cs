using System;
using Xamarin.Forms;

namespace SQLSaturday
{

	public class SessionCell : ViewCell
	{
		public SessionCell ()
		{
			var nameLabel = new Label {
				Style = StyleKit.LightLabelStyles.Body,
			};
			nameLabel.SetBinding (Label.TextProperty, "Title");

			var speakersLabel = new Label {
				Style = StyleKit.LightLabelStyles.Caption
			};
			speakersLabel.SetBinding (Label.TextProperty, "SpeakerNames");

			var roomLabel = new Label {
				Style = StyleKit.LightLabelStyles.Caption
			};
			roomLabel.SetBinding (Label.TextProperty, "Room");

			var cellLayout = new StackLayout {
				Spacing = 0,
				Padding = new Thickness(15, 5, 0, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { nameLabel, speakersLabel, roomLabel }
			};

			View = cellLayout;
		}
	}
	
}
