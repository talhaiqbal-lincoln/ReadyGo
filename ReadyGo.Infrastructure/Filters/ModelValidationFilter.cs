using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace ReadyGo.Infrastructure.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(m => m.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(errors);
            }

            base.OnActionExecuting(context);
        }
    }
}