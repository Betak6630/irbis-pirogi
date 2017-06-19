using System;
using System.Collections.Generic;
using System.Linq;
using Irbis.Entities;
using PetaPoco;

namespace Irbis.DataService
{
    public class OrderDataService
    {
        private Database _db;

        public OrderDataService(Database db)
        {
            _db = db;
        }


        public void SaveOrder(IEnumerable<ShoppingСart> shoppingСarts, User user, Guid token)
        {
            var now = DateTime.Now;
            var sqlInsert = "";

            foreach (var shoppingСart in shoppingСarts)
            {
                sqlInsert += $"insert into [Order] Values('{shoppingСart.Token}', {shoppingСart.ProductId}, " +
                                $"{shoppingСart.ProductOptionId}, {shoppingСart.Count}, '{user.Name}', '{user.Phone}'," +
                                $"'{user.Address}', '{user.Comment}', @now)\n";
            }


            using (var scope = _db.GetTransaction())
            {
                // Do transacted updates here
                _db.Execute(sqlInsert, new { now = now });
                // Commit
                scope.Complete();

            }
        }

        public IEnumerable<ViewOrder> GetOrder(Guid token, DateTime createdAt)
        {
            string sqlQuery = "SELECT o.Token, o.UserName, o.UserPhone, o.UserAddress, o.UserComment, o.ProductId, " +
                              "p.NAME AS ProductName, o.ProductOptionId, po.Weight, p.ProductTypeId, " +
                              "po.Price, sum(o.Count) AS Count, sum(o.Count * po.Price) AS TotalPrice, o.CreatedAt " +
                              "FROM[Order] o JOIN Product p ON o.ProductId = p.Id " +
                              "JOIN ProductOption po ON po.Id = o.ProductOptionId " +
                              "WHERE token = @token and o.createdAt=@createdAt " +
                              "GROUP BY o.Token, o.UserName, o.UserPhone, o.UserAddress, o.UserComment, " +
                              "o.ProductId, o.ProductOptionId, o.CreatedAt, p.NAME, p.ProductTypeId, " +
                              "po.Weight, po.Price";

            var data = _db.Query<ViewOrder>(sqlQuery, new { token = token, createdAt = createdAt }).ToList();

            return data;
        }

        public DateTime GetLastDateTimeOrder(Guid token)
        {
            var query = "select top 1 CreatedAt from [Order] where  " +
                        $"Token = '{token}' order by CreatedAt desc";

            var dateTime = _db.ExecuteScalar<DateTime>(query);

            return dateTime;
        }
    }
}