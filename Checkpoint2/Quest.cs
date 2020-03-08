using System;
using System.Collections.Generic;
using System.Text;

namespace WCS
{
    class Quest
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Cursus Cursus { get; set; }
        public Expedition Expedition { get; set; }
    }
}
