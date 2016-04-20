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
    }
}