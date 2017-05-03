using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irbis.Entities;
using PetaPoco;

namespace Irbis.DataService
{
    public class ProductDataService
    {
        private Database _db;

        public ProductDataService(Database db)
        {
            _db = db;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id)
        {
            var data = _db.Query<Product>("select * from product where id=" + id).FirstOrDefault();
            return data;
        }

        public IEnumerable<Product> GetProducts()
        {
            var data = _db.Query<Product>("select * from product").ToList();

            return data;
        }
    }
}
