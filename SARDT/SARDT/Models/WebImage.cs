using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARDT.Models
{
    public class WebImage
    {
        [Editable(false)]
        public int WebImageID { get; set; }

        public string FileName { get; set; }

        public string Caption { get; set; }

        [Editable(false)]
        public bool InUse { get; set; }

        [Editable(false)]
        public string Location { get; set; }

    }
}