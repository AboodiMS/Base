using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Helper101;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath)]
    public class ApiController : ControllerBase
    {
        private readonly ICustomPowersService _context;

       public ApiController(ICustomPowersService context)
       {
           _context = context;
       }



        [HttpGet]
        public ActionResult<string> Get() => Extensions.BasePath;


        //[HttpGet]
        //[Route("GetPowers")]
        //public object GetPowers()
        //{
        //    //var treepowers = _context.GetTreePowers();
        //    //return treepowers;
        //}
    }
}
