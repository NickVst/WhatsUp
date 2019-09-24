using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsUp.Controllers
{
    public class ChatController : Controller
    {
        /// <summary>
        /// The home page for logged in users. Displays all chats as well as
        /// options for creating new contacts and groups.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}