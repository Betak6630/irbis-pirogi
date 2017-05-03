﻿using System;
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

        public Init(string nameConnectionString= "DefaultConnection")
        {
            _providerPoco = new Database(nameConnectionString);
            ProductDataService = new ProductDataService(_providerPoco);
        }
    }
}