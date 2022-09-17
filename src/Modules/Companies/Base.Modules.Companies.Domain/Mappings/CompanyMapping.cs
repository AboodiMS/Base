
using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.Entities;
using System.Linq;

namespace Base.Modules.Companies.Domain.Mappings
{
    public static class CompanyMapping
    {
        private static List<Section> GetSections(List<Section> sections,string[]? activesections)
        {
            if (activesections == null)
                return new List<Section>();
            var AS = activesections.ToList();
            return sections.Join(AS, a => a.Code, b => b, (a, b) => a).ToList();
               
        }
        public static GetCompanyDetailsResponseDto AsDto(this Company entity, List<Section> sections)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name,
                CompanyWork = entity.CompanyWork,
                ActiveSections = GetSections(sections,entity.ActiveSections)
            };

        public static GetCompanyResponseDto AsDto(this Company entity)
            => new()
            {
                Id = entity.Id,
                Name = entity.Name,
                CompanyWork = entity.CompanyWork,
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

            entity.LastUpdateUserId = dto.UserId;
            entity.LastUpdateDate = DateTime.Now;
            return entity;
        }

        public static Company AsEntity(this CreateCompanyRequestDto dto)
            => new Company
            {
                Id = dto.Id,
                CompanyWork = dto.CompanyWork,
                Name = dto.Name,
                ActiveSections = dto.ActiveSections,

                CreatedDate = DateTime.Now,
                LastUpdateUserId = dto.UserId,
                IsDeleted=false
            };
    }
}
