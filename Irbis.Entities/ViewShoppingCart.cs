namespace Irbis.Entities
{
    public class ViewShoppingCart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductOptionId { get; set; }
        public int Weight { get; set; }
        public int ProductTypeId { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}