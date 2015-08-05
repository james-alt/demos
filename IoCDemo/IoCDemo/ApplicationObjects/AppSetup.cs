using Autofac;

namespace IoCDemo
{
	public class AppSetup
	{
		public IContainer CreateContainer() {
			var containerBuilder = new ContainerBuilder();
			RegisterDependencies (containerBuilder);
			return containerBuilder.Build ();
		}

		protected virtual void RegisterDependencies(ContainerBuilder cb) {
			// Register Services
			cb.RegisterType<CoreHelloFormsService>().As<IHelloFormsService>();

			// Register View Models
			cb.RegisterType<HomeViewModel>().SingleInstance();
		}
	}
}