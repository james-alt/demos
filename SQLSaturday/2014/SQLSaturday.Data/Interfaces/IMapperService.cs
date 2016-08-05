using System.Collections.Generic;

namespace SQLSaturday.Data
{
	public interface IMapperService
	{
		Conference MapGuidebookToConference(GuidebookDto guidebook);
		IList<Session> GetConferenceSessions (GuidebookDto guidebook);
		IList<Speaker> GetConferenceSpeakers(GuidebookDto guidebook);
		IList<Track> GetConferenceTracks (IList<Session> sessions);
		Session MapEventDtoToSession (EventDto currentEvent);
		Speaker MapSpeakerDtoToSpeaker(SpeakerDto currentSpeaker);
	}
}