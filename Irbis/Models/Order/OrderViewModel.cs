using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Irbis.Models.Order
{
    public class OrderViewModel
    {
        public UserModel User { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderProductViewModel> Orders { get; set; }
        public Decimal TotalPrice { get; set; }
    }
}