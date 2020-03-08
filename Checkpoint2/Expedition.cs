using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    class Expedition
    {
        public string Name { get; set; }
        public List<Quest> Quests { get; set; } = new List<Quest>();
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
