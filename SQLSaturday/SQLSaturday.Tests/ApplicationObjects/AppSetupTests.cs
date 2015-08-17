using NUnit.Framework;
using Autofac;
using SQLSaturday.Data;
using System.Reflection;
using SQLSaturday;
using System;
using System.Linq;

namespace SQLSaturday.Tests
{
	[TestFixture]
	public class AppSetupTests
	{
		private AppSetup _appSetup;

		[SetUp]
		public void Init()
		{
			_appSetup = new AppSetup ();
		}

		[TearDown]
		public void Cleanup()
		{
			_appSetup = null;
		}

		[Test]
		public void CreateContainerRegistersAllViewModels()
		{
			var container = _appSetup.CreateContainer ();

			var expectedType = typeof(IViewModel);
			var found = 0;
			var assembly = Assembly.Load ("SqlSaturday");
			var types = assembly.GetTypes ()
				.Where (t => expectedType.IsAssignableFrom (t) && t.IsClass && t != typeof(BaseViewModel));

			foreach (var type in types) {
				Assert.IsTrue (container.IsRegistered (type));
				found++;
			}

			Assert.AreNotEqual (found, 0);
		}

		[Test]
		public void CreateContainerRegistersAppConfig()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered (typeof(IAppConfig)));
		}

		[Test]
		public void CreateContainerRegistersMapperService()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered (typeof(IMapperService)));
		}

		[Test]
		public void CreateContainerRegistersConnectivityService()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered (typeof(IConnectivityService)));
		}

		[Test]
		public void CreateContainerRegistersHttpService()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered (typeof(IHttpService)));
		}

		[Test]
		public void CreateContainerRegistersSerializerService()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered (typeof(ISerializerService)));
		}

		[Test]
		public void CreateContainerRegistersDataClient()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered (typeof(IDataClient)));
		}

		[Test]
		public void CreateContainerRegistersSettingsService()
		{
			var container = _appSetup.CreateContainer ();

			Assert.IsTrue (container.IsRegistered(typeof(ISettingsService)));
		}
	}
}

