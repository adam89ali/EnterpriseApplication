using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseApplication.UI.Filters
{
    public class GlobalAuthorizationHandler : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.ActionDescriptor.RouteValues["controller"].ToString() == "AccountSecurity" &&
                context.ActionDescriptor.RouteValues["action"].ToString() == "Login")
                return;
            if (context.HttpContext.User.Identity.IsAuthenticated)
                return;
            context.Result = new RedirectToRouteResult(new
               RouteValueDictionary(new { controller = "AccountSecurity", Action = "Login" }));


        }
    }
}
