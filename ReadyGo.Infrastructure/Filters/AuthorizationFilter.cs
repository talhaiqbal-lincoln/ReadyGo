using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ReadyGo.Infrastructure.Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        public readonly ApplicationDbContext _dbContext;
        public readonly UserManager<ApplicationUser> _userManager;
        public AuthorizationFilter(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var curUser = await _userManager.GetUserAsync(context.HttpContext.User);
            var user = _userManager.Users.Include(x => x.Role).First(x=>x.Id.Equals(curUser.Id));
            string role = user.Role.Name;
            if (role.CompareTo("Admin") == 1)
            {
                bool permission = CheckPermission(context, role);
                if (!permission)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }

        private bool CheckPermission(AuthorizationFilterContext context, string role)
        {
            string key = role + "_" + context.RouteData.Values["Controller"];
            string permission = _dbContext.Configurations.Where(x => x.ConfigKey == key).FirstOrDefault()?.Value;
            return permission == "1" ? true : false;
        }

    }
}
