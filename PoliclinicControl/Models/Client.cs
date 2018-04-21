using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliclinicControl.Models
{
    public class Client
    {
        // ID 
        public int Id { get; set; }
        // first name 
        public string FName { get; set; }
        // last name 
        public string LName { get; set; }
        // pastronik name 
        public string PName { get; set; }
        // pastronik IIN 
        public string Iin { get; set; }
    }
}