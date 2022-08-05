using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Base.Modules.Companies.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath+"/[controller]")]
    public class CompaniesController: ControllerBase
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<GetCompanyResponseDto>> GetById(Guid companyId)
            => await _companiesService.GetCompany(companyId);

        [HttpPatch]
        [Route("Update")]
        public async Task Update(UpdateCompanyRequestDto dto)
            => await _companiesService.Update(dto);

        [HttpPatch]
        [Route("UpdateActiveSections")]
        public async Task UpdateActiveSections(UpdateActiveSectionsCompanyRequestDto dto)
            => await _companiesService.UpdateActiveSections(dto);

    }
}
