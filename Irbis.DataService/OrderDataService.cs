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
            ;
        }
    }
}