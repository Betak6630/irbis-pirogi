using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Irbis.DataService;
using Irbis.Models;
using IndexViewModel = Irbis.Models.Category.IndexViewModel;

namespace Irbis.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDataService _productDataService;

        public CategoryController()
        {
            var dataService = new Irbis.DataService.Init();
            _productDataService = dataService.ProductDataService;
        }

        public ActionResult Index(int productType)
        {
            var model = new IndexViewModel();

            if (productType == 1)
            {
                var data = _productDataService.GetProducts();
                var products = new List<Product>();

                foreach (var item in data)
                {
                    var productOptions = _productDataService.GetProductOptionsByProductId(item.Id);

                    var p = new Product()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        ProductTypeId = item.ProductTypeId,
                        Option = new List<ProductOption>()
                    };

                    foreach (var productOption in productOptions)
                    {
                        p.Option.Add(new ProductOption()
                        {
                            Id = productOption.Id,
                            ProductId = productOption.ProductId,
                            Weight = productOption.Weight,
                            Price = productOption.Price
                        });
                    }

                    products.Add(p);
                }

                model.Title = "Пироги";
                model.Products = products;
            }

            if (productType == 2)
            {
                model.Title = "Русские пироги";
            }

            return View(model);
        }
    }
}