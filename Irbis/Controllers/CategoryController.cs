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

        public ActionResult Index(int page)
        {
            var model = new IndexViewModel();

            if (page == 1)
            {
                var data = _productDataService.GetProducts();
                var products = new List<Product>();

                foreach (var item in data)
                {
                    products.Add(new Product()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        ProductTypeId = item.ProductTypeId
                    });
                }

                model.Title = "Осетинские пироги";
                model.Products = products;
            }

            if (page == 2)
            {
                model.Title = "Русские пироги";
            }

            return View(model);
        }
    }
}