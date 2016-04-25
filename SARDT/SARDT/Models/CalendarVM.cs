using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class CalendarVM
    {
        public Month month = new Month();
        public Month Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }
        public int Year { get; set; }
        public string ParseMilitaryAsNormalTime(int militaryTime)
        {
            string normalTime = "";
            string amPMString = "AM";
            if (militaryTime > 1259)
            {
                militaryTime = militaryTime - 1200;
                amPMString = "PM";
            }
            string militaryString = militaryTime.ToString("D4");
            normalTime = militaryString.Substring(0, 2) + ":" + militaryString.Substring(2, 2) + " " + amPMString;
            return normalTime;
        }
    }
}