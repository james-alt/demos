using Autofac;
using SQLSaturday.Data;

namespace SQLSaturday
{
	public class AppSetup
	{
		public IContainer CreateContainer()
		{
			var containerBuilder = new ContainerBuilder ();
			RegisterDependencies (containerBuilder);
			return containerBuilder.Build ();
		}

		protected virtual void RegisterDependencies(ContainerBuilder cb) 
		{
			// Configuration
			cb.RegisterType<AppConfig>().As<IAppConfig>();

			// Services
			cb.RegisterType<MapperService>().As<IMapperService>();
			cb.RegisterType<ConnectivityService> ().As<IConnectivityService> ();
			cb.RegisterType<HttpService> ().As<IHttpService> ();
			cb.RegisterType<SerializerService> ().As<ISerializerService> ();
			cb.RegisterType<DataClient> ().As<IDataClient> ();
			cb.RegisterType<SettingsService> ().As<ISettingsService> ();

			// ViewModels
			cb.RegisterType<MainViewModel>().SingleInstance();
			cb.RegisterType<SessionsViewModel>().SingleInstance();
			cb.RegisterType<SpeakersViewModel>().SingleInstance();
			cb.RegisterType<TracksViewModel>().SingleInstance();
			cb.RegisterType<SessionViewModel>().SingleInstance();
			cb.RegisterType<SpeakerViewModel>().SingleInstance();
			cb.RegisterType<TrackViewModel>().SingleInstance();
			cb.RegisterType<ConferenceSelectionViewModel>().SingleInstance();

		}
	}
}