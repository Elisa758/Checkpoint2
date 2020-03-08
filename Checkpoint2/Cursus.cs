using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    public class Cursus
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Event> Calendar { get; set; }
    }
}
