using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    /// <summary>
    /// Contains a chat between 1 or more people. Allows users to change
    /// the name of the group, so it appears as the title inside the chat
    /// list in /chat .
    /// </summary>
    public class GroupChat : Chat
    {
        public string Name { get; set; }

        public Account Owner { get; set; }
        public IEnumerable<Account> Members { get; set; }
    }
}