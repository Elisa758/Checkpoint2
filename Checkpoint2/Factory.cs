using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    public class PersonFactory
    {
        public static AbstractPerson Create(string name, List<AbstractPerson> students=null,List<AbstractPerson>instructors =null, Cursus cursus = null)
        {
            if(students!=null && instructors==null)
            {
                AbstractPerson newInstructor = new Instructor(name, students);
                return newInstructor;
            }
            else if(instructors!=null)
            {
                AbstractPerson newLeadInstructor = new LeadInstructor(name, instructors);
                return newLeadInstructor;
            }
            else
            {
                AbstractPerson newStudents = new Students(name, cursus);
                return newStudents;
            }
        }
    }
}
