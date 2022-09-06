
using Base.Modules.Companies.Domain.DTO.Company;



namespace Base.Modules.Companies.Domain.IServices
{
    public interface ICompaniesService
    {
        Task<GetCompanyDetailsResponseDto> GetById(Guid id);
        Task<List<GetCompanyResponseDto>> GetAll();
        Task Add(AddCompanyRequestDto dto);
        Task Update(UpdateCompanyRequestDto dto);
        Task UpdateActiveSections(UpdateActiveSectionsCompanyRequestDto dto);
        Task Delete(Guid id, Guid userid);
    }
}
