using System;

namespace Irbis.Entities
{
    /// <summary>
    /// Корзина покупок
    /// </summary>
    public class ShoppingСart
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int ProductId { get; set; }
        public int ProductOptionId { get; set; }
        public int Count { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}