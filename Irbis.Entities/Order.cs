using System;

namespace Irbis.Entities
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int ProductId { get; set; }
        public int ProductOptionId { get; set; }
        public int Count { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public string UserComment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}