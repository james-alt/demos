using Xamarin.Forms;

namespace IoCDemo
{
	public class HomePage : ViewPage<HomeViewModel>
	{
		public HomePage ()
		{
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {					
					new Label {
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Text = ViewModel.HelloText 
					}
				}
			};
		}
	}
}