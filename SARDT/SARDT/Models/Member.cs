using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SARDT.Models
{
    public class Member : IdentityUser
    {
        public string Name { get; set; }

        public string MemberName { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int MemberID { get; set; }

        public  string Password{ get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string FirstName { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string LastName { get; set; }


        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string Address { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int AttendencePercent { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string City { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int ZipCode { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string DOB { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public bool IsDiveEligible { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public string EmergencyContact { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int HomeNumber { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int WorkPhone { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override bool PhoneNumberConfirmed { get; set; }
    }
    
}