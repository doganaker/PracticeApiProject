using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PracticeApiProject.UI.CustomAttributes
{
    public class AdminAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if(user == null || !user.Identity.IsAuthenticated || user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value != "Admin")
            {
                context.Result = new ChallengeResult(JwtBearerDefaults.AuthenticationScheme);
            }
        }
    }
}
