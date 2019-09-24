using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Redirects the user to the chat area if they are authenticated.
        /// Otherwise, the user is redirected to the login page.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays a form for logging into the application.
        /// </summary>
        [HttpGet]
        public ActionResult Login()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles an authentication request.
        /// </summary>
        [HttpPost]
        public ActionResult Login(Account loginDetails)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays a form for registering for the application.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles a registration request.
        /// </summary>
        [HttpPost]
        public ActionResult Register(Account registerDetails)
        {
            throw new NotImplementedException();
        }
    }
}