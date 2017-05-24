using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Irbis.DataService;
using Irbis.Models;
using IndexViewModel = Irbis.Models.Category.IndexViewModel;

namespace Irbis.Controllers
{
    public class ShoppingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProduct(int productId, int optionProduct, int countProduct)
        {

            return Json(true);
        }
    }
}