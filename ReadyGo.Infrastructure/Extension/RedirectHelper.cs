using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ReadyGo.Infrastructure.Extension
{
    /// <summary>
    /// Used to redirect the user to login page if the user tries to access home pages without logging in on the web app and returns 
    /// Unauthorized status code when the user tries to access api actions that require login before logging in.
    /// </summary>
    public static class RedirectHelper
    {
        public static Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(HttpStatusCode statusCode,
            Func<RedirectContext<CookieAuthenticationOptions>, Task> existingRedirector) =>
        context => {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                context.Response.StatusCode = (int)statusCode;
                return Task.CompletedTask;
            }
            return existingRedirector(context);
        };

    }
}
