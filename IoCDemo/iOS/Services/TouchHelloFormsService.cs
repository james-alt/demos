namespace IoCDemo.iOS
{
	public class TouchHelloFormsService : IHelloFormsService
	{
		public string GetHelloFormsText ()
		{
			return "Hello from iOS!";
		}	
	}
}