using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Irbis.Controllers
{
    public partial class BaseController : Controller
    {
        public Guid Token = Guid.Empty;

        public BaseController()
        {

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var tokenStr = Request.Cookies["token"]?.Value;

            if (tokenStr != null && !tokenStr.IsEmpty())
            {
                Token = Guid.Parse(tokenStr);
            }
        }
    }
}