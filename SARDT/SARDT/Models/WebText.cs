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

        [Editable(false)]
        public string Section { get; set; }

        public string Body { get; set; }

        [Editable(false)]
        public string Page { get; set; }

        [Display(Name="Last Updated On")]
        [Editable(false)]
        public DateTime LastChangedOn { get; set; }

        [Display(Name = "Last Updated By")]
        [Editable(false)]
        public string LastChangeBy { get; set; }

    }
}