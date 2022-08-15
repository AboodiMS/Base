
using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.Entities;

namespace Base.Modules.Companies.Domain.Mappings
{
    public static class CompanyMapping
    {
        public static GetCompanyResponseDto AsDto(this Company entity)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name.Trim(),
                CompanyWork = entity.CompanyWork.Trim(),
                ActiveSections = entity.ActiveSections,
            };

        public static Company AsEntity(this UpdateActiveSectionsCompanyRequestDto dto, Company entity)
        {
            entity.Id = dto.Id;
            entity.ActiveSections = dto.ActiveSections;
            return entity;
        }

        public static Company AsEntity(this UpdateCompanyRequestDto dto, Company entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name.Trim();
            entity.CompanyWork = dto.CompanyWork.Trim();
            return entity;
        }
    }
}
