using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class ResultVM
    {
        public bool ErrorOccurred { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string RedirectViewName { get; set; }
        public string RedirectControllerName { get; set; }
    }
}