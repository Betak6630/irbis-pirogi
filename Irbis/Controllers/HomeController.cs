using System.Collections.Generic;
using System.Web.Mvc;
using Irbis.DataService;
using Irbis.Models;
using IndexViewModel = Irbis.Models.Home.IndexViewModel;

namespace Irbis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDataService _productDataService;

        public HomeController()
        {
            var dataService = new Init();
            _productDataService = dataService.ProductDataService;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel();

            var products = GetProductsByproductType(1);

            model.Title = "Осетинские пироги";
            model.Products = products;

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Delivery()
        {
            return View();
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

                var p = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ProductTypeId = product.ProductTypeId,
                    PictureUrl = productPictureUrl,
                    Option = new List<ProductOption>()
                };

                foreach (var productOption in productOptions)
                    p.Option.Add(new ProductOption
                    {
                        Id = productOption.Id,
                        ProductId = productOption.ProductId,
                        Weight = productOption.Weight,
                        Price = productOption.Price
                    });

                products.Add(p);
            }

            return products;
        }
    }
}