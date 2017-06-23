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
    public class CartController : BaseController
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
            var model = GetCart(this.Token);
            return View(model);
        }

        [HttpPost]
        public JsonResult AddProduct(int productId, int optionProduct, int countProduct)
        {
            bool result = false;
            try
            {
              
                if (countProduct > 0)
                {
                    _сartDataService.AddProductToCart(Token, productId, optionProduct, countProduct);
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
            try
            {
                _сartDataService.UpdateProductToCart(Token, productId, optionProduct, countProduct);
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
            var user = new Irbis.Entities.User()
            {
                Name = name,
                Phone = phone,
                Address = address,
                Comment = comment
            };

            var data = _сartDataService.GetShoppingСart(Token);
            _orderDataService.SaveOrder(data, user, Token);
            _сartDataService.Clear(Token);

            var dateTime = _orderDataService.GetLastDateTimeOrder(Token);
            var order = _orderDataService.GetOrder(Token, dateTime).ToList();
            var orderView = Irbis.Code.Order.OrderHelper.GetOrderView(order);

            var mes = TelegramMes(orderView);

            TelegramBot.SendMessageOrder(mes);
            return Json(true);
        }

        [HttpGet]
        public JsonResult GetСartByToken()
        {
            var result = _сartDataService.GetByToken(Token).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCart()
        {
            var model = GetCart(Token);
            return Json(model, JsonRequestBehavior.AllowGet);
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
    }
}