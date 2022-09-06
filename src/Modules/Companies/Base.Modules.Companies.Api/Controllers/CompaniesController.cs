using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Modules.Companies.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath+"/[controller]")]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class CompaniesController: ControllerBase
    {
        private readonly ICompaniesService _companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetRange")]
        public async Task<ActionResult<List<GetCompanyResponseDto>>> GetRange()
            => await _companiesService.GetAll();

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<GetCompanyDetailsResponseDto>> GetById(Guid companyId)
            => await _companiesService.GetById(companyId);

        [HttpPost]
        [Route("Add")]
        public async Task<Guid> Add(AddCompanyRequestDto dto)
        {
            throw new NotImplementedException();
            //dto.Id = Guid.NewGuid();
            //dto.UserId = Guid.NewGuid();
            //await _companiesService.Add(dto);
        }

        [HttpPut]
        [Route("Update")]
        public async Task Update([FromForm]UpdateCompanyRequestDto dto)
        {
            throw new NotImplementedException();
            //await _companiesService.Update(dto);
        }

        [HttpPatch]
        [Route("UpdateActiveSections")]
        public async Task UpdateActiveSections([FromForm]UpdateActiveSectionsCompanyRequestDto dto)
        {
            throw new NotImplementedException();
            //await _companiesService.UpdateActiveSections(dto);
        }



    }
}
