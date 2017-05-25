using System.Collections.Generic;

namespace Irbis.Models.Cart
{
    public class IndexViewModel
    {
        public List<ViewCartModel> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}