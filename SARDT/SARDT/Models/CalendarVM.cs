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
    }
}