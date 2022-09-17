using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.CustomPower;
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
        private readonly ICustomPowersService _customPowersService;
        private readonly IUserSettingsService _userSettingsService; 
        private readonly ITreePowesService _treePowesService;


        public ApiController(ICustomPowersService customPowersService, IUserSettingsService userSettingsService
            , ITreePowesService treePowesService
            )
       {
            _customPowersService = customPowersService;
            _userSettingsService = userSettingsService;
            _treePowesService = treePowesService;
       }



        [HttpGet]
        public ActionResult<string> Get() => Extensions.BasePath;
    }
}
