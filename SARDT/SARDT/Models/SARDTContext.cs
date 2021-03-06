using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SARDT.Models
{
    public class SARDTContext: IdentityDbContext<Member>
    {
        public SARDTContext() : base("SARDTContext")
        {
            
        }
   
        public System.Data.Entity.DbSet<SARDT.Models.WebText> WebTexts { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.WebImage> WebImages { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.Video> Videos { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.CurrentVideos> CurrentVideo { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.Application> Applications { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.SystemMessage> Messages { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.EventReminder> EventReminders { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.Message> UserMessages { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.Conversation> Conversations { get; set; }
    }
}
