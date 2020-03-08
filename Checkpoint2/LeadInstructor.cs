using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    public class LeadInstructor : AbstractPerson
    {
        public LeadInstructor(string name,  List<AbstractPerson> instructors)
        {
            Name = name;
            PersonList = instructors;

        }
    }
}
