using System;
using Xamarin.Forms;

namespace SQLSaturday
{

	public class TrackCell : ViewCell
	{
		public TrackCell ()
		{
			var nameLabel = new Label {
				Style = StyleKit.LightLabelStyles.Body
			};
			nameLabel.SetBinding (Label.TextProperty, "Title");

			var sessionCountLabel = new Label {
				Style = StyleKit.LightLabelStyles.Caption
			};
			sessionCountLabel.SetBinding (Label.TextProperty, "FormattedSessionCount");

			var cellLayout = new StackLayout {
				Spacing = 0,
				Padding = new Thickness(10, 5, 0, 5),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { nameLabel, sessionCountLabel }
			};

			View = cellLayout;
		}
	}
}
