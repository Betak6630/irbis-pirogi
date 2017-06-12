﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Irbis.DataService;
using Irbis.Models;
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
                   
            }

            return View(viewModel);
        }
    }
}