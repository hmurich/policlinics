using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PoliclinicControl.Models
{
    public class MedOrgDbInitializer : DropCreateDatabaseAlways<MedContext>
    {
        protected override void Seed(MedContext db)
        {
            db.MedOrgs.Add(new MedOrg { Name = "Поликника № 7"});
            db.MedOrgs.Add(new MedOrg { Name = "Поликника № 10" });
            db.MedOrgs.Add(new MedOrg { Name = "Поликника № 6" });

            base.Seed(db);
        }
    }
}