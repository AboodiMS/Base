
using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
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
    [Route(Extensions.BasePath+ "/[controller]")]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class CustomPowerController: MasterController
    {
        private readonly ICustomPowersService _customPowersService;
        public CustomPowerController(ICustomPowersService customPowersService)
        {
            _customPowersService = customPowersService;
        }


        [HttpGet]
        [Route("GetById")]
        [AuthorizationAction]
        public async Task<ActionResult<GetCustomPowerDetailsResponseDto>> GetById([FromForm][Required] Guid id)
        {
            return await _customPowersService.GetById(id,_businessId);
        }

        [HttpGet]
        [Route("GetAll")]
        [AuthorizationAction]
        public async Task<ActionResult<List<GetCustomPowerResponseDto>>> GetByAll()
        {
            return await _customPowersService.GetAll(_businessId);
        }

        [HttpPost]
        [Route("Create")]
        [AuthorizationAction]
        public async Task<ActionResult> Create([FromForm] CreateCustomPowerRequestDto dto )
        {
            dto.Id=Guid.NewGuid();
            dto.UserId = _userId;
            dto.BusinessId = _businessId;
            await _customPowersService.Create(dto);
            return Ok(dto.Id);
        }

        [HttpPut]
        [Route("Update")]
        [AuthorizationAction]
        public async Task<ActionResult> Update([FromForm] UpdateCustomPowerRequestDto dto)
        {
            dto.UserId = _userId;
            dto.BusinessId = _businessId;
            await _customPowersService.Update(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        [AuthorizationAction]
        public async Task<ActionResult> Delete([FromForm][Required] Guid id)
        {
            await _customPowersService.Delete(id,_businessId,_userId);
            return Ok();
        }

    }
}
