using System;
using System.Collections.Generic;
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
                                $"'{user.Address}', '{user.Comment}','{now}')\n";
            }


            using (var scope = _db.GetTransaction())
            {
                // Do transacted updates here
                _db.Execute(sqlInsert);
                // Commit
                scope.Complete();

            }
        }
    }
}