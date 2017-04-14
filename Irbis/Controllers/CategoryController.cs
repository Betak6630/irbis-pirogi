using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Irbis.Models.Category;

namespace Irbis.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index(int page)
        {
            var model=new IndexViewModel();

            if (page==1)
            {
                model.Title = "Осетинские пироги";
            }

            if (page == 2)
            {
                model.Title = "Русские пироги";
            }

            return View(model);
        }
    }
}