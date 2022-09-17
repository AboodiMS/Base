using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.IServices;
using Base.Shared.Controllers;
using Base.Shared.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Base.Modules.Companies.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath+"/[controller]")]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class CompanyController : MasterController
    {
        private readonly ICompaniesService _companiesService;

        public CompanyController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }
       
        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetCompanyResponseDto>>> GetAll()
            => await _companiesService.GetAll();

        [HttpGet]
        [Route("GetById")]
        [AuthorizationAction]
        public async Task<ActionResult<GetCompanyDetailsResponseDto>> GetById([FromForm][Required] Guid id)
            => await _companiesService.GetById(id);

        [HttpPost]
        [Route("Create")]
        [AuthorizationAction]
        public async Task<ActionResult> Create([FromForm] CreateCompanyRequestDto dto)
        {
            dto.Id = Guid.NewGuid();
            dto.UserId = _userId;
            await _companiesService.Create(dto);
            return Ok(dto.Id);
        }

        [HttpPut]
        [Route("Update")]
        [AuthorizationAction]
        public async Task<ActionResult> Update([FromForm] UpdateCompanyRequestDto dto)
        {
            dto.UserId = _userId;
            await _companiesService.Update(dto);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateActiveSections")]
        [AuthorizationAction]
        public async Task<ActionResult> UpdateActiveSections([FromForm] UpdateActiveSectionsCompanyRequestDto dto)
        {
            dto.UserId = _userId;
            await _companiesService.UpdateActiveSections(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        [AuthorizationAction]
        public async Task<ActionResult> Delete([FromForm][Required] Guid id)
        {
            await _companiesService.Delete(id,_userId);
            return Ok();
        }

    }
}
