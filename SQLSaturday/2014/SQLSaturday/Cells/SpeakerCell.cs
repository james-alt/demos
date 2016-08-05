using System;
using Xamarin.Forms;

namespace SQLSaturday
{

	public class SpeakerCell : ViewCell
	{
		public SpeakerCell ()
		{
			var nameLabel = new Label {
				Style = StyleKit.LightLabelStyles.Body,
				VerticalOptions = LayoutOptions.Center,
			};
			nameLabel.SetBinding (Label.TextProperty, "Name");

			var cellLayout = new StackLayout {
				Spacing = 0,
				HeightRequest = 35,
				Padding = new Thickness(10, 5, 0, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { nameLabel }
			};

			View = cellLayout;
		}
	}
	
}
