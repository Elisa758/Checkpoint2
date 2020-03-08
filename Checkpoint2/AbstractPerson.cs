using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    public class AbstractPerson
    {
        public Database DatabaseConnection { get; set; }
        public string Name { get; set; }
        public List<Event> Agenda { get; set; }
        public string Campus { get; set; }
        public List<AbstractPerson> PersonList { get; set; } = new List<AbstractPerson>();
        //public List<AbstractPerson> InstructorsList { get; set; } = new List<AbstractPerson>();


        public override String ToString()
        {
            string descritpion = Name;
            foreach (AbstractPerson person in PersonList)
            {
                descritpion += "\n" + person;
            }
            return descritpion;
        }

        public string GetEvents(DateTime startTime, DateTime endTime, List<Event> events)
        {
            string description = "";
            foreach (Event item in events)
            {
                if (startTime <= item.StartTime && item.EndTime <= endTime)
                {
                    description += item.Description + "\n";
                }

            }
            return description;

        }

        public string GetAllStudentsOfAInstructor()
        {
            string description = null;
            foreach (AbstractPerson person in PersonList)
            {
                description += person +"\n";
                
            }
            return description;
        }

    }
}
