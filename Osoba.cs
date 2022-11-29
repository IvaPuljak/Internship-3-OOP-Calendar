using System;
namespace Internship_3_OOP_Calendar
{
	class Person
	{
        public string Name;
        public string Surname;
        public string Email;
        public Dictionary<Guid, bool> Presence;
        public Person(string name, string surname, string email, Dictionary<Guid,bool> presence)
		{
            Name = name;
            Surname = surname;
            Email = email;
            Presence = presence;
		}
	}
}

