using Autofac;

namespace IoCDemo.iOS
{
	public class Setup : AppSetup
	{
		protected override void RegisterDependencies (ContainerBuilder cb)
		{
			base.RegisterDependencies (cb);

			cb.RegisterType<TouchHelloFormsService> ().As<IHelloFormsService> ();
		}
	}
}