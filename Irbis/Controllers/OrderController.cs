using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Irbis.DataService;
using Irbis.Models;
using Irbis.Models.Order;
using IndexViewModel = Irbis.Models.Order.IndexViewModel;

namespace Irbis.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderDataService _orderDataService;

        public OrderController()
        {
            var dataService = new Irbis.DataService.Init();
            _orderDataService = dataService.OrderDataService;
        }

        public ActionResult Index()
        {
            var viewModel = new IndexViewModel();

            var tokenStr = Request.Cookies["token"]?.Value;
            var token = Guid.Empty;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                token = Guid.Parse(tokenStr);
            }

            var dateTime = _orderDataService.GetLastDateTimeOrder(token);

            var data = _orderDataService.GetOrder(token, dateTime).ToList();

            if (data.Any())
            {
                var firstElement = data.FirstOrDefault();

                if (firstElement != null)
                {
                    viewModel.User = new UserModel()
                    {
                        Name = firstElement.UserName,
                        Phone = firstElement.UserPhone,
                        Address = firstElement.UserAddress,
                        Comment = firstElement.UserComment
                    };

                    viewModel.CreatedAt = firstElement.CreatedAt;
                }

                viewModel.Orders = new List<OrderViewModel>();

                foreach (var item in data)
                {
                    viewModel.Orders.Add(new OrderViewModel()
                    {
                        Token = item.Token,
                        UserName = item.UserName,
                        UserPhone = item.UserPhone,
                        UserAddress = item.UserAddress,
                        UserComment = item.UserComment,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ProductOptionId = item.ProductOptionId,
                        Weight = item.Weight,
                        ProductTypeId = item.ProductTypeId,
                        Price = item.Price,
                        Count = item.Count,
                        TotalPrice = item.TotalPrice,
                        CreatedAt = item.CreatedAt
                    });

                    viewModel.TotalPrice += item.TotalPrice;
                }

                 
            }

            return View(viewModel);
        }
    }
}