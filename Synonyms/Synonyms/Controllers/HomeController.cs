using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synonyms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dictionary";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Title = "Search";
            return View();
        }
    }
}
