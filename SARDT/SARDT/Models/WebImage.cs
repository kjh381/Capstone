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

        [DataType(DataType.MultilineText)]
        public string Caption { get; set; }

        [Editable(false)]
        public bool InUse { get; set; }

        [Editable(false)]
        public string Page { get; set; }

        [Editable(false)]
        public int? Location { get; set; }

    }
}