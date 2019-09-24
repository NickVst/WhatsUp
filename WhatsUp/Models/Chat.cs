using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    /// <summary>
    /// Abstraction layer for PrivateChats and GroupChats.
    /// </summary>
    public abstract class Chat : Entity
    {
        public IEnumerable<Message> Messages { get; set; }
    }
}