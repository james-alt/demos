using Xamarin.Forms;

namespace sqlsaturdaydemo
{
	public partial class SessionsPage : ContentPage
	{
		public SessionsPage ()
		{
			InitializeComponent ();
			Title = "Sessions";
			BindingContext = new SessionsViewModel ();
		}
	}
}
