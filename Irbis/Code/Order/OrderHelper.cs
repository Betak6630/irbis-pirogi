using System.Collections.Generic;
using System.Linq;
using Irbis.Entities;
using Irbis.Models;
using Irbis.Models.Order;

namespace Irbis.Code.Order
{
    public class  OrderHelper
    {
        public static OrderViewModel GetOrderView(List<ViewOrder> viewOrder)
        {
            var viewModel = new OrderViewModel();

            if (viewOrder.Any())
            {
                var firstElement = viewOrder.FirstOrDefault();

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

                viewModel.Orders = new List<OrderProductViewModel>();

                foreach (var item in viewOrder)
                {
                    viewModel.Orders.Add(new OrderProductViewModel()
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

            return viewModel;
        }
    }
}