using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Irbis.DataService;
using Irbis.Entities;
using Irbis.Models;
using Irbis.Models.Cart;
using IndexViewModel = Irbis.Models.Category.IndexViewModel;

namespace Irbis.Controllers
{
    public class CartController : Controller
    {
        private readonly СartDataService _сartDataService;

        public CartController()
        {
            var dataService = new Irbis.DataService.Init();
            _сartDataService = dataService.СartDataService;
        }
        public ActionResult Index()
        {
            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            var data = _сartDataService.GetByToken(token);

            var totalPrice = _сartDataService.GetTotalPriceByToken(token);

            var model = new Models.Cart.IndexViewModel();

            model.CartItems=new List<ViewCartModel>();
            foreach (var item in data)
            {
                model.CartItems.Add(new ViewCartModel()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductTypeId = item.ProductTypeId,
                    Weight = item.Weight,
                    ProductOptionId = item.ProductOptionId,
                    Count = item.Count,
                    TotalPrice = item.TotalPrice
                });
            }

            model.TotalPrice = totalPrice;
            

            return View(model);
        }

        [HttpPost]
        public JsonResult AddProduct(int productId, int optionProduct, int countProduct)
        {
            bool result = false;

            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            try
            {
                if (tokenStr != null && !tokenStr.IsEmpty())
                {
                    token = Guid.Parse(tokenStr);
                }

                _сartDataService.AddProductToCart(token, productId, optionProduct, countProduct);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return Json(result);
        }


        [HttpGet]
        public JsonResult GetСartByToken()
        {
            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            var result = _сartDataService.GetByToken(token).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}