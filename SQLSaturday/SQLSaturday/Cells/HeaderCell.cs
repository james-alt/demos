using Xamarin.Forms;

namespace SQLSaturday
{
	public class HeaderCell : ViewCell
	{
		public HeaderCell ()
		{
			Height = Device.OnPlatform(25, 35, 25);
			var title = new Label {
				Style = StyleKit.LightLabelStyles.Body,
				VerticalOptions = LayoutOptions.Center
			};
			title.SetBinding (Label.TextProperty, "Key");

			View = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = Device.OnPlatform(25, 35, 25),
				BackgroundColor = Colors.LightPrimaryColor,
				Padding = new Thickness(10, 7, 5, 7),
				Orientation = StackOrientation.Horizontal,
				Children = { title }
			};
		}
	}
}