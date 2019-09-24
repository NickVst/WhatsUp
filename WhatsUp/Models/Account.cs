using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class Account : Entity
    { 
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<Account> Contacts { get; set; }
    }
}