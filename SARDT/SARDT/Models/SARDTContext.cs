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
            Database.SetInitializer<SARDTContext>(new DBInitializer());
        }


        //TODO DbSets
        public System.Data.Entity.DbSet<SARDT.Models.WebText> WebTexts { get; set; }


       

        public System.Data.Entity.DbSet<SARDT.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.Video> Videos { get; set; }
        public System.Data.Entity.DbSet<SARDT.Models.CurrentVideos> CurrentVideo { get; set; }


        

    }
}