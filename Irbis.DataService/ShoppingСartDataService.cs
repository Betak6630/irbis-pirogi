using System;
using Irbis.Entities;
using PetaPoco;

namespace Irbis.DataService
{
    public class ShoppingСartDataService
    {
        private Database _db;
        public ShoppingСartDataService(Database db)
        {
            _db = db;
        }

        public void AddProductToShoppingCart(Guid token, int productId, int productOptionId, int count)
        {
            var shoppingCart = new ShoppingСart()
            {
                Token = token,
                ProductId = productId,
                ProductOptionId = productOptionId,
                Count = count,
                CreatedAt = DateTime.Now
            };

            _db.Insert("ShoppingСart", "Id", shoppingCart);

        }
    }
}