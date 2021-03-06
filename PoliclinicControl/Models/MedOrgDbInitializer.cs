﻿using System;
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

            db.Status.Add(new Status { Name = "Создан/В обработке" });
            db.Status.Add(new Status { Name = "Одобрен.Прикреплен" });
            db.Status.Add(new Status { Name = "Отказан.Не прикреплен" });

            db.Users.Add(new User { Login = "Admin", Password = "Admin", IsAdmin = true, IsAttach = true, IsControl = true, IsReport = true});

            base.Seed(db);
        }
    }
}