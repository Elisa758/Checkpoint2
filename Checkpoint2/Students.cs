using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    public class Students : AbstractPerson
    {
        public Cursus Cursus { get; }
        public Students(string name, Cursus cursus)
        {
            Name = name;
            Cursus = cursus;
        }
        
    }
}
