using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CommandLine;

namespace WCS
{
    class Program
    {
        [Verb("events", HelpText = "Display all the events for a person and a period")]
        class EventsOption
        {
            [Option('n', "name", Required = true, HelpText = "Person name")]
            public string PersonName { get; set; }
            [Option('b', "begins", Required = true, HelpText = "the start of the event")]
            public string StartTime { get; set; }
            [Option('e', "ends", Required = true, HelpText = "the end of the event")]
            public string EndTime { get; set; }
        }

        [Verb("cursus", HelpText = "Display information for a cursus")]
        class CursusOption
        {
            [Option('n', "name", Required = true, HelpText = "Cursus name")]
            public string CursusName { get; set; }

            [Option('s',"students",HelpText = "Display all the students for a cursus")]
            public bool Students { get; set; }

            [Option('q',"quests", HelpText = "Display all the quests for a cursus")]
            public bool Quests { get; set; }
        }

        public static void Main(string[] args)
        {
            /*Parser.Default.ParseArguments<EventsOption, CursusOption>(args)
            .WithParsed<EventsOption>(RunEventsOption)
            .WithParsed<CursusOption>(RunCursusOption);*/


            /*Event newEvent = new Event("Important meeting");
            newEvent.StartTime = DateTime.Now;
            newEvent.EndTime = DateTime.Now + TimeSpan.FromHours(1);
            newEvent.Postpone(TimeSpan.FromHours(1));
            Console.WriteLine("Another meeting is postponed");*/

            //Création d'événement pour une personne

            Event rentree = new Event("rentrée");
            rentree.StartTime = new DateTime(2019,12,09);
            rentree.EndTime = new DateTime(2019, 12, 10);

            Event hackathon = new Event("hackathon");
            hackathon.StartTime = new DateTime(2020, 02, 13);
            hackathon.EndTime = new DateTime(2020, 02, 15);

            List<Event> events = new List<Event>();
            events.Add(rentree);
            events.Add(hackathon);

            AbstractPerson person = new AbstractPerson();
            person.Agenda = events;
            

            DateTime date1 = new DateTime(2018, 01, 10);
            DateTime date2 = new DateTime(2020, 03, 10);

            Console.WriteLine(person.GetEvents(date1, date2,events));



            /*Cursus csharp = new Cursus();

             AbstractPerson student1 = PersonFactory.Create("Tom", null, null, csharp);
             AbstractPerson student2 = PersonFactory.Create("Lys", null, null, csharp);
             AbstractPerson student3 = PersonFactory.Create("Nathaniel", null, null, csharp);


             List<AbstractPerson> studentsList = new List<AbstractPerson>();

             studentsList.Add(student1);
             studentsList.Add(student2);
             studentsList.Add(student3);

             List<AbstractPerson> instructorsList = new List<AbstractPerson>();

             AbstractPerson instructor = PersonFactory.Create("Instructor1", studentsList);
            Console.WriteLine(instructor.GetAllStudentsOfAInstructor());
            //Console.WriteLine(instructor.ToString());


            AbstractPerson instructor2 = PersonFactory.Create("Instructor2", studentsList);

             instructorsList.Add(instructor);
             instructorsList.Add(instructor2);

            AbstractPerson lead = PersonFactory.Create("Chef", studentsList, instructorsList); 

            //Console.WriteLine(lead.ToString()); */

            // Display Students By Cursus and Instructor Id

            /*string nameCursus = "c#";
;
            AbstractPerson students = new AbstractPerson();
            students.DatabaseConnection = Database.Instance;
            
            students.DatabaseConnection.DisplayStudentsByCursus(nameCursus);

            int instructorId = 3;

            students.DatabaseConnection.DisplayStudentsByInstructor(instructorId);*/

        }

        static void RunEventsOption(EventsOption option)
        {

        }
        static void RunCursusOption(CursusOption option)
        {
            if(option.Students)
            {
                AbstractPerson students = new AbstractPerson();
                students.DatabaseConnection = Database.Instance;

                students.DatabaseConnection.DisplayStudentsByCursus(option.CursusName);
            }
            else if(option.Quests)
            {

            }
        }
    }
}
