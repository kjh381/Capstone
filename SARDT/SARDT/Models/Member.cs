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

        public string Address { get; set; }
        public int AttendencePercent { get; set; }

        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        public bool IsDiveEligible { get; set; }

        public string EmergencyContactName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string EmergencyContactPhone { get; set; }
    }
    
}