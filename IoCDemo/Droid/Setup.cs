using Autofac;

namespace IoCDemo.Droid
{
	public class Setup : AppSetup
	{
		protected override void RegisterDependencies (ContainerBuilder cb)
		{
			base.RegisterDependencies (cb);

			cb.RegisterType<DroidHelloFormsService> ().As<IHelloFormsService> ();
		}
	}
}