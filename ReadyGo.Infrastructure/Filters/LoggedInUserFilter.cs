using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Infrastructure.Filters
{
    public class LoggedInUserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            base.OnActionExecuting(context);
        }
    }
}
