using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Security
{
    [AttributeUsage(AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAction : Attribute,IAuthorizationFilter,IFilterMetadata
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            var module = context.ActionDescriptor.AttributeRouteInfo.Template;
            //var controller = context.ActionDescriptor.RouteValues.ToList()[1].Value;
            //var action = context.ActionDescriptor.RouteValues.ToList()[0].Value;
            //var role = module + "/" + controller + "/" + action;
            //string _roleType = context.HttpContext.Request?.Headers["role"].ToString();


            bool IsAuthorized = context.HttpContext.User.Claims.Any( a => a.Type == ClaimTypes.Role && ( a.Value == module|| a.Value == "admin" ));

            if (!IsAuthorized)
                context.Result = new ObjectResult(new
                {
                    title = "Unauthorized"
                })
                {
                        StatusCode=401
                };
        }
    }
}
