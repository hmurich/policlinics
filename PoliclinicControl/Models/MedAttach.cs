using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliclinicControl.Models
{
   
    public class MedAttach
    {
       
        
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int StatusId { get; set; }

        public int MedOrgId { get; set; }
        public MedOrg MedOrg { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateClosed { get; set; }
    }
}