using Base.Shared.Database;
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
        private List<string> SuperRules { get; set; } = new List<string>();
        private string RuleName { get; set; } = string.Empty;
        private Guid UserId { get; set; } = Guid.Empty;
        private Guid BusinessId { get; set; } = Guid.Empty;
        private List<Claim> Claims { get; set; } = new List<Claim>();
        private bool IsAuthorized { get; set; } = false;

        public AuthorizationAction()
        {
            SuperRules.Add("companies-module/Company/Create");
            SuperRules.Add("companies-module/Company/UpdateActiveSections");
            SuperRules.Add("companies-module/Company/Delete");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            RuleName = context.ActionDescriptor.AttributeRouteInfo.Template;

            var userid = context.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "UserId")?.Value;
            UserId = userid is null?Guid.Empty: Guid.Parse(userid);

            var businessid = context.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "BusinessId")?.Value;
            BusinessId = businessid is null ? Guid.Empty: Guid.Parse(businessid);

            Claims = context.HttpContext.User.Claims.ToList();
            CheckAuthorization(context);
        }
        private void ValidateNormalRule()
        {
            IsAuthorized =  Claims.Any(a => a.Type == ClaimTypes.Role && (a.Value == RuleName || a.Value == "admin"));
        }
        private void ValidateSuperRule()
        {
            IsAuthorized = UserId == BaseModulesData.SupperAdminId && BusinessId == BaseModulesData.SupperBusinessId;
        }
        private void CheckAuthorization(AuthorizationFilterContext context)
        {
            if (SuperRules.Any(a => a == RuleName) )
                ValidateNormalRule();
            else
                ValidateSuperRule();

            if (!IsAuthorized)
               throw new UnauthorizedAccessException();
        }
    }
}
