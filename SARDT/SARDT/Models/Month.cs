using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Month
    {
        public List<Day> days = new List<Day>();
        public string Name { get; set; }
        public int Num { get; set; }
        public List<Day> Days
        {
            get
            {
                return days;
            }

            set
            {
                days = value;
            }
        }
        public int DaysInMonth { get; set; }
    }
}