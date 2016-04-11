using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Day
    {
        public int ID { get; set; }
        // 0 - Sunday, 1 - Monday, etc...
        public int DayOfWeek { get; set; }
        public int DayOfMonth { get; set; }
        public int Month { get; set; }
        //TODO: Add list of events
    }
}