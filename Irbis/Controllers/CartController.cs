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
using Irbis.Models.Order;
using Irbis.Utils.Helpers;
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

            var dateTime = _orderDataService.GetLastDateTimeOrder(token);
            var order = _orderDataService.GetOrder(token, dateTime).ToList();
            var orderView = Irbis.Code.Order.OrderHelper.GetOrderView(order);

            var mes = TelegramMes(orderView);

            TelegramBot.SendMessageOrder(mes);
            return Json(true);
        }

        private string TelegramMes(OrderViewModel orderViewModel)
        {
            string s = $"🆕  Заказ № :\n";
            s += $"Дата заказа: {orderViewModel.CreatedAt}\n";
            s += $"👤  {orderViewModel.User.Name}\n";
            s += $"📞  {orderViewModel.User.Phone}\n";
            s += $"🚚  Адрес доставки: {orderViewModel.User.Address}; время доставки: Ближайшее время\n";
            s += $"📝  {orderViewModel.User.Comment}\n\n";

            s += $"🛒 Корзина: \n";
      
            foreach (var order in orderViewModel.Orders)
            {
                s += $"{order.ProductName}  {order.Weight} г.  × {order.Count} шт  {order.Price} руб.\n";
            }

            s += $"\n";

            s += $"Сумма заказа: {orderViewModel.TotalPrice} руб.\n";
            s += $"💰  Итого к оплате: {orderViewModel.TotalPrice} руб.\n";

            return s;
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