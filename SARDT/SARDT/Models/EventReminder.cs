using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class EventReminder
    {
        public int ID { get; set; }
        public Event Event { get; set; }
        public DateTime EventDate { get; set; }
    }
}