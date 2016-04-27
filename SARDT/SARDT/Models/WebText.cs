using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SARDT.Models
{
    public class WebText
    {
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int WebTextID { get; set; }

        public string Section { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Editable(false)]
        public string Page { get; set; }

        [Display(Name="Last Updated On")]
        public DateTime LastChangedOn { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastChangeBy { get; set; }

    }
}