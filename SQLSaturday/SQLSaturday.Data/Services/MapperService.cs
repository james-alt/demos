using System.Collections.Generic;
using System.Linq;

namespace SQLSaturday.Data
{
	public class MapperService : IMapperService
	{
		public Conference MapGuidebookToConference (GuidebookDto guidebook)
		{
			guidebook.ThrowIfNull ("guidebook");

			var conference = new Conference ();
			conference.Sessions = GetConferenceSessions (guidebook);
			conference.Speakers = GetConferenceSpeakers (guidebook);
			conference.Tracks = GetConferenceTracks (conference.Sessions);

			return conference;
		}

		public IList<Session> GetConferenceSessions(GuidebookDto guidebook)
		{
			guidebook.ThrowIfNull ("guidebook");
			var sessions = new List<Session> ();

			if (guidebook.Events != null) {
				foreach (var item in guidebook.Events.Events.Where(t => t != null)) {
					var session = MapEventDtoToSession (item);
					sessions.Add (session);
				}
			}

			return sessions;
		}

		public IList<Speaker> GetConferenceSpeakers(GuidebookDto guidebook)
		{
			guidebook.ThrowIfNull ("guidebook");
			var speakers = new List<Speaker> ();

			if (guidebook.Speakers != null) {
				foreach(var item in guidebook.Speakers.Speakers.Where(t => t != null).Distinct()) {
					var speaker = MapSpeakerDtoToSpeaker (item);
					speakers.Add (speaker);
				}
			}

			return speakers;
		}

		public IList<Track> GetConferenceTracks(IList<Session> sessions) 
		{
			sessions.ThrowIfNull ("sessions");
			var tracks = new List<Track> ();

			var distinctTrackNames = sessions.Select (p => p.Track).Distinct ();
			foreach (var name in distinctTrackNames) {
				var track = new Track { Title = name };
				var trackSessions = sessions.Where (p => p.Track == name).ToList ();
				if (trackSessions != null && trackSessions.Any ()) {
					track.Sessions = trackSessions;
					tracks.Add (track);
				}
			}

			return tracks;
		}

		public Session MapEventDtoToSession(EventDto currentEvent)
		{
			currentEvent.ThrowIfNull ("currentEvent");

			var session = new Session {
				Id = currentEvent.ImportID,
				Title = currentEvent.Title,
				Description = currentEvent.Description,
				Track = currentEvent.Track,
				Room = currentEvent.Location.Name,
				StartTime = currentEvent.StartTime,
				EndTime = currentEvent.EndTime
			};

			session.Speakers = new List<Speaker> ();
			if (currentEvent.Speakers != null && currentEvent.Speakers.Speakers != null) {
				foreach (var speaker in currentEvent.Speakers.Speakers) {
					session.Speakers.Add (MapSpeakerDtoToSpeaker (speaker));
				}
			}

			return session;
		}

		public Speaker MapSpeakerDtoToSpeaker(SpeakerDto currentSpeaker)
		{
			currentSpeaker.ThrowIfNull ("speaker");

			var speaker = new Speaker {
				Id = currentSpeaker.ImportId,
				Name = currentSpeaker.Name,
				Description = currentSpeaker.Description,
				Twitter = currentSpeaker.Twitter,
				LinkedIn = currentSpeaker.LinkedIn,
				ContactUrl = currentSpeaker.ContactUrl,
				ImageUrl = currentSpeaker.ImageUrl
			};

			return speaker;
		}
	}
}

