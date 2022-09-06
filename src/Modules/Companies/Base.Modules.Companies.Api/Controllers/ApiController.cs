
using Base.Shared.Security;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Base.Modules.Companies.Api.Controllers
{
    
    [ApiController]
    [Route(Extensions.BasePath)]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class ApiController : ControllerBase
    {
        
        [HttpGet]
        [AuthorizationAction]
        public ActionResult<string> Get101() => Extensions.BasePath;
    }
}
