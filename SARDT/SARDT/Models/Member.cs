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
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int MemberID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        public int AttendencePercent { get; set; }

        public string City { get; set; }
       
        public int ZipCode { get; set; }
       
        public string DOB { get; set; }
        public bool IsDiveEligible { get; set; }
        
        public string EmergencyContact { get; set; }
        public int HomeNumber { get; set; }
        public int WorkPhone { get; set; }
        [System.Web.Mvc.HiddenInput(DisplayValue=false)]
        public override bool PhoneNumberConfirmed { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override bool TwoFactorEnabled
        {
            get
            {
                return base.TwoFactorEnabled;
            }
            set
            {
                base.TwoFactorEnabled = value;
            }
        }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override DateTime? LockoutEndDateUtc
        {
            get
            {
                return base.LockoutEndDateUtc;
            }
            set
            {
                base.LockoutEndDateUtc = value;
            }
        }
        
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override bool LockoutEnabled
        {
            get
            {
                return base.LockoutEnabled;
            }
            set
            {
                base.LockoutEnabled = value;
            }
        }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override int AccessFailedCount
        {
            get
            {
                return base.AccessFailedCount;
            }
            set
            {
                base.AccessFailedCount = value;
            }
        }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }
        
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override string PasswordHash
        {
            get
            {
                return base.PasswordHash;
            }
            set
            {
                base.PasswordHash = value;
            }
        }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override string SecurityStamp
        {
            get
            {
                return base.SecurityStamp;
            }
            set
            {
                base.SecurityStamp = value;
            }
        }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override string UserName
        {
            get
            {
                return base.UserName;
            }
            set
            {
                base.UserName = value;
            }
        }
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public override bool EmailConfirmed
        {
            get
            {
                return base.EmailConfirmed;
            }
            set
            {
                base.EmailConfirmed = value;
            }
        }
    }
}