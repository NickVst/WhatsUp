using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class PrivateChat : Chat
    {
        public Account Member1 { get; set; }
        public Account Member2 { get; set; }
    }
}