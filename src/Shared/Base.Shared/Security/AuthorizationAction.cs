using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Security
{
    [AttributeUsage(AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAction : Attribute,IAuthorizationFilter,IFilterMetadata
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var xd = context.ActionDescriptor;
            var module = context.ActionDescriptor.AttributeRouteInfo.Template;
            var controller = xd.RouteValues.ToList()[1].Value;
            var action = xd.RouteValues.ToList()[0].Value;

            string _roleType = context.HttpContext.Request?.Headers["role"].ToString();

            var a = 0;
            if (!context.HttpContext.Items.ContainsKey("User"))
            {
                context.Result = new JsonResult("Permission denined!");
            }
        }
        //private readonly string _actionName;
        //private readonly string _roleType;
        //public AuthorizationAction(string actionName, string roleType)
        //{
        //    _actionName = actionName;
        //    _roleType = roleType;
        //}
        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
         
        //    switch (_actionName)
        //    {
        //        case "Index":
        //            if (!_roleType.Contains("admin")) context.Result = new JsonResult("Permission denined!");
        //            break;
        //    }
        //}
    }
}
