using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SARDT.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<SARDTContext>
    //public class DBInitializer : DropCreateDatabaseIfModelChanges<SARDTContext>
    {

        protected override void Seed(SARDTContext context)
        {
            //TODO: Add seeds to context here. 
            //context.class.add(newObjName)


            base.Seed(context);
        }
    }
}