using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Irbis.DataService;
using Irbis.Models;
using IndexViewModel = Irbis.Models.Category.IndexViewModel;

namespace Irbis.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ShoppingСartDataService _shoppingСartDataService;

        public ShoppingController()
        {
            var dataService = new Irbis.DataService.Init();
            _shoppingСartDataService = dataService.ShoppingСartDataService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProduct(int productId, int optionProduct, int countProduct)
        {
            bool result = false;

            var tokenStr = Request.Cookies["token"]?.Value;
            var token=Guid.Empty;
             
            try
            {
                if (tokenStr != null && !tokenStr.IsEmpty())
                {
                    token = Guid.Parse(tokenStr);
                }

                _shoppingСartDataService.AddProductToShoppingCart(token, productId, optionProduct, countProduct);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
           
            return Json(result);
        }
    }
}