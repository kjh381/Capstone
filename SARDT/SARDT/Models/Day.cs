﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Day
    {
        private List<Event> events = new List<Event>();
        private DateTime date = new DateTime();
        public int ID { get; set; }
        // 0 - Sunday, 1 - Monday, etc...
        //public int DayOfWeek { get; set; }
        //public int DayOfMonth { get; set; }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        //public int Month { get; set; }
        //TODO: Add list of events
        public List<Event> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
            }
        }
    }
}