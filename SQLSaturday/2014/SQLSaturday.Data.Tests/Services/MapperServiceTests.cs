using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLSaturday.Data.Tests
{
	[TestFixture]
	public class MapperServiceTests
	{
		private MapperService _service;
		private Fixture _fixture;

		[SetUp]
		public void Init()
		{
			_service = new MapperService ();
			_fixture = new Fixture ();
		}

		[TearDown]
		public void Cleanup()
		{
			_service = null;
			_fixture = null;
		}

		#region MapGuidebookToConference

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MapGuidebookToConferenceNullGuidebookThrowsArgumentNullException()
		{
			_service.MapGuidebookToConference (null);
		}

		[Test]
		public void MapGuidebookToConferenceLoadsConferenceSessions()
		{
			var guidebook = CreateGuidebookDto ();
			var conference = _service.MapGuidebookToConference (guidebook);

			Assert.IsNotNull (conference.Sessions);
			Assert.AreEqual (conference.Sessions.Count, guidebook.Events.Events.Count);
		}

		[Test]
		public void MapGuidebookToConferenceLoadsConferenceSpeakers()
		{
			var guidebook = CreateGuidebookDto ();
			var conference = _service.MapGuidebookToConference (guidebook);

			Assert.IsNotNull (conference.Speakers);
			Assert.AreEqual (conference.Speakers.Count, guidebook.Speakers.Speakers.Count);
		}

		#endregion

		#region GetConferenceSessions

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetConferenceSessionsNullGuidebookThrowsArgumentNullException()
		{
			_service.GetConferenceSessions (null);
		}

		[Test]
		public void GetConferenceSessionsNullEventsReturnsEmptyList()
		{
			var guidebook = CreateGuidebookDto ();
			guidebook.Events = null;

			var sessions = _service.GetConferenceSessions (guidebook);
			Assert.IsEmpty (sessions);
		}

		[Test]
		public void GetConferenceSessionsGuidebookEventsCountMatchesSessionsCount()
		{
			var guidebook = CreateGuidebookDto ();
			var sessions = _service.GetConferenceSessions (guidebook);

			Assert.AreEqual (guidebook.Events.Events.Count, sessions.Count);
		}

		#endregion

		#region GetConferenceSpeakers

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetConferenceSpeakersNullGuidebookThrowsArgumentNullException()
		{
			_service.GetConferenceSpeakers (null);
		}

		[Test]
		public void GetConferenceSpeakersNullGuidebookSpeakersReturnsEmptyCollection()
		{
			var guidebook = CreateGuidebookDto ();
			guidebook.Speakers = null;

			var speakers = _service.GetConferenceSpeakers (guidebook);

			Assert.IsEmpty (speakers);
		}

		[Test]
		public void GetConferenceSpeakersGuidebookSpeakersCountMatchesSessionsCount()
		{
			var guidebook = CreateGuidebookDto ();
			var speakers = _service.GetConferenceSpeakers (guidebook);

			Assert.AreEqual (guidebook.Speakers.Speakers.Count, speakers.Count);
		}

		[Test]
		public void GetConferenceSpeakersGuidebookRemovesDuplicateSpeakers()
		{
			var guidebook = CreateGuidebookDto ();
			guidebook.Speakers.Speakers.Add (guidebook.Speakers.Speakers [0]);

			var speakers = _service.GetConferenceSpeakers (guidebook);

			Assert.AreEqual (guidebook.Speakers.Speakers.Count - 1, speakers.Count);
		}

		#endregion

		#region GetConferenceTracks

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetConferenceTracksNullSessionsThrowsArgumentNullException()
		{
			_service.GetConferenceTracks (null);
		}

		[Test]
		public void GetConferenceTracksEmptySessionsReturnsEmptyTrackList()
		{
			var sessions = new List<Session> ();
			var tracks = _service.GetConferenceTracks (sessions);

			Assert.IsEmpty (tracks);
		}

		[Test]
		public void GetConferenceTracksCountMatchesDistinctSessionTracks()
		{
			var sessions = CreateSessionsList ();
			var expectedTrackCount = sessions.Select (p => p.Track).Distinct ().Count();

			var tracks = _service.GetConferenceTracks (sessions);

			Assert.AreEqual (expectedTrackCount, tracks.Count);
		}

		#endregion

		#region MapEventDtoToSession

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MapEventDtoToSessionNullEventDtoThrowsArgumentNullException()
		{
			_service.MapEventDtoToSession (null);
		}

		[Test]
		public void MapEventDtoToSessionMapsEventToSession()
		{
			var eventDto = CreateEventDto ();
			var session = _service.MapEventDtoToSession (eventDto);

			Assert.AreEqual (eventDto.ImportID, session.Id);
			Assert.AreEqual (eventDto.Title, session.Title);
			Assert.AreEqual (eventDto.Description, session.Description);
			Assert.AreEqual (eventDto.Track, session.Track);
			Assert.AreEqual (eventDto.Location.Name, session.Room);
			Assert.AreEqual (eventDto.StartTime, session.StartTime);
			Assert.AreEqual (eventDto.EndTime, session.EndTime);
		}

		#endregion

		#region MapSpeakerDtoToSpeaker

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MapSpeakerDtoToSpeakerNullSpeakerDtoThrowsArgumentNullException()
		{
			_service.MapSpeakerDtoToSpeaker (null);
		}

		[Test]
		public void MapSpeakerDtoToSpeakerMapsSpeakerToSpeaker()
		{
			var speakerDto = CreateSpeakerDto ();
			var speaker = _service.MapSpeakerDtoToSpeaker (speakerDto);

			Assert.AreEqual (speakerDto.ImportId, speaker.Id);
			Assert.AreEqual (speakerDto.Name, speaker.Name);
			Assert.AreEqual (speakerDto.Description, speaker.Description);
			Assert.AreEqual (speakerDto.Twitter, speaker.Twitter);
			Assert.AreEqual (speakerDto.LinkedIn, speaker.LinkedIn);
			Assert.AreEqual (speakerDto.ContactUrl, speaker.ContactUrl);
			Assert.AreEqual (speakerDto.ImageUrl, speaker.ImageUrl);
		}

		#endregion

		#region Helper Methods

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

		private SpeakerDto CreateSpeakerDto()
		{
			return _fixture.Create<SpeakerDto> ();
		}

		private List<Session> CreateSessionsList()
		{
			var sessions = new List<Session> ();
			for (var i = 0; i < 20; i++) {
				var session = CreateSession ();
				sessions.Add (session);
				if (i % 2 == 0) {
					var session2 = CreateSession ();
					session2.Track = session.Track;
				}
			}
			return sessions;
		}

		private Session CreateSession()
		{
			return _fixture.Build<Session> ()
				.Without (p => p.Speakers)
				.Create ();
		}

		#endregion
	}
}

