namespace IoCDemo
{
	public class CoreHelloFormsService : IHelloFormsService
	{		
		public string GetHelloFormsText ()
		{
			return "Hello From the Core!";
		}
	}
}