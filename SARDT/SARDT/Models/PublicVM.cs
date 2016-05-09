using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class PublicVM
    {
        public List<WebText> textList { get; set; }
        public List<WebImage> imageList { get; set; }

        public List<Event> eventList { get; set; }

        public Video currentVideo { get; set; }

        public Application application { get; set; }

        public DateTime ParseMilitaryTime(string time)
        {
            //
            // Convert hour part of string to integer.
            //
            string hour = time.Substring(0, 2);
            int hourInt = int.Parse(hour);
            if (hourInt >= 24)
            {
                throw new ArgumentOutOfRangeException("Invalid hour");
            }
            //
            // Convert minute part of string to integer.
            //
            string minute = time.Substring(2, 2);
            int minuteInt = int.Parse(minute);
            if (minuteInt >= 60)
            {
                throw new ArgumentOutOfRangeException("Invalid minute");
            }
            //
            // Return the DateTime.
            //
            return new DateTime(2016, 04, 20, hourInt, minuteInt, 0);
        }

    }
}