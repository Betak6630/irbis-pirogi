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
        public ProductDataService ProductDataService { get; private set; }
        public TokenDataService TokenDataService { get; private set; }
        public СartDataService СartDataService { get; private set; }
        public OrderDataService OrderDataService { get; private set; }

        public Init(string nameConnectionString= "DefaultConnection")
        {
            _providerPoco = new Database(nameConnectionString);
            ProductDataService = new ProductDataService(_providerPoco);
            TokenDataService = new TokenDataService(_providerPoco);
            СartDataService = new СartDataService(_providerPoco);
            OrderDataService = new OrderDataService(_providerPoco);
        }
    }
}