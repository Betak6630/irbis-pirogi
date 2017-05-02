using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace Irbis.DataService
{
    public class Init
    {
        private Database _providerPoco;
        public ProductDataService ProductDataService;
        public Init(string connectionString)
        {
            var _providerPoco = new Database(connectionString);
            ProductDataService = new ProductDataService(_providerPoco);


        }
    }
}
