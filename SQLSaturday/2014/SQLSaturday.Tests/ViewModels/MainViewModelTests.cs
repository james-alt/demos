using NUnit.Framework;
using Moq;
using SQLSaturday.Data;
using Autofac;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SQLSaturday.Tests
{
	[TestFixture]
	public class MainViewModelTests
	{
		private Mock<IDataClient> _dataClientMock;
		private Mock<IAppConfig> _appConfigMock;

		[SetUp]
		public void Init()
		{			
			_dataClientMock = new Mock<IDataClient> ();
			_appConfigMock = new Mock<IAppConfig> ();
		}

		[TearDown]
		public void CleanUp()
		{
			_dataClientMock = null;
			_appConfigMock = null;
		}

		#region Constructor

		[Test]
		public void ConstructorSuccess()
		{
			InitializeDependencies ();
			var viewModel = new MainViewModel (_dataClientMock.Object, _appConfigMock.Object);

			Assert.IsNotNull (viewModel);
		}			

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullDataClientThrowsArgumentNullException()
		{
			new MainViewModel (null, _appConfigMock.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullAppConfigThrowsArgumentNullException()
		{
			new MainViewModel (_dataClientMock.Object, null);
		}

		#endregion

		#region LoadConference

		[Test]
		public async Task LoadConferenceSetsConferenceOnSuccess()
		{
			var viewModel = CreateViewModel ();
			var expectedConference = CreateConference ();
			_dataClientMock.Setup (t => t.GetCachableConferenceAsync ()).ReturnsAsync (expectedConference);
			await viewModel.LoadConference ();

			Assert.AreEqual (expectedConference, viewModel.Conference);
		}

		[Test]
		public async Task LoadConferenceSetsSessionViewModelSessionsOnSuccess()
		{
			var viewModel = CreateViewModel ();
			var expectedConference = CreateConference ();
			_dataClientMock.Setup (t => t.GetCachableConferenceAsync ()).ReturnsAsync (expectedConference);
			await viewModel.LoadConference ();

			SessionsViewModel sessionsViewModel;
			using (var scope = AppContainer.Container.BeginLifetimeScope ()) {
				sessionsViewModel = AppContainer.Container.Resolve<SessionsViewModel> ();
			}

			Assert.AreEqual (sessionsViewModel.Sessions, expectedConference.Sessions);
		}

		[Test]
		public async Task LoadConferenceSetsSpeakersViewModelSpeakersOnSuccess()
		{
			var viewModel = CreateViewModel ();
			var expectedConference = CreateConference ();
			_dataClientMock.Setup (t => t.GetCachableConferenceAsync ()).ReturnsAsync (expectedConference);
			await viewModel.LoadConference ();

			SpeakersViewModel speakersViewModel;
			using (var scope = AppContainer.Container.BeginLifetimeScope ()) {
				speakersViewModel = AppContainer.Container.Resolve<SpeakersViewModel> ();
			}

			Assert.AreEqual (speakersViewModel.Speakers, expectedConference.Speakers);
		}

		[Test]
		public async Task LoadConferenceSetsTracksViewModelTracksOnSuccess()
		{
			var viewModel = CreateViewModel ();
			var expectedConference = CreateConference ();
			_dataClientMock.Setup (t => t.GetCachableConferenceAsync ()).ReturnsAsync (expectedConference);
			await viewModel.LoadConference ();

			TracksViewModel tracksViewModel;
			using (var scope = AppContainer.Container.BeginLifetimeScope ()) {
				tracksViewModel = AppContainer.Container.Resolve<TracksViewModel> ();
			}

			Assert.AreEqual (tracksViewModel.Tracks, expectedConference.Tracks);
		}

		#endregion

		#region IsConferenceSelected

		[Test]
		public void IsConferenceSelectedReturnsFalseOnEmptyString()
		{
			_appConfigMock.Setup (t => t.ConferenceIdentifier).Returns (string.Empty);
			var viewModel = CreateViewModel ();

			Assert.IsFalse (viewModel.IsConferenceSelected);
		}

		[Test]
		public void IsConferenceSelectedReturnsFalseOnNull()
		{
			_appConfigMock.Setup (t => t.ConferenceIdentifier).Returns (() => null);
			var viewModel = CreateViewModel ();

			Assert.IsFalse (viewModel.IsConferenceSelected);
		}

		[Test]
		public void IsConferenceSelectedReturnsTrueWhenNotNullOrEmpty()
		{
			_appConfigMock.Setup (t => t.ConferenceIdentifier).Returns ("1234");
			var viewModel = CreateViewModel ();

			Assert.IsTrue (viewModel.IsConferenceSelected);
		}

		#endregion

		#region SetConferenceIdentifier

		[Test]
		public void SetConferenceIdentifierCallsDataClientGetCachableConferenceAsync()
		{
			var viewModel = CreateViewModel ();
			viewModel.SetConferenceIdentifier ("something");
			_dataClientMock.Verify (t => t.GetCachableConferenceAsync (), Times.Once);
		}

		[Test]
		public void SetConferenceIdentifierCallsAppConfigConferenceIdentifier()
		{
			var viewModel = CreateViewModel ();
			viewModel.SetConferenceIdentifier ("something");
			_appConfigMock.VerifySet (t => t.ConferenceIdentifier=It.IsAny<string>());
		}

		#endregion

		#region Helpers

		private MainViewModel CreateViewModel()
		{
			InitializeDependencies ();
			return new MainViewModel (_dataClientMock.Object, _appConfigMock.Object);
		}

		private void InitializeDependencies()
		{
			var containerBuilder = new ContainerBuilder ();

			containerBuilder.RegisterType<SessionsViewModel>().SingleInstance();
			containerBuilder.RegisterType<SpeakersViewModel>().SingleInstance();
			containerBuilder.RegisterType<TracksViewModel>().SingleInstance();

			AppContainer.Container = containerBuilder.Build ();
		}

		private Conference CreateConference()
		{
			var conference = new Conference ();
			conference.Sessions = new List<Session> () {
				new Session(),
				new Session(),
				new Session()
			};
			conference.Speakers = new List<Speaker> () {
				new Speaker(),
				new Speaker()
			};
			conference.Tracks = new List<Track> () {
				new Track (),
				new Track (),
				new Track ()
			};
			return conference;
		}

		#endregion
	}
}

