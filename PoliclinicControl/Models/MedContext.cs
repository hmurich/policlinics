using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace PoliclinicControl.Models
{
    public class MedContext : DbContext
    {
        public DbSet<MedOrg> MedOrgs { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}