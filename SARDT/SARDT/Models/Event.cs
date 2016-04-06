﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public DateTime LastChangedOn { get; set; }
        public string LastChangeBy { get; set; }
    }
}