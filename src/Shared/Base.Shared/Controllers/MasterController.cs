

using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Base.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        // first Upload
        public Guid _UserId = Guid.Empty;

        public MasterController()
        {
            if (Request != null && _UserId == Guid.Empty)
                GetUserId();
        }

        protected void GetUserId()
        {
            string id = HttpContext.User.Claims.Where(x => x.Type == "ID").FirstOrDefault().Value;

            if (string.IsNullOrEmpty(id))
                _UserId = Guid.Empty;
            else
                _UserId = Guid.Parse(id);
        }
    }
}
