using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class Message : Entity
    {
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public Account Sender { get; set; }
        
    }
}