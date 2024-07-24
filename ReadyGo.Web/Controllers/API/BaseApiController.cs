using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ReadyGo.Web.Controllers.API
{
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public string DecodeJwt()
        {
            var stream = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jsonToken = (JwtSecurityToken)handler.ReadToken(stream);
            return jsonToken.Claims.FirstOrDefault().Value;
        }
        [NonAction]
        public AssignedRoute CurrentRoute(List<AssignedRoute> Routes)
        {
            if (Routes != null && Routes.Count > 0)
            {
                var tempRoute = Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date > DateTime.Today);
                if (tempRoute != null)
                {
                    return tempRoute;
                }
                else
                {
                    var route = Routes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue);
                    return route;
                }
            }
            return null;
        }
      
    }
}
