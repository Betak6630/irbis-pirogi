using System;
using System.Collections.Generic;
using System.Linq;
using Irbis.Entities;
using PetaPoco;

namespace Irbis.DataService
{
    public class СartDataService
    {
        private Database _db;
        public СartDataService(Database db)
        {
            _db = db;
        }

        public void AddProductToCart(Guid token, int productId, int productOptionId, int count)
        {
            var shoppingCart = new ShoppingСart()
            {
                Token = token,
                ProductId = productId,
                ProductOptionId = productOptionId,
                Count = count,
                CreatedAt = DateTime.Now
            };

            string sqlQuery =
                $"select count(1) from ShoppingСart where Token='{token}' and  ProductId={productId} and ProductOptionId={productOptionId}";

            var result = _db.ExecuteScalar<int>(sqlQuery);

            if (result > 0)
            {
                var sqlUpdate =
                    $"update ShoppingСart set Count=Count+{shoppingCart.Count} where  Token='{token}' and  ProductId={productId} and ProductOptionId={productOptionId}";

                _db.Execute(sqlUpdate);
            }
            else
            {
                _db.Insert("ShoppingСart", "Id", shoppingCart);
            }

            

        }

        public void RemoveProductToCart(Guid token, int productId, int optionProductId)
        {
            string sqlQuery = $"delete from ShoppingСart where Token = '{token}' and ProductId={productId} and ProductOptionId={optionProductId}";
            _db.Execute(sqlQuery);
        }

        public IEnumerable<ViewCart> GetByToken(Guid token)
        {
            string sqlQuery =
                "select sc.ProductId, P.Name as ProductName, sc.ProductOptionId, po.Weight, p.ProductTypeId, sum(sc.Count) as Count, sum(sc.Count*po.Price) as TotalPrice " +
                "from ShoppingСart sc" + " join Product p on sc.ProductId = p.Id " +
                "join ProductOption po on po.Id = sc.ProductOptionId" + $" where Token = '{token}' " +
                "group by sc.ProductId, P.Name, sc.ProductOptionId, po.Weight, p.ProductTypeId, po.Price";

            var data = _db.Query<ViewCart>(sqlQuery).ToList();

            return data;
        }

        public decimal GetTotalPriceByToken(Guid token)
        {
            string sqlQuery = "select sum(sc.Count * Price) as TotalPrice " + "from ShoppingСart sc " +
                              "join ProductOption po on po.Id = sc.ProductOptionId " + $"where Token = '{token}'";

            decimal totalPrice = 0;
            try
            {
                 totalPrice = _db.ExecuteScalar<decimal>(sqlQuery);
            }
            catch (Exception ex)
            {
                totalPrice = 0;
            }
          
            return totalPrice;
        }
    }
}