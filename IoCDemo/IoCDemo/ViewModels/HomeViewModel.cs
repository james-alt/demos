namespace IoCDemo
{
	public class HomeViewModel : IViewModel
	{
		public HomeViewModel (IHelloFormsService formsService)
		{
			HelloText = formsService.GetHelloFormsText ();
		}

		public string HelloText { get; set; }
	}
}