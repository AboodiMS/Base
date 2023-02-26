

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Modules.Companies.Api.Controllers
{
    
    [ApiController]
    [Route(Extensions.BasePath)]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class ApiController : ControllerBase
    {
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> Get() => Extensions.BasePath;
    }
}
