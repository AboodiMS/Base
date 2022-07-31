
using Base.Modules.Companies.Domain.DTO.Company;



namespace Base.Modules.Companies.Domain.IServices
{
    public interface ICompaniesService
    {
        Task Update(UpdateCompanyRequestDto dto);
        Task UpdateActiveSections(UpdateActiveSectionsCompanyRequestDto dto);
        Task<GetCompanyResponseDto> GetCompany(Guid id);
    }
}
