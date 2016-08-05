using NUnit.Framework;
using SQLSaturday.Data;
using Moq;
using System;

namespace SQLSaturday.Tests
{
	[TestFixture]
	public class AppConfigTests
	{
		private Mock<ISettingsService> _settingsServiceMock;

		[SetUp]
		public void Init()
		{
			_settingsServiceMock = new Mock<ISettingsService> ();
		}

		[TearDown]
		public void TearDown()
		{
			_settingsServiceMock = null;
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullSettingsServiceThrowsArgumentNullException()
		{
			var appConfig = new AppConfig (null);
		}

		[Test]
		public void ConstructorSuccess()
		{
			var appConfig = new AppConfig (_settingsServiceMock.Object);

			Assert.IsNotNull (appConfig);
		}

		[Test]
		public void GuidebookAddress()
		{
			_settingsServiceMock.Setup (t => t.ConferenceIdentifier).Returns ("423");

			var appConfig = CreateAppConfig ();
			const string guidebookAddress = "http://www.sqlsaturday.com/eventxml.aspx?sat=";
			var conferenceString = guidebookAddress + appConfig.ConferenceIdentifier;

			Assert.AreEqual (conferenceString, appConfig.GuidebookAddress);
		}

		#region Helpers

		private AppConfig CreateAppConfig()
		{
			return new AppConfig (_settingsServiceMock.Object);
		}

		#endregion
	}
}