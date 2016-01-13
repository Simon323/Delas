using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delas.Site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var x = User.Identity.Name;
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

        public ActionResult Transfer()
        {
            return View();
        }

        public ActionResult CashHandout() // wypłata
        {
            return View();
        }

        public ActionResult Contribution() //wpłata
        {
            return View();
        }
    }
}