using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ViewShoppingCart> GetShoppingСartByToken(Guid token)
        {
            string sqlQuery =
                "select sc.ProductId, P.Name as ProductName, sc.ProductOptionId, po.Weight, p.ProductTypeId, sum(sc.Count) as Count, sum(sc.Count*po.Price) as TotalPrice " +
                "from ShoppingСart sc" + " join Product p on sc.ProductId = p.Id " +
                "join ProductOption po on po.Id = sc.ProductOptionId" + $" where Token = '{token}' " +
                "group by sc.ProductId, P.Name, sc.ProductOptionId, po.Weight, p.ProductTypeId, po.Price";

            var data = _db.Query<ViewShoppingCart>(sqlQuery).ToList();

            return data;
        }
    }
}