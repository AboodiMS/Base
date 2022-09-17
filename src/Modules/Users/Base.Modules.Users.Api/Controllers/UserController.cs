using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Controllers;
using Base.Shared.Security;
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
    public class UserController:MasterController
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("GetById")]
        [AuthorizationAction]
        public async Task<ActionResult<GetUserDetailsResponseDto>> GetById([FromForm][Required] Guid id)
        {
            return await _usersService.GetById(id, _businessId);
        }

        [HttpGet]
        [Route("GetAll")]
        [AuthorizationAction]
        public async Task<ActionResult<List<GetUserResponseDto>>> GetByAll()
        {
            return await _usersService.GetAll(_businessId);
        }

        [HttpPost]
        [Route("Create")]
        [AuthorizationAction]
        public async Task<ActionResult> Create([FromForm] CreateUserRequestDto dto)
        {
            dto.Id = Guid.NewGuid();
            dto.UserId = _userId;
            dto.BusinessId = _businessId;
            await _usersService.Create(dto);
            return Ok(dto.Id);
        }

        [HttpPut]
        [Route("Update")]
        [AuthorizationAction]
        public async Task<ActionResult> Update([FromForm] UpdateUserRequestDto dto)
        {
            dto.UserId = _userId;
            dto.BusinessId = _businessId;
            await _usersService.Update(dto);
            return Ok();
        }

        [HttpPatch]
        [Route("ChangePowers")]
        [AuthorizationAction]
        public async Task<ActionResult> ChangePowers([FromForm] ChangePowersRequestDto dto)
        {
            dto.UserId = _userId;
            dto.BusinessId = _businessId;
            await _usersService.ChangePowers(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        [AuthorizationAction]
        public async Task<ActionResult> Delete([FromForm][Required] Guid id)
        {
            await _usersService.Delete(id, _businessId, _userId);
            return Ok();
        }

    }
}
