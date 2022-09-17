using Base.Modules.Users.Domain.DTO.TreePower;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Controllers;
using Base.Shared.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath + "/TreePower")]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class TreePowerController:MasterController
    {
        private readonly ITreePowesService _treePowersService;
        public TreePowerController(ITreePowesService treePowersService)
        {
            _treePowersService = treePowersService;
        }


        [HttpGet]
        [Route("GetAll")]
        [AuthorizationAction]
        public  ActionResult<List<GetTreePowerResponseDto>> GetByAll()
        {
            return  _treePowersService.GetAll();
        }
    }
}
