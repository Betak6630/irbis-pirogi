using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irbis.Entities
{
    public class ViewOrder
    {
        public Guid Token { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserComment { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductOptionId { get; set; }
        public double Weight { get; set; }
        public int ProductTypeId { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
