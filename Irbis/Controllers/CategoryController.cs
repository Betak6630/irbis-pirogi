using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
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

        public ActionResult Index(int productTypeId)
        {
            var model = new IndexViewModel();

            if (productTypeId == 1)
            {
                var products = GetProductsByproductType(productTypeId);
                model.Title = "Осетинские пироги";
                model.Products = products;
            }

            if (productTypeId == 2)
            {
                var products = GetProductsByproductType(productTypeId);
                model.Title = "Сладкие пироги";
                model.Products = products;
            }

            if (productTypeId == 3)
            {
                var products = GetProductsByproductType(productTypeId);
                model.Title = "Постные пироги";
                model.Products = products;
            }

            return View(model);
        }

        private List<Product> GetProductsByproductType(int productTypeId)
        {
            var data = _productDataService.GetProductsByProductTypeId(productTypeId);
            var products = new List<Product>();

            foreach (var product in data)
            {
                var productOptions = _productDataService.GetProductOptionsByProductId(product.Id);

                var productPicture = _productDataService.GetPictureByProduct(product.Id);
                var productPictureUrl = productPicture.PictureUrl;

                var p = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ProductTypeId = product.ProductTypeId,
                    PictureUrl = productPictureUrl,
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

            return products;
        }
    }
}