using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.Identity;

namespace ReadyGo.Infrastructure.Filters
{
    public class AdminAccessFilter : ActionFilterAttribute
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminAccessFilter(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ApplicationUser CurUser = _userManager.GetUserAsync(context.HttpContext.User).Result;
            if (CurUser.Id.Equals(AppConstants.AdminUser))
            {
                return;
            }
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            base.OnActionExecuting(context);
        }
    }
}
