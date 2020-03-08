using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    public class Instructor : AbstractPerson
    {
        public Instructor(string name, List<AbstractPerson>students)
        {
            Name = name;
            PersonList = students;
        }

    }
}
