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

        public string MemberName { get; set; }
      public int MemberID { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        public int AttendencePercent { get; set; }

        public string City { get; set; }
       
        public int ZipCode { get; set; }
       
        public string DOB { get; set; }
        public bool IsDiveEligible { get; set; }
        
        [DataType(DataType.EmailAddress)]
        //public string EmailAddress { get; set; }
        public string EmergencyContact { get; set; }
        public int HomeNumber { get; set; }
        public int WorkPhone { get; set; }
    }
}