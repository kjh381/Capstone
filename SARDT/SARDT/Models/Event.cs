using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Event
    {
        public enum EventType { Public, Team }
        public int EventID { get; set; }
        public EventType Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastChangedOn { get; set; }
        public string LastChangeBy { get; set; }
    }
}