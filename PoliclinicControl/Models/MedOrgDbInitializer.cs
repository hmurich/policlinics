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

            db.Clients.Add(new Client { FName = "Имя 1", LName = "FName 1", PName = "FName 1", Iin = "iin 1" });
            db.Clients.Add(new Client { FName = "Имя 2", LName = "FName 2", PName = "FName 2", Iin = "iin 2" });
            db.Clients.Add(new Client { FName = "Имя 3", LName = "FName 3", PName = "FName 3", Iin = "iin 3" });

            base.Seed(db);
        }
    }
}