using System.Collections;
using System.Collections.Generic;
using Internship_3_OOP_Calendar;
namespace app
{
    public class Program
    {
        static Guid GuidParser(string eventId)
        {
           while(true)
            {
                
                
                Guid eventIdValid;
                var isGuidValid = Guid.TryParse(eventId,out eventIdValid);
                if(isGuidValid)
                {
                    return eventIdValid;
                }

                Console.WriteLine("Taj event ne postoji - probaj opet: ");
                eventId = Console.ReadLine();
                
            }
        }

        static void Main(string[] args)
        {
            Event event1 = new Event(Guid.NewGuid(), "Rodendan", "Suhi potok", new DateTime(2022, 11, 25, 0, 0, 0), new DateTime(2022, 11, 25, 23, 59, 59), new List<string> { "matija.rodic@gmail.com", " karlo.nikic@gmail.com"});
            Event event2 = new Event(Guid.NewGuid(), "Godišnjica braka", "Radmanove Mlinice", new DateTime(2022, 11, 16, 0, 0, 0), new DateTime(2023, 1, 1, 0, 0, 0), new List<string> { "ana.barbi@gmail.com", " luka.lukic@gmail.com" });
            Event event3 = new Event(Guid.NewGuid(), "Rafting", "Cetina", new DateTime(2017, 7, 7, 16, 20, 0), new DateTime(2022, 7, 7, 22, 0, 0), new List<string> { "vlado.jaman@gmail.com", " niko.nikic@gmail.com" });
            Event event4 = new Event(Guid.NewGuid(), "Spoj", "Tortuga", new DateTime(2022, 12, 15, 20, 0, 0), new DateTime(2022, 12, 15, 22, 30, 0), new List<string> { "robi.rodic@gmail.com", " mile.stanic@gmail.com" });
            Event event5 = new Event(Guid.NewGuid(), "Dorucak", "Pazdigrad", new DateTime(2022, 11, 27, 9, 0, 0), new DateTime(2022, 11, 27, 10, 0, 0), new List<string> { "marija.vis@gmail.com", " ivica.poljak@gmail.com" });


            Person person1 = new Person("Iva", "Puljak", "iva.puljak@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,true }, {event2.Id,true}, {event3.Id,true},{event4.Id,false}, {event5.Id,true}
            });
            Person person2 = new Person("Ivana", "Ivanić", "ivana.ivanic@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,false},{event2.Id,true},{event3.Id,false},{event4.Id,true},{event5.Id,false}
            });
            Person person3 = new Person("Mate", "Matić", "mate.matic@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,true},{event2.Id,true},{event3.Id,false},{event4.Id,true},{event5.Id,false}
            });
            Person person4 = new Person("Luka", "Modrić", "luka.modric@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,false},{event2.Id,true},{event3.Id,true},{event4.Id,false},{event5.Id,false}
            });
            Person person5 = new Person("Domagoj", "Vida", "domagoj.vida@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,false},{event2.Id,false},{event3.Id,false},{event4.Id,true},{event5.Id,false}
            });
            Person person6 = new Person("Bartol", "Deak", "bartol.deak@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,true},{event2.Id,true},{event3.Id,true},{event4.Id,false},{event5.Id,true}
            });
            Person person7 = new Person("Matija", "Matić", "matija.matic@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,false},{event2.Id,true},{event3.Id,true},{event4.Id,true},{event5.Id,true}
            });
            Person person8 = new Person("Ema", "Luketin", "ema.luketin@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,true},{event2.Id,true},{event3.Id,false},{event4.Id,true},{event5.Id,false}
            });
            Person person9 = new Person("Nada", "Nadić", "nada.nadic@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,false},{event2.Id,true},{event3.Id,false},{event4.Id,true},{event5.Id,true}
            });
            Person person10 = new Person("Lana", "Lanis", "lana.lanis@gmail.com", new Dictionary<Guid, bool>()
            {
                {event1.Id,true},{event2.Id,false},{event3.Id,false},{event4.Id,true},{event5.Id,true}
            });

            var InocomingEvents = new List<Event>();

            var Events = new List<Event>()
            {
                event1, event2, event3, event4, event5
            };
            var MyPeople = new List<Person>()
            {

                person1, person2, person3, person4, person5,
                person6, person7, person8, person9, person10

            };

            var ListOfPeople = new List<string>();
            var now = DateTime.Now;
            var decision = 0;
            var command = 17;
            var check = 20;
            string emailPerson;

            do
            {
                Console.Clear();
                Console.WriteLine("     ~ GLAVNI MENU ~  ");
                Console.WriteLine("");
                Console.WriteLine("1 - Aktivni eventi");
                Console.WriteLine("2 - Nadolazeći eventi");
                Console.WriteLine("3 - Eventi koji su završili");
                Console.WriteLine("4 - Kreiraj event");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                Console.Write("\nUnesi naredbu: ");
                Console.WriteLine("");
                bool isTheCommandParsed = int.TryParse(Console.ReadLine(), out command);
                if (!isTheCommandParsed)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Probaj opet");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Aktivni eventi");
                    Console.WriteLine("2 - Nadolazeći eventi");
                    Console.WriteLine("3 - Eventi koji su završili");
                    Console.WriteLine("4 - Kreiraj event");
                    Console.WriteLine("0 - Izlaz iz aplikacije");
                    Console.Write("\nUnesi naredbu opet: ");
                    command = 17;
                    continue;
                }
                switch (command)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("      ~ AKTIVNI EVENTI ~    ");
                        Console.WriteLine("");

                        foreach (var item in Events)
                        {
                            if (DateTime.Compare(item.Beginning, now) < 0 && DateTime.Compare(item.Ending, now) > 0)
                            {
                                Console.WriteLine($"{item.Id}");
                                Console.Write($"{item.EventName} - ");
                                Console.Write($"{item.Location}");
                                Console.WriteLine("");
                                Console.WriteLine($"Ends in {item.Ending}");
                                Console.WriteLine("");
                                Console.WriteLine("Sudionici: ");

                                foreach (var item1 in MyPeople)
                                {
                                    foreach (var it in item1.Presence)
                                    {
                                        if (Equals(it.Key, item.Id) == true)
                                        {
                                            if (it.Value == true)
                                                Console.WriteLine($"{item1.Name} {item1.Surname} - {item1.Email}");
                                        }
                                    }
                                }

                                foreach(var item2 in ListOfPeople)
                                {
                                    Console.WriteLine(item);
                                }

                            }
                           

                        }

                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("2 - Zabilježi neprisutnosti");
                            Console.WriteLine("1 - Povratak na izbornik");
                            Console.WriteLine("0 - Izlaz iz aplikacije");
                            Console.WriteLine("Unesi naredbu: ");
                            bool isTheCommandParsed1 = int.TryParse(Console.ReadLine(), out command);
                        } while (command<1 || command>2);
 
                        
                        switch (command)
                        {
                            case 2:
                                    Console.WriteLine("");
                                    Console.WriteLine("Unesi ID eventa:");
                                var eventId = Console.ReadLine();
                                var eventIdValid = GuidParser(eventId);

                                do
                                {
                                    Console.WriteLine("Unesi email osobe (0 = izlaz) : ");
                                    emailPerson = Console.ReadLine();
                                    if (emailPerson == "0")
                                        break;
                                    else
                                    {
                                        foreach (var item in MyPeople)
                                        {

                                            if (item.Email == emailPerson)
                                            {
                                                if (item.Presence[eventIdValid] == true)
                                                {
                                                    item.Presence[eventIdValid] = false;
                                                    Console.WriteLine("Zabilježeno");
                                                    break;
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Osoba nije sudionik eventa");
                                                break;
                                            }
                                        }
                                    }
                                } while (true);
                                


                                break;
                            case 1:
                                 continue;
                                
                            case 0:
                                return;
                        }


                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Povratak na glavni menu: DA ili NE");
                            string menu = Console.ReadLine();
                            string result = menu.ToUpper();
                            if (result == "DA")
                            {
                                decision = 1;
                                break;
                            }
                            else if (result == "NE")
                            {
                                decision = 0;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Krivi unos - probaj opet: ");

                                continue;

                            }

                        } while (true);
                        if (decision == 0)
                            return;
                        else
                            continue;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("      ~ NADOLAZEĆI EVENTI ~    ");
                        Console.WriteLine("");


                        foreach (var item in Events)
                        {
                            if (DateTime.Compare(item.Beginning, now) > 0)
                            {
                                InocomingEvents.Add(item);
                                Console.WriteLine($"{item.Id}");
                                Console.Write($"{item.EventName} - ");
                                Console.Write($"{item.Location}");
                                Console.WriteLine("");
                                Console.WriteLine($"Počinje za {(item.Beginning - now).Days} dana");
                                Console.WriteLine($"Traje {Math.Round((item.Ending - item.Beginning).TotalHours, 1)} h");


                                Console.WriteLine("Sudionici: ");

                                foreach (var item1 in MyPeople)
                                {
                                    foreach (var it in item1.Presence)
                                    {
                                        if (Equals(it.Key, item.Id) == true)
                                        {
                                            if (it.Value == true)
                                                Console.WriteLine($"{item1.Name} {item1.Surname} - {item1.Email}");
                                        }
                                    }
                                }
                            }
                        }


                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("3 - Izbriši event");
                            Console.WriteLine("2 - Ukloni osobe s eventa");
                            Console.WriteLine("1 - Povratak na glavni menu");
                            Console.WriteLine("0 - Izlaz iz aplikacije");
                            Console.WriteLine("Unesi naredbu: ");
                            bool isTheCommandParsed2 = int.TryParse( Console.ReadLine(),out command);
                        } while (command < 1 || command > 3);
                        switch(command)
                        {
                            case 3:
                                Console.WriteLine("Unesi ID eventa kojeg želiš izbrisat:");
                                var eventId = Console.ReadLine();
                                var eventIdSolution = GuidParser(eventId);
                                int checkingIfItIsIncoming = 1;
                                foreach(var item1 in InocomingEvents)
                                {
                                    if (eventIdSolution != item1.Id)
                                        checkingIfItIsIncoming = 0;
                                }
                                if (checkingIfItIsIncoming == 0)
                                {
                                    Console.WriteLine("Event nije moguće izbrisati");
                                    continue;
                                }
                                foreach(var item in InocomingEvents)
                                {
                                    if (item.Id == eventIdSolution)
                                        InocomingEvents.Remove(item);
 
                                }
                               
                                foreach(var item in MyPeople)
                                {
                                    foreach(var it in item.Presence)
                                    {
                                        if(it.Key == eventIdSolution)
                                        {
                                            item.Presence.Remove(it.Key);
                                        }
                                    }
                                }
                                Console.WriteLine("Uspješno izbrisan event!");
                                break;
                            case 2:
                                Console.WriteLine("Unesi ID eventa:");
                                eventId = Console.ReadLine();
                                eventIdSolution = GuidParser(eventId);
                                check = 20;
                                var emailPersonDelete = "";
                                do
                                {
                                    Console.WriteLine("Unesi email osobe (0 = izlaz) : ");
                                    emailPerson = Console.ReadLine();
                                    if (emailPerson == "0")
                                        break;
                                    else
                                    {
                                        foreach (var item in MyPeople)
                                        {

                                            if (item.Email == emailPerson)
                                            {
                                                if (item.Presence[eventIdSolution] == true)
                                                {
                                                    item.Presence[eventIdSolution] = false;
                                                    Console.WriteLine("Zabilježeno");
                                                    break;
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Osoba nije sudionik eventa");
                                                break;
                                            }
                                        }
                                    }
                                } while (true) ;
                                foreach (var item in MyPeople)
                                {
                                    if (item.Email == emailPersonDelete)
                                    {
                                        foreach (var it in item.Presence)
                                        {
                                            if (item.Presence[eventIdSolution] == true)
                                            {
                                                item.Presence.Remove(it.Key);
                                                Console.WriteLine("Zabilježeno");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Osoba nije sudionik eventa");
                                                Console.ReadLine();
                                            }
                                        }
                                    }
                                }
                                break;
                            case 1:
                                continue;
                            case 0:
                                break;

                        }



                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Povratak na glavni menu: DA ili NE");
                            string menu = Console.ReadLine();
                            string result = menu.ToUpper();
                            if (result == "DA")
                            {
                                decision = 1;
                                break;
                            }
                            else if (result == "NE")
                            {
                                decision = 0;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Krivi unos - probaj opet: ");

                                continue;

                            }

                        } while (true);
                        if (decision == 0)
                            return;
                        else
                            continue;

                    case 3:

                        Console.Clear();
                        Console.WriteLine("      ~ EVENTI KOJI SU ZAVRŠILI ~    ");
                        Console.WriteLine("");

                        foreach (var item in Events)
                        {
                            if (DateTime.Compare(item.Ending, now) < 0)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.Write($"{item.EventName} - ");
                                Console.Write($"{item.Location}");
                                Console.WriteLine("");
                                Console.WriteLine($"Završilo je prije {(now - item.Ending).Days} dana");
                                Console.WriteLine($"Event je trajao {Math.Round((item.Ending - item.Beginning).TotalHours, 1)} h");
                                Console.WriteLine("");
                                Console.WriteLine("Popis prisutnih sudionika: ");

                                foreach (var item1 in MyPeople)
                                {
                                    foreach (var it in item1.Presence)
                                    {
                                        if (Equals(it.Key, item.Id) == true)
                                        {
                                            if (it.Value == true)
                                                Console.WriteLine($"{item1.Name} {item1.Surname} - {item1.Email}");
                                        }
                                    }
                                }
                                Console.WriteLine("");
                                Console.WriteLine("Popis ne prisutnih sudionika: ");

                                foreach (var item1 in MyPeople)
                                {
                                    foreach (var it in item1.Presence)
                                    {
                                        if (Equals(it.Key, item.Id) == true)
                                        {
                                            if (it.Value == false)
                                                Console.WriteLine($"{item1.Name} {item1.Surname} - {item1.Email}");
                                        }
                                    }
                                }
                            }
                        }



                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Povratak na glavni menu: DA ili NE");
                            string menu = Console.ReadLine();
                            string result = menu.ToUpper();
                            if (result == "DA")
                            {
                                decision = 1;
                                break;
                            }
                            else if (result == "NE")
                            {
                                decision = 0;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Krivi unos - probaj opet: ");

                                continue;

                            }

                        } while (true);
                        if (decision == 0)
                            return;
                        else
                            continue;



                    case 4:
                        Console.Clear();
                        Console.WriteLine("      ~ KREIRAJ EVENT ~    ");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Unesi ime eventa: ");
                        string nameOfNewEvent = Console.ReadLine();
                        Console.WriteLine("Unesi lokaciju eventa: ");
                        string locationOfNewEvent = Console.ReadLine();
                        DateTime beginingOfNewEvent;
                        do
                        {   Console.WriteLine("Unesi vrijeme početka eventa: ");
                            Console.WriteLine("(mora biti u obliku DD.MM.YYYY)");
                            beginingOfNewEvent = DateTime.Parse(Console.ReadLine());

                        } while (beginingOfNewEvent < now);
                        DateTime endingOfNewEvent;
                        do
                        {
                            Console.WriteLine("Unesi vrijeme kraja eventa: ");
                            Console.WriteLine("(mora biti u obliku DD.MM.YYYY)");
                            endingOfNewEvent = DateTime.Parse(Console.ReadLine());

                        } while (endingOfNewEvent < beginingOfNewEvent);


                        Console.WriteLine("Unesi emailove osoba koji su pozvani na eventi: ");
                        Console.WriteLine("(svaka osoba je odvojena s razmakom)");
                        var newPeople = Console.ReadLine();
                        var onePerson = "";
                        foreach(var item in newPeople)
                        {
                            if (item == ' ')
                            {
                                
                                ListOfPeople.Add(onePerson);
                                onePerson = "";
                            }
                            else
                                onePerson = onePerson + item;
                        }
                        ListOfPeople.Add(onePerson);

                        foreach(var item in MyPeople)
                        {
                            foreach(var it in ListOfPeople)
                            {
                                if(item.Email == it)
                                {
                                    
                                }
                            }
                        }
                        Event newEvent = new Event(Guid.NewGuid(), nameOfNewEvent, locationOfNewEvent, beginingOfNewEvent, endingOfNewEvent, ListOfPeople);
                        Events.Add(newEvent);
                        Console.WriteLine("Event je uspješno kreiran");

                        do
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Povratak na glavni menu: DA ili NE");
                            string menu = Console.ReadLine();
                            string result = menu.ToUpper();
                            if (result == "DA")
                            {
                                decision = 1;
                                break;
                            }
                            else if (result == "NE")
                            {
                                decision = 0;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Krivi unos - probaj opet: ");
                                continue;

                            }

                        } while (true);
                        if (decision == 0)
                            return;
                        else
                            continue;


                    case 0:
                        return;




                }while (true) ;

               



                Console.WriteLine();
                Console.ReadLine();
            } while (true);
        }
    }
}

