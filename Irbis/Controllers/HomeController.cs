using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Irbis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("Category?page=1");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Delivery()
        {
            return View();
        }
    }
}