using NUnit.Framework;
using Ploeh.AutoFixture;
using Moq;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace SQLSaturday.Data.Tests
{
	[TestFixture]
	public class DataClientTests
	{
		private Fixture _fixture;
		private DataClient _dataClient;

		private Mock<IMapperService> _mapperServiceMock;
		private Mock<IConnectivityService> _connectivityServiceMock;
		private Mock<ISerializerService> _serializerServiceMock;
		private Mock<IHttpService> _httpServiceMock;
		private Mock<IAppConfig> _appConfigMock;

		[SetUp]
		public void Init()
		{
			_fixture = new Fixture ();

			_mapperServiceMock = new Mock<IMapperService> ();
			_connectivityServiceMock = new Mock<IConnectivityService> ();
			_serializerServiceMock = new Mock<ISerializerService> ();
			_httpServiceMock = new Mock<IHttpService> ();
			_appConfigMock = new Mock<IAppConfig> ();
		}

		[TearDown]
		public void Cleanup()
		{
			_fixture = null;

			_mapperServiceMock = null;
		}

		#region Constructor

		[Test]
		public void ConstructorSuccess()
		{
			var dataClient = CreateDataClient ();

			Assert.IsNotNull (dataClient);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullMapperServiceThrowsArgumentNullException()
		{
			var dataClient = CreateDataClient (null, 
				_connectivityServiceMock.Object, _serializerServiceMock.Object,
				_httpServiceMock.Object, _appConfigMock.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullConnectivityServiceThrowsArgumentNullException()
		{
			var dataClient = CreateDataClient (_mapperServiceMock.Object, 
				null, _serializerServiceMock.Object, 
				_httpServiceMock.Object, _appConfigMock.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullSerializerServiceThrowsArgumentNullException()
		{
			var dataClient = CreateDataClient (_mapperServiceMock.Object, 
				_connectivityServiceMock.Object, null, 
				_httpServiceMock.Object, _appConfigMock.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullHttpServiceThrowsArgumentNullException()
		{
			var dataClient = CreateDataClient (_mapperServiceMock.Object, 
				_connectivityServiceMock.Object, _serializerServiceMock.Object, 
				null, _appConfigMock.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorNullAppConfigThrowsArgumentNullException()
		{
			var dataClient = CreateDataClient (_mapperServiceMock.Object, 
				_connectivityServiceMock.Object, _serializerServiceMock.Object, 
				_httpServiceMock.Object, null);
		}

		#endregion

		#region GetRemoteConferenceAsync

		[Test]
		public async Task GetRemoteConferenceAsyncDoesNotReturnNullConference()
		{
			var dataClient = CreateDataClient ();
			var conference = await dataClient.GetRemoteConferenceAsync ();

			Assert.IsNotNull (conference);
		}

		[Test]
		public async Task GetRemoteConferenceAsyncReturnsNewConferenceWhenNotConnected()
		{
			_connectivityServiceMock.Setup (t => t.IsConnected).Returns (false);
			var dataClient = CreateDataClient ();
			var conference = await dataClient.GetRemoteConferenceAsync ();

			Assert.IsEmpty (conference.Sessions);
			Assert.IsEmpty (conference.Speakers);
		}

		[Test]
		public async Task GetRemoteConferenceAsyncReturnsNewConferenceWhenHttpServiceThrowsException()
		{
			_connectivityServiceMock.Setup (t => t.IsConnected).Returns (true);
			_httpServiceMock.Setup (t => t.GetResponseAsync (It.IsAny<string> ()))
				.ThrowsAsync (new Exception ());

			var dataClient = CreateDataClient ();
			var conference = await dataClient.GetRemoteConferenceAsync ();

			Assert.IsEmpty (conference.Sessions);
			Assert.IsEmpty (conference.Speakers);
		}

		[Test]
		public async Task GetRemoteConferenceAsyncReturnsConferenceOnSuccess()
		{	
			var expectedConference = CreateConference ();
			_connectivityServiceMock.Setup (t => t.IsConnected).Returns (true);
			_httpServiceMock.Setup (t => t.GetResponseAsync (It.IsAny<string> ()))
				.ReturnsAsync (new MemoryStream());
			_serializerServiceMock.Setup (t => t.Deserialize<GuidebookDto> (It.IsAny<Stream> ()))
				.ReturnsAsync (CreateGuidebookDto ());
			_mapperServiceMock.Setup (t => t.MapGuidebookToConference (It.IsAny<GuidebookDto> ()))
				.Returns (expectedConference);

			var dataClient = CreateDataClient ();
			var conference = await dataClient.GetRemoteConferenceAsync ();

			Assert.AreEqual (conference, expectedConference);
		}

		#endregion

		#region Helpers

		private DataClient CreateDataClient()
		{
			return CreateDataClient (_mapperServiceMock.Object,
				_connectivityServiceMock.Object, 
				_serializerServiceMock.Object,
				_httpServiceMock.Object,
				_appConfigMock.Object);
		}

		private DataClient CreateDataClient(IMapperService mapperService, 
			IConnectivityService connectivityService, 
			ISerializerService serializerService,
			IHttpService httpService,
			IAppConfig appConfig)
		{
			return new DataClient (mapperService, connectivityService, serializerService, httpService, appConfig);
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
			return conference;
		}

		private GuidebookDto CreateGuidebookDto()
		{
			var dto = new GuidebookDto ();

			dto.Speakers = _fixture.Create<SpeakersDto> ();

			dto.Events = new EventsDto ();
			dto.Events.Events = new List<EventDto> {
				CreateEventDto(),
				CreateEventDto(),
				CreateEventDto()
			};

			return dto;
		}

		private EventDto CreateEventDto()
		{
			return _fixture.Build<EventDto> ()
				.Without (p => p.StartTimeString)
				.Without (p => p.EndTimeString)
				.Create ();
		}

		#endregion
	}
}

