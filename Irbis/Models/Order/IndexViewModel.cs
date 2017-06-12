using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Irbis.Models.Order
{
    public class IndexViewModel
    {
        public UserModel User { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public Decimal TotalPrice { get; set; }
    }
}