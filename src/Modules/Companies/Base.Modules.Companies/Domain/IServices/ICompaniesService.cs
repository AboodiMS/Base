
using Base.Modules.Companies.Domain.DTO.Company;
using Base.Shared.IServices;

namespace Base.Modules.Companies.Domain.IServices
{
    public interface ICompaniesService
    {
        Task<GetCompanyDetailsResponseDto> GetById(Guid id);
        Task<List<GetCompanyResponseDto>> GetAll();
        Task Create(CreateCompanyRequestDto dto);
        Task Update(UpdateCompanyRequestDto dto);
        Task UpdateActiveSections(UpdateActiveSectionsCompanyRequestDto dto);
        Task Delete(Guid id, Guid Companyid);
        Task Restore(Guid id, Guid Companyid);
        Task ActiveOneMonth(Guid id, Guid Companyid);

    }
}
