using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class WebText
    {
        public int WebTextID { get; set; }

        public string Section { get; set; }

        public string Body { get; set; }

        public DateTime LastChangedOn { get; set; }

        public string LastChangeBy { get; set; }

    }
}