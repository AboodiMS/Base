using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.UserSettings;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Entities;
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
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class ApiController : ControllerBase
    {
        private readonly ICustomPowersService _context;
        private readonly IUserSettingsService _userSettingsService; 
        private readonly ITreePowesService _treePowesService;


        public ApiController(ICustomPowersService context, IUserSettingsService userSettingsService
            , ITreePowesService treePowesService
            )
       {
           _context = context;
            _userSettingsService = userSettingsService;
            _treePowesService = treePowesService;
       }



        [HttpGet]
        public ActionResult<string> Get() => Extensions.BasePath;


        [HttpPost]
        public async Task<ActionResult<string>> Login([FromForm]LoginUsingUserNameRequestDto dto)
        {
            return await _userSettingsService.LoginUsingUserName(dto);
        }

        [HttpGet]
        [Route("TreePowers")]
        public async Task<ActionResult<List<TreePower>>> TreePowers()
        {
            return await _treePowesService.GetAsTreeAsync();
        }
    }
}
