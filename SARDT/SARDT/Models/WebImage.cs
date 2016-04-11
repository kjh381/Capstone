using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARDT.Models
{
    public class WebImage
    {
        public int WebImageID { get; set; }

        public string FileName { get; set; }

        public string Caption { get; set; }

        public bool InUse { get; set; }

        public string? Location { get; set; }

    }
}