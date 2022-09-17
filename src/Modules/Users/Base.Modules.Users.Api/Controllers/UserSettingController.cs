using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.DTO.UserSettings;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath + "/[controller]")]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class UserSettingController:MasterController
    {
        private readonly IUserSettingsService _userSettingsService;
        public UserSettingController(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }


        [HttpGet]
        [Route("GetUserInfo")]
        [Authorize]
        public async Task<ActionResult<GetUserDetailsResponseDto>> GetUserInfo()
        {
            return await _userSettingsService.GetUserInfo(_userId,_businessId);
        }

        [HttpPatch]
        [Route("LoginUsingEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> LoginUsingEmail([FromForm] LoginUsingEmailRequestDto dto)
        {
            return await _userSettingsService.LoginUsingEmail(dto);
        }

        [HttpPatch]
        [Route("LoginUsingUserName")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> LoginUsingUserName([FromForm] LoginUsingUserNameRequestDto dto)
        {
            return await _userSettingsService.LoginUsingUserName(dto);
        }

        [HttpPatch]
        [Route("SendVerifyCodeToEmail")]
        [Authorize]
        public async Task<ActionResult> SendVerifyCodeToEmail()
        {
            await _userSettingsService.SendVerifyCodeToEmail(_userId,_businessId);
            return Ok();
        }

        [HttpPatch]
        [Route("VerifyEmail")]
        [Authorize]
        public async Task<ActionResult> VerifyEmail([Required] string code)
        {
            await _userSettingsService.VerifyEmail(_userId, _businessId,code);
            return Ok();
        }

        [HttpPatch]
        [Route("ChangeEmail")]
        [Authorize]
        public async Task<ActionResult> ChangeEmail([Required][EmailAddress] string email)
        {
            await _userSettingsService.ChangeEmail(_userId, _businessId, email);
            return Ok();
        }

        [HttpPatch]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<ActionResult> ChangePassword([FromForm] ChangePasswordRequestDto dto)
        {
            dto.Id = _userId;
            dto.BusinessId=_businessId;
            await _userSettingsService.ChangePassword(dto);
            return Ok();
        }

        [HttpPatch]
        [Route("ChangePasswordAndSendUsingEmail****")]
        [AllowAnonymous]
        public async Task<ActionResult> ChangePasswordAndSendUsingEmail([Required][EmailAddress] string email)
        {
            await _userSettingsService.ChangePasswordAndSendUsingEmail(_businessId,email);
            return Ok();
        }
    }
}
