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
        private readonly OrderDataService _orderDataService;

        public CartController()
        {
            var dataService = new Irbis.DataService.Init();
            _сartDataService = dataService.СartDataService;
            _orderDataService = dataService.OrderDataService;
        }
        public ActionResult Index()
        {
            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            var model = GetCart(token);

            return View(model);
        }

        private Models.Cart.IndexViewModel GetCart(Guid token)
        {
            var data = _сartDataService.GetByToken(token);

            var totalPrice = _сartDataService.GetTotalPriceByToken(token);

            var model = new Models.Cart.IndexViewModel();

            model.CartItems = new List<ViewCartModel>();
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

            return model;
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

                if (countProduct > 0)
                {
                    _сartDataService.AddProductToCart(token, productId, optionProduct, countProduct);
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateProduct(int productId, int optionProduct, int countProduct)
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


                _сartDataService.UpdateProductToCart(token, productId, optionProduct, countProduct);
                result = true;

            }
            catch (Exception)
            {
                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public void RemoveProduct(int productId, int optionProductId)
        {
            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            if (productId > 0)
            {
                _сartDataService.RemoveProductToCart(token, productId, optionProductId);
            }
        }

        [HttpPost]
        public JsonResult Checkout(string name, string phone, string address, string comment)
        {
            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            var user = new Irbis.Entities.User()
            {
                Name = name,
                Phone = phone,
                Address = address,
                Comment = comment
            };

            var data = _сartDataService.GetShoppingСart(token);
            _orderDataService.SaveOrder(data, user, token);
            _сartDataService.Clear(token);

            return Json(new object());
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

        public JsonResult GetCart()
        {
            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            var model = GetCart(token);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}