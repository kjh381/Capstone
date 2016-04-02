using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.Entity;

namespace SARDT.Models
{
    public class SARDTContext: DbContext
    {
        public SARDTContext() : base("SARDTDBConnection")
        {
            Database.SetInitializer<SARDTContext>(new DBInitializer());
        }

        //TODO DbSets
        public System.Data.Entity.DbSet<SARDT.Models.WebText> WebTexts { get; set; }
    }
}