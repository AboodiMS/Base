
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Base.Modules.Companies.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath)]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => Extensions.BasePath;
    }
}
