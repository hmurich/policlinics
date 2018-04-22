using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using PoliclinicControl.Models;

namespace PoliclinicControl.Models
{
    public class MedContext : DbContext
    {
        public DbSet<MedOrg> MedOrgs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<MedAttach> MedAttachs{ get; set; }
        public DbSet<Status> Status { get; set; }
    }
}