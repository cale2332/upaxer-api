using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace WebApp.Restful.Filters
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
        {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User == null)
            {
                filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
