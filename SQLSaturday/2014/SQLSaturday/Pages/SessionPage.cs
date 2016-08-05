using Xamarin.Forms;
using SQLSaturday.Data;

namespace SQLSaturday
{

	public class SessionPage : ViewPage<SessionViewModel>
	{
		public SessionPage (Session session)
		{
			Title = "Session";
			ViewModel.CurrentSession = session;

			var titleLabel = new Label {
				Text = session.Title
			};

			var stackLayout = new StackLayout {
				Padding = 10,
				Orientation = StackOrientation.Vertical,
				Children = { titleLabel }
			};

			Content = stackLayout;
		}
	}

}
