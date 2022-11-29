using System;
namespace Internship_3_OOP_Calendar
{
	class Event
	{
		public Guid Id;
		public string EventName;
		public string Location;
		public DateTime Beginning;
		public DateTime Ending;
		public List<string> Emails;
		public Event(Guid id, string eventName, string location, DateTime beginning, DateTime ending, List<string> email)
		{
			Id = id;
			EventName = eventName;
			Location = location;
			Beginning = beginning;
			Ending = ending;
			Emails = email;
		}
	}
}

