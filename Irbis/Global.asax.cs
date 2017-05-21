using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using Irbis.DataService;
using Irbis.Utils.Extensions;

namespace Irbis
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static TokenDataService _tokenDataService;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var dataService = new Irbis.DataService.Init();
            _tokenDataService = dataService.TokenDataService;
        }

        protected void Application_BeginRequest()
        {
            var userId = 1;
            var token = Request.Cookies["token"]?.Value;

            if (token.IsEmpty())
            {
                //Создаем токен 
                var t = _tokenDataService.CreateToken(userId);

                //Сохраняем токен в куки
                if (!t.IsEmpty())
                {
                    var cookie = new HttpCookie("token", t);
                    Response.Cookies.Add(cookie);
                }
            }

        }
    }
}
