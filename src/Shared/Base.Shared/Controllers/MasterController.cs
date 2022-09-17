

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
        public Guid _userId
        {
            get { return GetUserId(); }
        }
        public Guid _businessId 
        {
            get { return GetBusinessId(); }
        }

        protected Guid GetUserId()
        {
            try
            {
                string id = HttpContext.User.Claims.Where(x => x.Type == "UserId").FirstOrDefault().Value;        
                return Guid.Parse(id);
            }
            catch
            {
               return Guid.Empty;
            }

        }
        protected Guid GetBusinessId()
        {
            try
            {
                string id = HttpContext.User.Claims.Where(x => x.Type == "BusinessId").FirstOrDefault().Value;
                return Guid.Parse(id);
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
