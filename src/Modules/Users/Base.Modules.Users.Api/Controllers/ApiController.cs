

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath)]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class ApiController : ControllerBase
    {
        public ApiController()
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> Get() => Extensions.BasePath;
    }
}
