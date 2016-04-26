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
        public string ParseMilitaryAsNormalTime(string militaryTime)
        {
            int militaryNum = int.Parse(militaryTime);
            string normalTime = "";
            string amPMString = "AM";
            if (militaryNum > 1259)
            {
                militaryNum = militaryNum - 1200;
                amPMString = "PM";
            }
            string militaryString = militaryNum.ToString("D4");
            normalTime = militaryString.Substring(0, 2) + ":" + militaryString.Substring(2, 2) + " " + amPMString;
            return normalTime;
        }
    }
}