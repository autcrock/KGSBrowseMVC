using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KGSBrowseMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            return null;
            //return View();
        }

        public ActionResult Uploadfiles()
        {
            // Can pass a model in here as an argument to View
            return View();
        }
    }
}
