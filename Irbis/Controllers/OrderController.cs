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

namespace Irbis.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderDataService _orderDataService;

        public OrderController()
        {
            var dataService = new Irbis.DataService.Init();
            _orderDataService = dataService.OrderDataService;
        }

        public ActionResult Index()
        {
            var dateTime = _orderDataService.GetLastDateTimeOrder(Token);

            var data = _orderDataService.GetOrder(Token, dateTime).ToList();

            var viewModel = Irbis.Code.Order.OrderHelper.GetOrderView(data);

            return View(viewModel);
        }
    }
}