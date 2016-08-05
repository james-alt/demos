using System;
using System.Collections.Generic;
using System.Linq;
namespace sqlsaturdaydemo
{
	public class MockSessionStore
	{
		private static MockSessionStore _instance;
		public static MockSessionStore Instance {
			get {
				if (_instance == null) {
					_instance = new MockSessionStore ();
				}
				return _instance;
			}
		}

		private List<Session> _sessions = new List<Session> ();

		private MockSessionStore ()
		{
			var speakerStore = MockSpeakerStore.Instance;
			var speakers = speakerStore.GetSpeakers ().ToArray();
			var speaker = 0;
			var speakerCount = 0;

			for (var i = 0; i < SessionNames.Length; i++) {
				var sessionSpeakers = new List<Speaker> ();
				speakerCount++;

				for (var j = 0; j < speakerCount; j++) {
					sessionSpeakers.Add (speakers [speaker]);
					speaker++;
					if (speaker >= speakers.Length)
						speaker = 0;
				}

				_sessions.Add (new Session {
					Id = i.ToString(),
					Name = SessionNames[i],
					Speakers = sessionSpeakers,
					Description = "Everyone likes a good session description, and this one is no different. Oh wait, it's very different, because it isn't real!"
				});

				if (speakerCount > 2)
					speakerCount = 0;
			}
		}

		public IEnumerable<Session> GetSessions ()
		{
			return _sessions;
		}

		public Session GetSession (string id)
		{
			return _sessions.SingleOrDefault (p => p.Id == id);
		}

		private static readonly string [] SessionNames =
		{
			"Advanced Topics in F#",
			"Aurelia - What is it and how does it compare to the rest?",
			"Automating Deployments with Octopus Deploy",
			"Beauty and the Bits: Why both Left and Right Brain MUST be Engaged",
			"Beginning T-SQL",
			"Careers in IT",
			"Coaching and Mentoring",
			"Continuous Integration and Delivery",
			"Creating Cross-Platform Mobile Applications with Xamarin",
			"Effortless Backups with Minion Backup",
			"Digging Into ASP.NET Core 1",
			"Planning Your SharePoint Online Migration Strategy",
			"Monitoring Databses in a Virtual Environment",
			"Optimizing Backup and Restore Performance in SQL Server",
			"Making the Most of the SSIS Catalog",
			"Just Use Forms Already!",
			"Introduction to Biml",
			"Indexes and Execution Plans",
			"Hostile Takeover",
			"Giving Feedback: How to Effectively Communicate to your Employees",
			"From Here to Azure: The Journey of Data",
			"Rx for Demystifying Index Tuning Decisions",
			"Scripting with C# and scriptcs",
			"SQL Server Internals",
			"SQLSaturday Jeopardy",
			"Startup 101: Lessons Learned",
			"The Binary Language of Music",
			"The Data Warehouse of the Future",
			"The M Word",
			"Unraveling Tangled Code: A Spellbinding Tale of Victory Over Chaos",
			"Using SQL to Avoid the SharePoint List Threshold",
			"Writing Functional Web Apps w/ Suave",
			"Zero to Hero with PowerShell and SQL Server in just half a day!"
		};
	}
	
}
