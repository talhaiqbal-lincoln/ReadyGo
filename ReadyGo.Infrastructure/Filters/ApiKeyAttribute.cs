using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadyGo.Domain.Constants;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ReadyGo.Infrastructure.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "X-API-KEY";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Content = ErrorMessageConstants.MissingAPIKey
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!extractedApiKey[0].Contains(apiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = ErrorMessageConstants.InvalidAPIKey
                };
                return;
            }

            if (!extractedApiKey[0].Contains("Bearer"))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = ErrorMessageConstants.InvalidHeader
                };
                return;
            }

            await next();
        }
    }
}
